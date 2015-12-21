namespace Blobs.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class AttackFactory : IAttackFactory
    {
        public IAttack CreateAttack(string attackType, IBlob blob)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == attackType);

            if (type == null)
            {
                throw new ArgumentException("Unknown attack type.");
            }

            var attack = (IAttack)Activator.CreateInstance(type, blob);

            return attack;
        }
    }
}
