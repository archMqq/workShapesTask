using FiguresLab;
namespace FiguresTester
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void checkCircleSquareWithTrue()
        {
            IFigure circle = FigureFabric.createCircle(10);

            float square = circle.getSquare();

            Assert.That(square, Is.EqualTo(10*10*Math.PI).Within(0.0001));
        }

        [Test]
        public void checkTriangleSquareWithTrue()
        {
            IFigure triangle = FigureFabric.createTriangle(new float[] {10 , 7, 5});

            float square = triangle.getSquare();

            Assert.That(square, Is.EqualTo((float)Math.Sqrt(11 * (11 - 10) * (11 - 7) * (11 - 5))).Within(0.0001));
        }

        [Test]
        public void checkTriangleSquareWithFalse()
        {            
            Triangle triangle = (Triangle)FigureFabric.createTriangle(3, 4, 5);

            bool isRectangle = triangle.isRectangle;

            Assert.IsTrue(isRectangle);
        }

    }
}