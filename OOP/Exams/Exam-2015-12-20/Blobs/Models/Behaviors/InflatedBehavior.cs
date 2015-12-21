namespace Blobs.Models.Behaviors
{
    using Contracts;

    public class InflatedBehavior : Behavior
    {
        private const int HealthIncreaseOnActivation = 50;
        private const int HealthDecreasePerTurn = 10;

        public InflatedBehavior(IBlob blob)
            : base(blob)
        {
        }

        public override void Activate()
        {
            base.Activate();

            this.Blob.Health += HealthIncreaseOnActivation;
        }

        public override void Update()
        {
            base.Update();

            if (this.TurnsActive > EffectDelayInTurns)
            {
                this.Blob.Health -= HealthDecreasePerTurn;
            }
        }
    }
}
