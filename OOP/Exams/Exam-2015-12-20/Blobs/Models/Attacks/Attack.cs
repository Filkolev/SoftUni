namespace Blobs.Models.Attacks
{
    using System;

    using Contracts;

    public abstract class Attack : IAttack
    {
        private IBlob blob;

        protected Attack(IBlob blob)
        {
            this.Blob = blob;
        }

        protected IBlob Blob
        {
            get
            {
                return this.blob;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "A blob cannot be null when creating an attack.");
                }

                this.blob = value;
            }
        }

        public virtual int Damage => this.Blob.Damage;

        public virtual void ActivateEffects()
        {
        }
    }
}