using AreaCalculator.Figures;
using System.Collections;

namespace AreaCalculator.Tests;

[TestFixture]
public class CircleAreaTest
{
    private FigureFactory? _figureFactory;

    [SetUp]
    public void SetUp()
    {
        _figureFactory = new FigureFactory();
    }

    [TestCaseSource(typeof(CircleTestCases), nameof(CircleTestCases.CircleInvalidCases))]    
    public void CircleVidatationTest(double radius)
    {       
        Assert.That(() => _figureFactory!.CreateCircle(radius), Throws.TypeOf<ArgumentException>());
    }

    [TestCaseSource(typeof(CircleTestCases), nameof(CircleTestCases.CircleCases))]
    public double CircleAreaCalculatorTest(double radius)
    {
        var circle = _figureFactory!.CreateCircle(radius);
        return circle.GetArea();
    }
}

public class CircleTestCases
{
    public static IEnumerable CircleInvalidCases
    {
        get
        {
            yield return new TestCaseData(-1);
        }
    }

    public static IEnumerable CircleCases
    {
        get
        {
            yield return new TestCaseData(1).Returns(Math.PI);
        }
    }
}