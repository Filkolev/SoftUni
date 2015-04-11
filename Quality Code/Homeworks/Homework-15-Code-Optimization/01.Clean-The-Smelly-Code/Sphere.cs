namespace Surfaces
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public sealed class Sphere : Surface
    {
        private static readonly PropertyHolder<double, Sphere> RadiusProperty =
            new PropertyHolder<double, Sphere>("Radius", 1.0, OnGeometryChanged);

        private static readonly PropertyHolder<Point3D, Sphere> PositionProperty =
            new PropertyHolder<Point3D, Sphere>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

        private double radius;
        private Point3D position;

        public double Radius
        {
            get
            {
                return RadiusProperty.Get(this);
            }

            set
            {
                RadiusProperty.Set(this, value);
            }
        }

        public Point3D Position
        {
            get
            {
                return PositionProperty.Get(this);
            }

            set
            {
                PositionProperty.Set(this, value);
            }
        }

        protected override Geometry3D CreateMesh()
        {
            this.radius = this.Radius;
            this.position = this.Position;

            const int AngleSteps = 32;
            const double MinAngle = 0;
            const double MaxAngle = 2 * Math.PI;
            const double DAngle = (MaxAngle - MinAngle) / AngleSteps;

            const int YSteps = 32;
            const double MinY = -1.0;
            const double MaxY = 1.0;
            const double Dy = (MaxY - MinY) / YSteps;

            MeshGeometry3D mesh = new MeshGeometry3D();

            for (int yi = 0; yi <= YSteps; yi++)
            {
                double y = MinY + (yi * Dy);

                for (int ai = 0; ai <= AngleSteps; ai++)
                {
                    double angle = ai * DAngle;

                    mesh.Positions.Add(this.GetPosition(angle, y));
                    mesh.Normals.Add(this.GetNormal(angle, y));
                    mesh.TextureCoordinates.Add(this.GetTextureCoordinate(angle, y));
                }
            }

            for (int yi = 0; yi < YSteps; yi++)
            {
                for (int ai = 0; ai < AngleSteps; ai++)
                {
                    int a1 = ai;
                    int a2 = ai + 1;
                    int y1 = yi * (AngleSteps + 1);
                    int y2 = (yi + 1) * (AngleSteps + 1);

                    mesh.TriangleIndices.Add(y1 + a1);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y1 + a2);

                    mesh.TriangleIndices.Add(y1 + a2);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y2 + a2);
                }
            }

            mesh.Freeze();
            return mesh;
        }

        private Point3D GetPosition(double angle, double y)
        {
            double r = this.radius * Math.Sqrt(1 - (y * y));
            double x = r * Math.Cos(angle);
            double z = r * Math.Sin(angle);

            return new Point3D(
                this.position.X + x,
                this.position.Y + (this.radius * y),
                this.position.Z + z);
        }

        private Vector3D GetNormal(double angle, double y)
        {
            return (Vector3D)this.GetPosition(angle, y);
        }

        private Point GetTextureCoordinate(double angle, double y)
        {
            Matrix map = new Matrix();
            map.Scale(1 / (2 * Math.PI), -0.5);

            Point p = new Point(angle, y);
            p = p * map;

            return p;
        }
    }
}
