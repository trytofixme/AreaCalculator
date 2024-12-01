using AreaCalculator.Figures.Model;

namespace AreaCalculator.Figures
{
    public interface IFigureFactory
    {
        IFigure CreateTriangle(double a, double b, double c);
        IFigure CreateCircle(double r);
    }
}
