namespace Blobs.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class BehaviorFactory : IBehaviorFactory
    {
        public IBehavior CreateBehavior(string behaviorType, IBlob blob)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == behaviorType);

            if (type == null)
            {
                throw new ArgumentException("Unknown behavior type.");
            }

            var behavior = (IBehavior)Activator.CreateInstance(type, blob);

            return behavior;
        }
    }
}
