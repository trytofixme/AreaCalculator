using AreaCalculator.Figures;
using System.Collections;
using AreaCalculator.Figures.Model;

namespace AreaCalculator.Tests;

[TestFixture]
public class TriangleAreaTest
{
    private FigureFactory? _figureFactory;

    [SetUp]
    public void SetUp()
    {
        _figureFactory = new FigureFactory();
    }

    [TestCaseSource(typeof(TriangleTestCases), nameof(TriangleTestCases.TriangleInvalidCases))]
    public void TriangleVidatationTest(double sideA, double sideB, double sideC)
    {
        Assert.That(() => _figureFactory!.CreateTriangle(sideA, sideB, sideC), Throws.TypeOf<ArgumentException>());
    }

    [TestCaseSource(typeof(TriangleTestCases), nameof(TriangleTestCases.TriangleCases))]
    public double TriangleAreaCalculatorTest(double sideA, double sideB, double sideC)
    {
        var triangle = _figureFactory!.CreateTriangle(sideA, sideB, sideC);
        return triangle.GetArea();
    }

    [TestCaseSource(typeof(TriangleTestCases), nameof(TriangleTestCases.RectangularTriangleCases))]
    public bool RectangularTriangleTest(double sideA, double sideB, double sideC)
    {
        var triangle = _figureFactory!.CreateTriangle(sideA, sideB, sideC) as Triangle;
        return triangle!.IsTriangleRectangular();
    }

    public class TriangleTestCases
    {
        public static IEnumerable TriangleInvalidCases
        {
            get
            {
                yield return new TestCaseData(-1, 2, 3);
                yield return new TestCaseData(1, -2, 3);
                yield return new TestCaseData(1, 2, -3);
                yield return new TestCaseData(5, 1, 1);
                yield return new TestCaseData(1, 2, 4);
            }
        }

        public static IEnumerable TriangleCases
        {
            get
            {
                yield return new TestCaseData(5, 3, 4).Returns(6);
                yield return new TestCaseData(13, 13, 10).Returns(60);
            }
        }

        public static IEnumerable RectangularTriangleCases
        {
            get
            {
                yield return new TestCaseData(3, 4, 5).Returns(true);
                yield return new TestCaseData(13, 13, 10).Returns(false);
            }
        }
    }
}