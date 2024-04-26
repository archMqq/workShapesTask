namespace ShapeOperator
{
    public interface IFigure
    {
        float getSquare();
    }

    public abstract class Figure
    {
        private float _square;
    }

    public class Circle : Figure, IFigure
    {
        private float _radius;
        private float _square;
        private const float PI = 3.1415926535F;

        public Circle()
        {

        }
        public Circle(float radius)
        {
            Radius = radius;
        }

        public float Radius
        {
            private get { return _radius; }
            set { _radius = value > 0 ? value : 0; }
        }

        public float getSquare()
        {
            if (_square == 0)
                _square = _radius * _radius * PI;
            return _square;
        }
    }

    public class Triangle : Figure, IFigure
    {
        private float[] _sides;
        private float _square;
        private bool _isRectangle;

        public Triangle()
        {

        }

        public Triangle(float[] sides)
        {
            Sides = sides;
            setIsRectangle();
        }

        public Triangle(float firstSide, float secondSide, float thirdSide)
        {
            _sides = new float[] { firstSide, secondSide, thirdSide};
            setIsRectangle();
        }

        public bool isRectangle
        {
            get { return _isRectangle; }
            private set { _isRectangle = value; }
        }

        public float[] Sides
        {
            private get { return _sides; }
            set
            {
                if (value.Length != 3)
                {
                    _sides = value;
                    if (_sides != null)
                        foreach (var side in _sides)
                            if (side <= 0)
                                throw new ArgumentException("Значение каждой стороны должно быть больше 0.");
                }
                else
                    throw new ArgumentException("Количество сторон должно быть трем.");
            }
        }

        public float getSquare()
        {
            if (_square == 0)
            {
                float p = (_sides[0] + _sides[1] + _sides[2]) / 2;
                _square = (float)Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2]));
            }                
            return _square;
        }

        private void setIsRectangle()
        {
            Array.Sort(_sides);

            float aSquared = _sides[0] * _sides[0];
            float bSquared = _sides[1] * _sides[1];
            float cSquared = _sides[2] * _sides[2];

            isRectangle =  aSquared + bSquared == cSquared;
        }
    }
}
