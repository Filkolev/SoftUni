namespace Blobs.Models.Behaviors
{
    using System;

    using Contracts;

    public abstract class Behavior : IBehavior
    {
        protected const int EffectDelayInTurns = 1;

        private IBlob blob;

        protected Behavior(IBlob blob)
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
                    throw new ArgumentNullException(nameof(value), "The behavior's blob cannot be null.");
                }

                this.blob = value;
            }
        }

        protected bool IsActive { get; private set; } = false;

        protected int TurnsActive { get; set; } = 0;

        public virtual void Activate()
        {
            if (this.IsActive)
            {
                throw new InvalidOperationException("The behavior has already been activated.");
            }

            this.IsActive = true;
        }

        public virtual void Update()
        {
            if (this.IsActive)
            {
                this.TurnsActive++;
            }
        }
    }
}
