using System;

namespace DiggerLib
{
    public class Point
    {
        public double X;
        public double Y;
    }
    public class Vector
    {
         public enum vType
        {
            NULL,
            RANDOM,
            LEFT,
            RIGHT,
            UP,
            DOWN
        }
        public double Y { get; set; }
        public double X { get; set; }
        public double Length()
        {
            var result = this * this;
            var temp = Math.Sqrt(result.Y + result.X);
            return Math.Round(temp);
        }
        public double Angle(Vector left, Vector right)
        {
            double cos = (left.X * right.X + left.Y * right.Y) / (left.Length() * right.Length());
            return Math.Acos(cos);
        }
        public Vector ByAngle(double angle, double length = 1)
        {
            // Возвращает вектор длинной length с углом angle в радианах
            return new Vector()
            {
                X = Math.Cos(angle) * length,
                Y = Math.Sin(angle) * length
            };
        }
        public void Normalize()
        {
            // Нормализирует вектор
            double length = Length();
            X = Math.Round(X * 1 / length);
            Y = Math.Round(Y * 1 / length);
        }
        private void Set(Point location) => new Vector(location.X, location.Y);
        private bool Equals(Vector vector) => X == vector.X && Y == vector.Y;

        public bool IsNull() => Y == 0 && Y == 0;
        public Vector(Point A) => Set(A);
        public static Vector operator !(Vector left)
            // Возвращает нормаль вектора
            => new Vector
            {
                X = left.X * 1 / left.Length(),
                Y = left.Y * 1 / left.Length()
            };
        public static Vector operator+ (Vector left, Vector right)
            => new Vector
            {
                X = left.X + right.X,
                Y = left.Y + right.Y
            };
        public static Vector operator* (Vector left, Vector right)
            => new Vector
            {
                X = left.X * right.X,
                Y = left.Y * right.Y
            };
        public static Vector operator* (int left, Vector right)
            => new Vector
            {
                X = left * right.X,
                Y = left * right.Y
            };
        public static Vector operator* (Vector left, int right)
            => new Vector
            {
                X = left.X * right,
                Y = left.Y * right
            };
        public static Vector operator- (Vector left, Vector right)
            => new Vector
            {
                X = right.X - left.X,
                Y = right.Y - left.Y
            };

        public static bool operator !=(Vector left, Vector right) => !left.Equals(right);
        public static bool operator ==(Vector left, Vector right) => left.Equals(right);

        public static bool operator !=(double left, Vector right) => left != right.Length();
        public static bool operator ==(double left, Vector right) => left  == right.Length();

        public Vector(vType type = vType.NULL, int minRandom = 0, int maxRandom = 2)
        {
            //Примеры   new Vector3(vType.RANDOM); получение случайного вектора;
            //          new Vector3(vType.NULL);  нулевого и т.д.
            switch (type)
            {
                case vType.DOWN:
                    X = 0;
                    Y = -1;
                    break;
                case vType.LEFT:
                    X = -1;
                    Y = 0;
                    break;
                case vType.RIGHT:
                    X = 1;
                    Y = 0;
                    break;
                case vType.UP:
                    X = 0;
                    Y = 1;
                    break;
                case vType.NULL: 
                    X = 0;
                    Y = 0;
                    break;
                case vType.RANDOM:
                    Random r = new Random();
                    X = r.Next(minRandom, maxRandom) * 2 - 1;
                    Y = r.Next(minRandom, maxRandom) * 2 - 1; 
                    break;
            }
        }
        public Vector (double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vector(double angle)
        {
            var temp = ByAngle(angle);
            X = temp.X;
            Y = temp.Y;
        }
    }
}
