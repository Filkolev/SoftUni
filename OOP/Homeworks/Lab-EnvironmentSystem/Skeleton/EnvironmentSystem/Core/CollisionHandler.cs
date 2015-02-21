namespace EnvironmentSystem.Core
{
    using System.Collections.Generic;
    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.Data.Structures;

    public static class CollisionHandler
    {
        private static QuadTree<ICollidable> collidingObjects;

        public static void Initlialize(int worldWidth, int worldHeight)
        {
            collidingObjects = new QuadTree<ICollidable>(0, new Rectangle(0, 0, worldWidth, worldHeight));
        }

        public static void HandleCollisions(IList<EnvironmentObject> objects)
        {
            foreach (var obj in objects)
            {
                collidingObjects.Insert(obj);
            }

            foreach (var obj in objects)
            {
                var candidateCollisionItems = collidingObjects.GetItems(new List<ICollidable>(), obj.Bounds);

                foreach (var item in candidateCollisionItems)
                {
                    if (Rectangle.Intersects(obj.Bounds, item.Bounds) && item != obj)
                    {
                        var collisionInfo = new CollisionInfo(item);
                        obj.RespondToCollision(collisionInfo);
                    }
                }
            }

            collidingObjects.Clear();
        }
    }
}
