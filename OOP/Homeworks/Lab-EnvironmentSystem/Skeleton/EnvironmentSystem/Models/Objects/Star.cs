namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    class Star : MovingObject
    {
        protected static readonly char[] StarCharImages = { '@', '0', 'o' };
        private static readonly Random rnd = new Random();
        protected int countLoops = 0;
        protected char currentImage = StarCharImages[0];
        protected bool isFalling = false;
        protected int trailCount = 0;

        public Star(int x, int y, int width, int height)
            : base(x, y, width, height, new Point(0, 0))
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void Update()
        {
            this.countLoops++;
            if (countLoops % 10 == 0)
            {
                int newIndex = rnd.Next(0, StarCharImages.Length);
                this.currentImage = StarCharImages[newIndex];
            }

            int fallChecker = rnd.Next(0, 101);

            if (fallChecker == 100 && !isFalling)
            {
                isFalling = true;
                int horizontalVelocity = rnd.Next(-1, 2);

                this.Direction.X = horizontalVelocity;
                this.Direction.Y = 1;
            }

            this.Bounds.TopLeft.Y += this.Direction.Y;
            this.Bounds.TopLeft.X += this.Direction.X;

            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Ground || collisionInfo.HitObject is StarShrapnel)
            {
                this.Exists = false;
            }
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { this.currentImage } };
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (isFalling)
            {
                this.trailCount++;
                switch (this.trailCount)
                {
                    case 1:
                        return new List<EnvironmentObject>()
                    {
                        new StarTrail(this.Bounds.TopLeft.X - (this.Direction.X * 2), this.Bounds.TopLeft.Y - 1, 1, 1, this.Direction)
                    };
                    case 2:
                        return new List<EnvironmentObject>()
                    {
                        new StarTrail(this.Bounds.TopLeft.X - (this.Direction.X * 3), this.Bounds.TopLeft.Y -2 , 1, 1, this.Direction)
                    };

                    case 3:
                        return new List<EnvironmentObject>()
                    {
                        new StarTrail(this.Bounds.TopLeft.X - (this.Direction.X * 4), this.Bounds.TopLeft.Y -3 , 1, 1, this.Direction)
                    };
                }
            }

            return new List<EnvironmentObject>();
        }
    }
}
