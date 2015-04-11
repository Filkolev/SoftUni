namespace Microsoft._3DTools
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media.Media3D;

    /// <summary>
    ///     Trackball is a utility class which observes the mouse events
    ///     on a specified FrameworkElement and produces a Transform3D
    ///     with the resultant rotation and scale.
    /// 
    ///     Example Usage:
    /// 
    ///         Trackball trackball = new Trackball();
    ///         trackball.EventSource = myElement;
    ///         myViewport3D.Camera.Transform = trackball.Transform;
    /// 
    ///     Because Viewport3Ds only raise events when the mouse is over the
    ///     rendered 3D geometry (as opposed to not when the mouse is within
    ///     the layout bounds) you usually want to use another element as 
    ///     your EventSource.  For example, a transparent border placed on
    ///     top of your Viewport3D works well:
    ///     
    ///         <Grid>
    ///           <ColumnDefinition />
    ///           <RowDefinition />
    ///           <Viewport3D Name="myViewport" ClipToBounds="True" Grid.Row="0" Grid.Column="0" />
    ///           <Border Name="myElement" Background="Transparent" Grid.Row="0" Grid.Column="0" />
    ///         </Grid>
    ///     
    ///     NOTE: The Transform property may be shared by multiple Cameras
    ///           if you want to have auxilary views following the trackball.
    /// 
    ///           It can also be useful to share the Transform property with
    ///           models in the scene that you want to move with the camera.
    ///           (For example, the Trackport3D's headlight is implemented
    ///           this way.)
    /// 
    ///           You may also use a Transform3DGroup to combine the
    ///           Transform property with additional Transforms.
    /// </summary> 
    public class Trackball
    {
        private readonly Transform3DGroup transform;
        private readonly ScaleTransform3D scale = new ScaleTransform3D();
        private readonly AxisAngleRotation3D rotation = new AxisAngleRotation3D();

        private FrameworkElement eventSource;
        private Point previousPosition2D;
        private Vector3D previousPosition3D = new Vector3D(0, 0, 1);

        public Trackball()
        {
            this.transform = new Transform3DGroup();
            this.transform.Children.Add(this.scale);
            this.transform.Children.Add(new RotateTransform3D(this.rotation));
        }

        /// <summary>
        ///     A transform to move the camera or scene to the trackball's
        ///     current orientation and scale.
        /// </summary>
        public Transform3D Transform
        {
            get
            {
                return this.transform;
            }
        }

        #region Event Handling

        /// <summary>
        ///     The FrameworkElement we listen to for mouse events.
        /// </summary>
        public FrameworkElement EventSource
        {
            get
            {
                return this.eventSource;
            }

            set
            {
                if (this.eventSource != null)
                {
                    this.eventSource.MouseDown -= this.OnMouseDown;
                    this.eventSource.MouseUp -= this.OnMouseUp;
                    this.eventSource.MouseMove -= this.OnMouseMove;
                }

                this.eventSource = value;

                this.eventSource.MouseDown += this.OnMouseDown;
                this.eventSource.MouseUp += this.OnMouseUp;
                this.eventSource.MouseMove += this.OnMouseMove;
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            Mouse.Capture(this.EventSource, CaptureMode.Element);
            this.previousPosition2D = e.GetPosition(this.EventSource);
            this.previousPosition3D = this.ProjectToTrackball(
                this.EventSource.ActualWidth,
                this.EventSource.ActualHeight,
                this.previousPosition2D);
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            Mouse.Capture(this.EventSource, CaptureMode.None);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(this.EventSource);

            // Prefer tracking to zooming if both buttons are pressed.
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.Track(currentPosition);
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                this.Zoom(currentPosition);
            }

            this.previousPosition2D = currentPosition;
        }

        #endregion Event Handling

        private void Track(Point currentPosition)
        {
            Vector3D currentPosition3D = this.ProjectToTrackball(
                this.EventSource.ActualWidth, this.EventSource.ActualHeight, currentPosition);

            Vector3D axis = Vector3D.CrossProduct(this.previousPosition3D, currentPosition3D);
            double angle = Vector3D.AngleBetween(this.previousPosition3D, currentPosition3D);
            Quaternion delta = new Quaternion(axis, -angle);

            // Get the current orientantion from the RotateTransform3D
            AxisAngleRotation3D r = this.rotation;
            Quaternion q = new Quaternion(this.rotation.Axis, this.rotation.Angle);

            // Compose the delta with the previous orientation
            q *= delta;

            // Write the new orientation back to the Rotation3D
            this.rotation.Axis = q.Axis;
            this.rotation.Angle = q.Angle;

            this.previousPosition3D = currentPosition3D;
        }

        private Vector3D ProjectToTrackball(double width, double height, Point point)
        {
            double x = point.X / (width / 2);    // Scale so bounds map to [0,0] - [2,2]
            double y = point.Y / (height / 2);

            x = x - 1;                           // Translate 0,0 to the center
            y = 1 - y;                           // Flip so +Y is up instead of down

            double z2 = 1 - (x * x) - (y * y);       // z^2 = 1 - x^2 - y^2
            double z = z2 > 0 ? Math.Sqrt(z2) : 0;

            return new Vector3D(x, y, z);
        }

        private void Zoom(Point currentPosition)
        {
            double yDelta = currentPosition.Y - this.previousPosition2D.Y;

            double scale = Math.Exp(yDelta / 100);    // e^(yDelta/100) is fairly arbitrary.

            this.scale.ScaleX *= scale;
            this.scale.ScaleY *= scale;
            this.scale.ScaleZ *= scale;
        }
    }
}
