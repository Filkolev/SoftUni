namespace EnvironmentSystem.Interfaces
{
    using System.Collections.Generic;

    using EnvironmentSystem.Models;

    interface IObjectProducer
    {
        IEnumerable<EnvironmentObject> ProduceObjects();
    }
}
