namespace RPG.Items.Shields
{
    using Interfaces;

    public abstract class Armor : Item, IDestroyable
    {
        protected Armor(Position position, int hitPoints)
            : base(position)
        {
            this.HitPoints = hitPoints;
        }

        public int HitPoints { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: Hit points ({1})", this.GetType().Name, this.HitPoints);
        }
    }
}
