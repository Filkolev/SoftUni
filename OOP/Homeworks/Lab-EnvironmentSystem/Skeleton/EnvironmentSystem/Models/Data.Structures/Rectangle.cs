namespace EnvironmentSystem.Models.Data.Structures
{
    using System;

    public class Rectangle : ICloneable
    {
        public Rectangle(int x, int y, int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.TopLeft = new Point(x, y);
        }

        public Point TopLeft { get; private set; }

        public Point BottomRight
        {
            get
            {
                return new Point(this.TopLeft.X + this.Width, this.TopLeft.Y + this.Height);
            }
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public static bool Intersects(Rectangle rectA, Rectangle rectB)
        {
            return rectA.TopLeft.X < rectB.BottomRight.X &&
                rectA.BottomRight.X > rectB.TopLeft.X &&
                rectA.TopLeft.Y < rectB.BottomRight.Y &&
                rectA.BottomRight.Y > rectB.TopLeft.Y;
        }

        public object Clone()
        {
            return new Rectangle(this.TopLeft.X, this.TopLeft.Y, this.Width, this.Height);
        }
    }
}
