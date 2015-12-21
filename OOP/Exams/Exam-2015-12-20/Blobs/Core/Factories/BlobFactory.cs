namespace Blobs.Core.Factories
{
    using Contracts;
    using Models;

    public class BlobFactory : IBlobFactory
    {
        public IBlob CreateBlob(
            string name,
            int health,
            int damage,
            string attackType,
            string behaviourType,
            IAttackFactory attackFactory,
            IBehaviorFactory behaviorFactory)
        {
            var blob = new Blob(name, damage, health, attackType, behaviourType, attackFactory, behaviorFactory);

            return blob;
        }
    }
}
