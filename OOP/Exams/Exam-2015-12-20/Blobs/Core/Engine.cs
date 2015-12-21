namespace Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class Engine : IEngine
    {
        private IBlobFactory blobFactory;
        private IAttackFactory attackFactory;
        private IBehaviorFactory behaviorFactory;
        private IInputReader reader;
        private IOutputWriter outputWriter;

        private readonly ICollection<IBlob> blobs = new List<IBlob>();
        private readonly IDictionary<string, IBlob> blobsByName = new Dictionary<string, IBlob>();

        public Engine(
            IBlobFactory blobFactory,
            IAttackFactory attackFactory,
            IBehaviorFactory behaviorFactory,
            IInputReader reader,
            IOutputWriter outputWriter)
        {
            this.BlobFactory = blobFactory;
            this.AttackFactory = attackFactory;
            this.BehaviorFactory = behaviorFactory;
            this.InputReader = reader;
            this.OutputWriter = outputWriter;
        }

        protected IBlobFactory BlobFactory
        {
            get
            {
                return this.blobFactory;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The engine's blob factory cannot be null.");
                }

                this.blobFactory = value;
            }
        }

        protected IAttackFactory AttackFactory
        {
            get
            {
                return this.attackFactory;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The engine's attack factory cannot be null.");
                }

                this.attackFactory = value;
            }
        }

        protected IBehaviorFactory BehaviorFactory
        {
            get
            {
                return this.behaviorFactory;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The engine's behavior factory cannot be null.");
                }

                this.behaviorFactory = value;
            }
        }

        protected IInputReader InputReader
        {
            get
            {
                return this.reader;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The engine's input reader cannot be null.");
                }

                this.reader = value;
            }
        }

        protected IOutputWriter OutputWriter
        {
            get
            {
                return this.outputWriter;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "The engine's output writer cannot be null.");
                }

                this.outputWriter = value;
            }
        }

        protected bool AreEventsMonitored { get; set; } = false;

        protected StringBuilder Output { get; } = new StringBuilder();

        public virtual void Run()
        {
            while (true)
            {
                var commandArgs = this.reader.ReadLine().Split();

                this.ProcessCommand(commandArgs);
                this.Update();
            }
        }

        public virtual void ProcessCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0];

            switch (commandName)
            {
                case "drop":
                    Environment.Exit(0);
                    break;
                case "pass":
                    break;
                case "create":
                    this.CreateBlob(commandArgs);
                    break;
                case "attack":
                    this.PerformAttack(commandArgs);
                    break;
                case "status":
                    this.PrintStatus();
                    break;
                case "report-events":
                    this.AreEventsMonitored = true;
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }
        }

        public virtual void Update()
        {
            foreach (IBlob blob in this.blobs)
            {
                blob.Update();
            }
        }

        private void CreateBlob(string[] commandArgs)
        {
            string name = commandArgs[1];
            int health = int.Parse(commandArgs[2]);
            int damage = int.Parse(commandArgs[3]);
            string behavior = commandArgs[4];
            string attack = commandArgs[5];

            var blob = this.blobFactory.CreateBlob(
                name,
                health,
                damage,
                attack,
                behavior,
                this.attackFactory,
                this.behaviorFactory);

            this.blobs.Add(blob);
            this.blobsByName.Add(name, blob);

            if (this.AreEventsMonitored)
            {
                blob.OnToggleBehavior += this.PrintToggleBehaviorInfo;
                blob.OnBlobDeath += this.PrintBlobDeathInfo;
            }
        }

        private void PerformAttack(string[] commandArgs)
        {
            var attackerName = commandArgs[1];
            if (!this.blobsByName.ContainsKey(attackerName))
            {
                throw new ArgumentException("Attacking blob does not exist.");
            }

            var attacker = this.blobsByName[attackerName];

            if (!attacker.IsAlive)
            {
                throw new InvalidOperationException("A dead blob cannot produce an attack.");
            }

            var defenderName = commandArgs[2];
            if (!this.blobsByName.ContainsKey(defenderName))
            {
                throw new ArgumentException("Defending blob does not exist.");
            }

            var defender = this.blobsByName[defenderName];

            if (!defender.IsAlive)
            {
                throw new InvalidOperationException("A dead blob cannot be attacked.");
            }

            var attack = attacker.ProduceAttack();
            defender.Health -= attack.Damage;
        }

        private void PrintStatus()
        {
            foreach (IBlob blob in this.blobs)
            {
                this.Output.AppendLine(blob.ToString());
            }

            this.outputWriter.WriteLine(this.Output.ToString().Trim());
            this.Output.Clear();
        }

        private void PrintToggleBehaviorInfo(IBlob sender, EventArgs eventArgs)
        {
            this.outputWriter.WriteLine($"Blob {sender.Name} toggled {sender.BehaviorType}");
        }

        private void PrintBlobDeathInfo(IBlob sender, EventArgs eventargs)
        {
            this.outputWriter.WriteLine($"Blob {sender.Name} was killed");
        }
    }
}
