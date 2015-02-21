namespace TheSlum.GameObjects.Items
{
    class Axe : Item
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultAttackEffect = 75;

        public Axe(string id)
            : base(id, DefaultHealthEffect, DefaultDefenseEffect, DefaultAttackEffect)
        {
        }
    }
}
