namespace EnvironmentSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Linq;

    using EnvironmentSystem.Models;
    using EnvironmentSystem.Models.Objects;
    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models.Data.Structures;
    using EnvironmentSystem.Core.Generator;
    
    public class Engine
    {
        private const int WorldWidth = 50;
        private const int WorldHeight = 30;
        private const int LoopIntervalInMilliseconds = 200;

        private Rectangle worldBounds;
        private List<EnvironmentObject> objects;
        private IRenderer consoleRenderer;
        private ObjectGenerator objectGenerator;

        public Engine()
        {
            this.objects = new List<EnvironmentObject>();
            this.consoleRenderer = new ConsoleRenderer(WorldWidth, WorldHeight);
            this.objectGenerator = new ObjectGenerator(WorldWidth, WorldHeight);
            this.worldBounds = new Rectangle(0, 0, WorldWidth, WorldHeight);
            CollisionHandler.Initlialize(WorldWidth, WorldHeight);
        }

        public virtual void Run()
        {
            this.objectGenerator.Initiliaze(this.objects);
            while (true)
            {
                this.ExecuteEnvironmentLoop();
            }
        }

        protected virtual void ExecuteEnvironmentLoop()
        {
            this.objectGenerator.DynamicallyAdd(this.objects);

            for (int i = 0; i < this.objects.Count; i++)
            {
                this.objects[i].Update();
            }

            CollisionHandler.HandleCollisions(this.objects);
            this.ProcessObjectProduction();

            this.objects.RemoveAll(x => !x.Exists);
            this.objects.RemoveAll(x => !Rectangle.Intersects(this.worldBounds, x.Bounds));

            for (int i = 0; i < this.objects.Count; i++)
            {
                this.consoleRenderer.EnqueueForRendering(objects[i]);
            }

            this.consoleRenderer.RenderAll();
            Thread.Sleep(LoopIntervalInMilliseconds);
            this.consoleRenderer.ClearQueue();
        }

        protected virtual void Insert(EnvironmentObject obj)
        {
            this.objects.Add(obj);
        }

        private void ProcessObjectProduction()
        {
            List<EnvironmentObject> newObjects = new List<EnvironmentObject>();
            for (int i = 0; i < this.objects.Count; i++)
            {
                var producedObjects = this.objects[i].ProduceObjects();
                newObjects.AddRange(producedObjects);
            }

            foreach (var obj in newObjects)
            {
                this.Insert(obj);
            }
        }
    }
}
