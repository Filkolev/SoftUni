namespace RPG.Items
{
    using Attributes;

    [Item]
    public class HealthPotion : Item
    {
        private const int DefaultHealthRestore = 100;

        public HealthPotion(Position position)
            : base(position)
        {
            this.HealthRestore = DefaultHealthRestore;
        }

        public int HealthRestore { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: Health restore ({1})", this.GetType().Name, this.HealthRestore);
        }
    }
}
