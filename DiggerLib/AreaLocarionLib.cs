using System;

namespace DiggerLib
{
    public class Point
    {
        public double X;
        public double Y;

        public static Vector operator !(Point pt)
        {
            return new Vector(pt);
        }
    }
    public class Vector
    {
        private static readonly Vector Ordinatus = new Vector(1,0); 
        public enum VectorType
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
        public double Angle(Vector right)
        {
            if (this.IsZero() && right.IsZero())
                return 0;
            double cos = (this.X * right.X + this.Y * right.Y) / (this.Length() * right.Length());
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
            if (IsZero())
            {
                X = 0;
                Y = 1;
                return;
            }
            double length = Length();
            X = Math.Round(X * 1 / length);
            Y = Math.Round(Y * 1 / length);
        }
        private void Set(Point location) => new Vector(location.X, location.Y);
        private bool Equals(Vector vector) => X == vector.X && Y == vector.Y;

        public override bool Equals(object obj)
        {
            if (obj is Vector v)
                return Equals(v);
            return base.Equals(obj);
        }
        public override int GetHashCode() 
            => Angle(Ordinatus).GetHashCode() * Length().GetHashCode();
        

        public bool IsZero() => Y == 0 && X == 0;
        public Vector(Point A) => Set(A);
        public static Vector operator !(Vector vec)
        // Возвращает нормаль вектора
        {
            double length = vec.Length();
            double x = vec.X;
            double y = vec.Y;
            if(length == 0)
            {
                length = 1;
            }
            x /= length;
            y /= length;
            return new Vector(x,y);
        }



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
        public static Vector operator& (Vector left, double right)
        {
            var vec = left.Angle(new Vector(VectorType.RIGHT));
            return new Vector(vec + right);
        }
        public static Vector operator& (double left, Vector right)
        {
            var vec = right.Angle(new Vector(VectorType.RIGHT));
            return new Vector(vec + left);
        }

        public static bool operator !=(Vector left, Vector right) => !left.Equals(right);
        public static bool operator ==(Vector left, Vector right) => left.Equals(right);

        public static bool operator !=(double left, Vector right) => left != right.Length();
        public static bool operator ==(double left, Vector right) => left  == right.Length();

        public Vector(VectorType type = VectorType.NULL, int minRandom = 0, int maxRandom = 2)
        {
            //Примеры   new Vector(vType.RANDOM); получение случайного вектора;
            //          new Vector(vType.NULL);  нулевого и т.д.
            switch (type)
            {
                case VectorType.DOWN:
                    X = 0;
                    Y = -1;
                    break;
                case VectorType.LEFT:
                    X = -1;
                    Y = 0;
                    break;
                case VectorType.RIGHT:
                    X = 1;
                    Y = 0;
                    break;
                case VectorType.UP:
                    X = 0;
                    Y = 1;
                    break;
                case VectorType.NULL: 
                    X = 0;
                    Y = 0;
                    break;
                case VectorType.RANDOM:
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
