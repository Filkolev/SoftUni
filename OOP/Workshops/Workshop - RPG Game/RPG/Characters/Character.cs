namespace RPG.Characters
{
    using Engine;
    using Exceptions;
    using Interfaces;
    using Items.Shields;

    public abstract class Character : ICharacter, IShielded
    {
        private int damage;
        private int hitPoints;
        private Position position;

        protected Character(Position position, int damage, int hitPoints, int armor)
        {
            this.Position = position;
            this.Damage = damage;
            this.HitPoints = hitPoints;
            this.Armor = armor;
        }

        public virtual int Damage
        {
            get
            {
                return this.damage;
            }

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.damage = value;
            }
        }

        public virtual int Armor { get; private set; }

        public virtual int HitPoints
        {
            get
            {
                return this.hitPoints;
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.hitPoints = value;
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                bool isXPosInRange = 0 <= value.X && value.X < Constants.MapWidth;
                bool isYPosInRange = 0 <= value.X && value.X < Constants.MapHeight;

                if (!isXPosInRange || !isYPosInRange)
                {
                    throw new LocationOutOfRangeException();
                }

                this.position = value;
            }
        }

        public void Attack(ICharacter enemy)
        {
            int damageInflicted = this.Damage - enemy.Armor;

            if (damageInflicted > 0)
            {
                enemy.HitPoints -= this.Damage;
            }
        }
    }
}
