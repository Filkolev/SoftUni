namespace Blobs.Models
{
    using System;

    using Contracts;

    public class Blob : IBlob
    {
        private const string BehaviorSuffix = "Behavior";

        private readonly int initialHealth;

        private string name;
        private int damage;
        private int health;
        private string attackType;
        private string behaviorType;

        private IBehavior behavior;
        private IAttackFactory attackFactory;
        private IBehaviorFactory behaviorFactory;

        public Blob(
            string name,
            int damage,
            int health,
            string attackType,
            string behaviorType,
            IAttackFactory attackFactory,
            IBehaviorFactory behaviorFactory)
        {
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.initialHealth = health;
            this.AttackType = attackType;
            this.BehaviorType = behaviorType + BehaviorSuffix;
            this.AttackFactory = attackFactory;
            this.BehaviorFactory = behaviorFactory;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "A blob's name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "A blob's damage cannot be negative.");
                }

                this.damage = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                this.health = value < 0 ? 0 : value;

                if (this.Health <= this.initialHealth / 2 
                    && !this.HasActivatedBehavior)
                {
                    this.ActivateBehavior();
                }

                if (!this.IsAlive)
                {
                    this.OnBlobDeath?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public bool IsAlive => this.Health > 0;

        public string AttackType
        {
            get
            {
                return this.attackType;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "A blob's attack type cannot be empty.");
                }

                this.attackType = value;
            }
        }

        public string BehaviorType
        {
            get
            {
                return this.behaviorType;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value), "A blob's behavior type cannot be empty.");
                }

                this.behaviorType = value;
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
                    throw new ArgumentNullException(nameof(value), "A blob's attack factory cannot be null.");
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
                    throw new ArgumentNullException(nameof(value), "A blob's behavior factory cannot be null.");
                }

                this.behaviorFactory = value;
            }
        }

        protected bool HasActivatedBehavior { get; set; } = false;

        protected bool HasAttacked { get; set; } = false;

        public virtual void ActivateBehavior()
        {
            if (this.HasActivatedBehavior)
            {
                throw new InvalidOperationException("A blob can activate a behavior only once.");
            }

            this.behavior = this.behaviorFactory.CreateBehavior(this.BehaviorType, this);
            this.HasActivatedBehavior = true;
            this.behavior.Activate();

            this.OnToggleBehavior?.Invoke(this, EventArgs.Empty);
        }

        public virtual IAttack ProduceAttack()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Blob is dead and cannot attack.");
            }

            if (this.HasAttacked)
            {
                throw new InvalidOperationException("Blob cannot attack more than once per turn.");
            }

            var attack = this.attackFactory.CreateAttack(this.AttackType, this);
            this.HasAttacked = true;
            attack.ActivateEffects();

            return attack;
        }

        public virtual void Update()
        {
            if (!this.IsAlive)
            {
                return;
            }

            this.HasAttacked = false;

            if (this.HasActivatedBehavior)
            {
                this.behavior.Update();
            }
        }

        public override string ToString()
        {
            var result = this.IsAlive ?
                $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage" :
                $"Blob {this.Name} KILLED";

            return result;
        }

        public event OnToggleBehaviorEventHandler OnToggleBehavior;

        public event OnBlobDeathEventHandler OnBlobDeath;
    }
}
