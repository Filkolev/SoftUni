namespace Blobs
{
    using Contracts;
    using Core;
    using Core.Factories;
    using UI;

    public class BlobsApplication
    {
        public static void Main(string[] args)
        {
            IBlobFactory blobFactory = new BlobFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IBehaviorFactory behaviorFactory = new BehaviorFactory();
            IInputReader reader = new ConsoleReader();
            IOutputWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(blobFactory, attackFactory, behaviorFactory, reader, writer);
            engine.Run();
        }
    }
}
