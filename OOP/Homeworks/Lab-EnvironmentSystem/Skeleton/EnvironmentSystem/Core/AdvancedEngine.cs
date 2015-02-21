namespace EnvironmentSystem.Core
{
    using System;

    public class AdvancedEngine : Engine
    {
        public AdvancedEngine()
            : base()
        {
        }

        protected override void Insert(Models.EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object cannot be null.");
            }

            base.Insert(obj);
        }
    }
}
