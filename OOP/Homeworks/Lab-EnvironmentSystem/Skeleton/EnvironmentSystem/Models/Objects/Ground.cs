namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    public class Ground : EnvironmentObject
    {
        protected const char GroundCharImage = '#';

        public Ground(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            char[,] image = new char[this.Bounds.Height, this.Bounds.Width];

            for (int row = 0; row < image.GetLength(0); row++)
            {
                for (int col = 0; col < image.GetLength(1); col++)
                {
                    image[row, col] = GroundCharImage;
                }
            }

            return image;
        }

        public override void Update()
        {   
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>(0);
        }
    }
}
