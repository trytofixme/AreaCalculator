namespace AreaCalculator.Figures.Model
{
    public class Triangle(double a, double b, double c) : IFigure
    {
        private double SideA { get; } = a;
        private double SideB { get; } = b;
        private double SideC { get; } = c;

        public double GetArea()
        {
            var p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public bool IsTriangleRectangular() =>        
            Math.Abs(SideA * SideA - SideC * SideC - SideB * SideB) < AreaHelpers.Precision 
            || Math.Abs(SideB * SideB - SideC * SideC - SideA * SideA) < AreaHelpers.Precision 
            || Math.Abs(SideC * SideC - SideA * SideA - SideB * SideB) < AreaHelpers.Precision;
    }
}
