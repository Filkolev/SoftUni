namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class UnstableStar : Star
    {
        private const int Lifetime = 8;
        private int ticks = 0;
        private bool exploded = false;
        private static Random rnd = new Random();

        public UnstableStar(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
        }

        public override void Update()
        {
            base.Update();

            if (this.isFalling)
            {
                this.ticks++;

                if (this.ticks == Lifetime)
                {
                    this.Exists = false;
                    this.Direction.X = 0;
                    this.Direction.Y = 0;
                }
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            List<EnvironmentObject> list = base.ProduceObjects().ToList();

            if (!this.Exists && !this.exploded)
            {
                this.exploded = true;
                int minRow = Math.Max(0, this.Bounds.TopLeft.Y - 2);
                int maxRow = Math.Min(24, this.Bounds.TopLeft.Y + 2);
                int minCol = Math.Max(0, this.Bounds.TopLeft.X - 2);
                int maxCol = Math.Min(50, this.Bounds.TopLeft.X + 2);

                for (int row = minRow; row <= maxRow; row++)
                {
                    for (int col = minCol; col <= maxCol; col++)
                    {
                        if (row == this.Bounds.TopLeft.Y && col == this.Bounds.TopLeft.X)
                        {
                            continue;
                        }
                        
                        list.Add(new StarShrapnel(col, row, 1, 1));
                    }
                }
            }
           
            return list;
        }
    }
}
