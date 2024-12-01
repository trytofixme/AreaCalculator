namespace AreaCalculator.Figures.Model
{
    internal class Circle(double radius) : IFigure
    {
        private double Radius { get; } = radius;

        public double GetArea()
        {
            return Radius * Radius * Math.PI;
        }
    }
}
