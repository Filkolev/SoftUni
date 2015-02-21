namespace TheSlum.GameObjects.Items
{
    class Pill : Bonus
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultAttackEffect = 100;

        public Pill(string id)
            : base(id, DefaultHealthEffect, DefaultDefenseEffect, DefaultAttackEffect)
        {
            this.Countdown = 1;
        }
    }
}
