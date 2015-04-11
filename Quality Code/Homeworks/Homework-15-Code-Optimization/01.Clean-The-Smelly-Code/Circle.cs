namespace Surfaces
{
    using System;
    using System.Windows.Media.Media3D;

    public sealed class Circle : Surface
    {
        private static readonly PropertyHolder<double, Circle> RadiusProperty =
            new PropertyHolder<double, Circle>("Radius", 1.0, OnGeometryChanged);

        private static readonly PropertyHolder<Point3D, Circle> PositionProperty =
            new PropertyHolder<Point3D, Circle>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

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

            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D prevPoint = this.PointForAngle(0);
            Vector3D normal = new Vector3D(0, 0, 1);

            const int Div = 180;
            for (int i = 1; i <= Div; ++i)
            {
                double angle = 2 * Math.PI / Div * i;
                Point3D newPoint = this.PointForAngle(angle);
                mesh.Positions.Add(prevPoint);
                mesh.Positions.Add(this.position);
                mesh.Positions.Add(newPoint);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                prevPoint = newPoint;
            }

            mesh.Freeze();
            return mesh;
        }

        private Point3D PointForAngle(double angle)
        {
            return new Point3D(
                this.position.X + (this.radius * Math.Cos(angle)),
                this.position.Y + (this.radius * Math.Sin(angle)),
                this.position.Z);
        }
    }
}
