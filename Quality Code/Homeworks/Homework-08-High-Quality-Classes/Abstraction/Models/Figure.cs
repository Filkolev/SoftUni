namespace Abstraction.Models
{
    using Interfaces;

    public abstract class Figure : IPerimeterCalculatable, ISurfaceCalculatable
    {
        public abstract double CalcSurface();

        public abstract double CalcPerimeter();
    }
}
