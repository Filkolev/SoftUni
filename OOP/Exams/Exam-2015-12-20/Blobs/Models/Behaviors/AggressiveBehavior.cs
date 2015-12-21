namespace Blobs.Models.Behaviors
{
    using Contracts;

    public class AggressiveBehavior : Behavior
    {
        private const int DamageDecreasePerTurn = 5;

        private int initialBlobDamage;

        public AggressiveBehavior(IBlob blob) 
            : base(blob)
        {
        }

        public override void Activate()
        {
            base.Activate();

            this.initialBlobDamage = this.Blob.Damage;
            this.Blob.Damage *= 2;
        }

        public override void Update()
        {
            base.Update();

            if (this.Blob.Damage - DamageDecreasePerTurn >= this.initialBlobDamage 
                && this.TurnsActive > EffectDelayInTurns)
            {
                this.Blob.Damage -= DamageDecreasePerTurn;
            }
        }
    }
}
