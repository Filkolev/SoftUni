namespace EnvironmentSystem.Models
{
    using System;
    using System.Collections.Generic;

    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models.Data.Structures;
    using EnvironmentSystem.Models.Objects;

    public abstract class EnvironmentObject : IRenderable, ICollidable, IObjectProducer
    {
        protected EnvironmentObject(int x, int y, int width, int height)
            : this(new Rectangle(x, y, width, height))
        {   
        }

        protected EnvironmentObject(Rectangle bounds)
        {
            this.Bounds = bounds;
            this.Exists = true;
        }

        public Rectangle Bounds { get; private set; }

        public CollisionGroup CollisionGroup { get; protected set; }

        public bool Exists { get; protected set; }

        public char[,] ImageProfile { get; protected set; }

        public abstract void Update();

        public abstract void RespondToCollision(CollisionInfo collisionInfo);

        public abstract IEnumerable<EnvironmentObject> ProduceObjects();
    }
}
