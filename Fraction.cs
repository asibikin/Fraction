using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Fraction(int numerator = 0, int denominator = 1)
        {
            if (denominator == 0) throw new ArgumentException("Знаменатель не может быть равен 0!");
            Numerator = numerator;
            if (denominator > 0)
                Denominator = denominator;
            else
            {
                Numerator = -numerator;
                Denominator = -denominator;
            }

        }
        public Fraction(double d = 0)
        {
            if (d == 0)
            {
                Numerator = 0;
                Denominator = 1;
            }
            else
            {
                string strTemp = d.ToString();
                strTemp = strTemp.Substring(strTemp.IndexOf(",") + 1);
                int i = strTemp.Length;
                Numerator = (int)(d * Math.Pow(10, i));
                Denominator = (int)(Math.Pow(10, i));
            }
        }
        /// <summary>
        /// возвращает обратную дробь
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Fraction Invers(Fraction f) => (f.Numerator > 0) ? new Fraction(f.Denominator, f.Numerator) : new Fraction(-f.Denominator, -f.Numerator);
        /// <summary>
        /// возвращает сокращённую дробь
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static Fraction Reduce(Fraction f)
        {
            int a = Math.Abs(f.Numerator), b = f.Denominator, NOD = 1;
            while ((a != 0) && (b != 0))
            {
                if (a > b)
                    a %= b;
                else b %= a;
            }
            NOD = Math.Max(a, b);
            if (NOD == 0) NOD = 1;
            return new Fraction(f.Numerator / NOD, f.Denominator / NOD);
        }
        public void Print() => Console.WriteLine("{0}/{1}", Numerator, Denominator);
        public override string ToString()
        {
            if (Denominator == 1)
                return Numerator.ToString();
            else
                return Numerator.ToString() + "/" + Denominator.ToString();
        }
        public static implicit operator double(Fraction f) => (double)f.Numerator / (double)f.Denominator;
        public static implicit operator Fraction(double d) => Reduce(new Fraction(d));
        #region bool
        /// <summary>
        /// сравнение дробей дробь 1/2 не равна 2/4, для сравнения значений используйте метод Reduce()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            
            if (obj == null) return false;
            Fraction f = obj as Fraction;
            if (f == null) return false;
            return (this.Numerator == f.Numerator && this.Denominator == f.Denominator);
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Fraction f = obj as Fraction;
            if (f != null)
                return ((double)this).CompareTo((double)f);
            else
                throw new ArgumentException("Объект не является дробью!");
        }
        public override int GetHashCode()=> Numerator ^ Denominator;
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            if (ReferenceEquals(f1, f2)) return true;
            if ((object)f1 == null) return false;
            return f1.Equals(f2);
        }
        public static bool operator !=(Fraction f1, Fraction f2) => !(f1 == f2);
        public static bool operator true(Fraction f) => f.Numerator > 0 ? f.Numerator < f.Denominator : -f.Numerator < f.Denominator;
        public static bool operator false(Fraction f) => f.Numerator > 0 ? f.Numerator < f.Denominator : -f.Numerator < f.Denominator;
        public static bool operator <(Fraction f1, Fraction f2) => ((f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator) < 0);
        public static bool operator >(Fraction f1, Fraction f2) => (f2 < f1);
        public static bool operator <=(Fraction f1, Fraction f2) => ((f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator) <= 0);
        public static bool operator >=(Fraction f1, Fraction f2) => (f2 <= f1);
        #endregion
        #region +
        public static Fraction operator +(Fraction f1, Fraction f2) => Reduce(new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator));
        public static Fraction operator +(int a, Fraction f) => new Fraction(a, 1) + f;
        public static Fraction operator +(Fraction f, int a) => a + f;
        public static Fraction operator +(double d, Fraction f) => new Fraction(d) + f;
        public static Fraction operator +(Fraction f, double d) => d + f;
        #endregion
        #region -
        public static Fraction operator -(Fraction f) => new Fraction(-f.Numerator, f.Denominator);
        public static Fraction operator -(Fraction f1, Fraction f2) => f1 + (-f2);
        public static Fraction operator -(Fraction f, int a) => f + (-a);
        public static Fraction operator -(int a, Fraction f) => -f + a;
        #endregion
        #region *
        public static Fraction operator *(Fraction f1, Fraction f2) => Reduce(new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator));
        public static Fraction operator *(int a, Fraction f) => new Fraction(a) * f;
        public static Fraction operator *(Fraction f, int a) => new Fraction(a) * f;
        #endregion
        #region /
        public static Fraction operator /(Fraction f1, Fraction f2) => Fraction.Reduce(new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator));
        public static Fraction operator /(int a, Fraction f) => new Fraction(a, 1) / f;
        public static Fraction operator /(Fraction f, int a) => f / new Fraction(a, 1);
        #endregion
        public static Fraction operator ^(Fraction f, int Power) => new Fraction((int)Math.Pow(f.Numerator, Power), (int)Math.Pow(f.Denominator, Power));
    }
}
