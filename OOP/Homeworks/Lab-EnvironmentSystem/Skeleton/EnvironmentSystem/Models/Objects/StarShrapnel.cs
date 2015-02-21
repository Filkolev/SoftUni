namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    class StarShrapnel : EnvironmentObject
    {
        private const char StarShrapnelImage = '^';
        private const int lifetime = 2;
        private int ticks = 0;

        public StarShrapnel(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void Update()
        {
            this.ticks++;

            if (this.ticks == lifetime)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { StarShrapnelImage } };
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
