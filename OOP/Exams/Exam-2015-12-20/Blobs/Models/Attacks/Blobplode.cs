namespace Blobs.Models.Attacks
{
    using Contracts;

    public class Blobplode : Attack
    {
        public Blobplode(IBlob blob)
            : base(blob)
        {
        }

        public override int Damage => this.Blob.Damage * 2;

        public override void ActivateEffects()
        {
            base.ActivateEffects();
            this.Blob.Health -= this.Blob.Health / 2;
        }
    }
}
