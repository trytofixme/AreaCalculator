using AreaCalculator.Figures.Model;

namespace AreaCalculator.Figures
{
    public class FigureFactory : IFigureFactory
    {
        public IFigure CreateTriangle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentException("Sides should be grater then or equal 0");
            }

            if (a + b < c || a + c < b || b + c < a)
            {
                throw new ArgumentException("It is impossible to make a triangle from these sides");
            }

            return new Triangle(a, b, c);
        }

        public IFigure CreateCircle(double r)
        {
            if (r < 0)
            {
                throw new ArgumentException("Radius should be grater then or equal 0");
            }

            return new Circle(r);
        }
    }
}
