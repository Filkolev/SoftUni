namespace RPG.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Interfaces;

    public static class MapInitializer
    {
        private const int MinEnemySaturationRate = 5;
        private const int MaxEnemySaturationPercentage = 10;
        private const int MinItemSaturationRate = 5;
        private const int MaxItemSaturationRate = 15;

        private static readonly Random Rand = new Random();

        public static IList<IGameObject> PopulateMap()
        {
            IList<IGameObject> entities = new List<IGameObject>();

            SeedEnemies(entities);
            SeedItems(entities);

            return entities;
        }

        private static void SeedItems(IList<IGameObject> entities)
        {
            int saturation = Rand.Next(MinItemSaturationRate, MaxItemSaturationRate + 1);

            int numberOfItems = saturation * Constants.MapHeight * Constants.MapWidth / 100;

            var enemies = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(ItemAttribute)))
                .ToArray();

            for (int i = 0; i < numberOfItems; i++)
            {
                int currentX = Rand.Next(1, Constants.MapWidth);
                int currentY = Rand.Next(1, Constants.MapHeight);

                while (entities.Any(e => e.Position.X == currentX && e.Position.Y == currentY))
                {
                    currentX = Rand.Next(1, Constants.MapWidth);
                    currentY = Rand.Next(1, Constants.MapHeight);
                }

                int entityIndex = Rand.Next(0, enemies.Length);

                var entity = Activator.CreateInstance(enemies[entityIndex], new Position(currentX, currentY)) as IGameObject;

                entities.Add(entity);
            }
        }

        private static void SeedEnemies(IList<IGameObject> entities)
        {
            int saturation = Rand.Next(MinEnemySaturationRate, MaxEnemySaturationPercentage + 1);

            int numberOfEnemies = saturation * Constants.MapHeight * Constants.MapWidth / 100;

            var enemies = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(EnemyAttribute)))
                .ToArray();

            for (int i = 0; i < numberOfEnemies; i++)
            {
                int currentX = Rand.Next(1, Constants.MapWidth);
                int currentY = Rand.Next(1, Constants.MapHeight);

                while (entities.Any(e => e.Position.X == currentX && e.Position.Y == currentY))
                {
                    currentX = Rand.Next(1, Constants.MapWidth);
                    currentY = Rand.Next(1, Constants.MapHeight);
                }

                int entityIndex = Rand.Next(0, enemies.Length);

                var entity = Activator.CreateInstance(enemies[entityIndex], new Position(currentX, currentY)) as IGameObject;

                entities.Add(entity);
            }
        }
    }
}
