using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Fraction
{
    //          + - * / > < == != true false
    class Program
    {
        static void Main(string[] args)
        {
            int a, a1, b;
            a1 = 3; b = -4;
            Fraction f = new Fraction(a1, b);
            f.Print();
            Console.WriteLine("1. f= {0}", f);
            Console.WriteLine("2. Invers(f)= {0}", Fraction.Invers(f));
            Console.WriteLine("3. f+= {0}, Reduction(f+f) = {1}", f + f, Fraction.Reduce(f + f));
            Console.WriteLine("4. f-= {0}", f - f);
            Console.WriteLine("5. f*= {0}", f * f);
            Console.WriteLine("6. f/= {0}", f / f);
            a = 10;
            Fraction f1 = f * a;
            Console.WriteLine("7. f1 = f * 10 = {0}", f1);
            Fraction f2 = a * f;
            Console.WriteLine("8. f2 = 10 * f = {0}", f2);
            if (f) Console.WriteLine("9. f = {0} правильная дробь", f);
            else Console.WriteLine("10. f = {0} неправильная дробь", f);

            if (f1) Console.WriteLine("11. f1 = {0} правильная дробь", f1);
            else Console.WriteLine("12. f1 = {0} неправильная дробь", f1);
            double d = 1.5;
            Fraction f3 = f + d;
            Console.WriteLine("13. f3 = {0} + {1} = {2}", f, d, f3);
            Console.WriteLine("14. f3 = {0}", (double)f3);
            f = 1.5; f1 = new Fraction(6, 4);
            Console.WriteLine("15. f = {0}, f1 = {1}", f, f1);
            Console.WriteLine("16. f({0}) <= f1({1}) - {2}", f, f1, f <= f1);
            Console.WriteLine("17. f({0}) = f1({1}) - {2}", f, f1, f == 1);
            Console.WriteLine("18. f({0}).Equals(f1({1})) = {2}", f, f1, f.Equals(f1));
            Console.WriteLine("19. значения f({0}) и f1({1}) равны? - {2}", f, f1, Fraction.Reduce(f) == Fraction.Reduce(f1));
            Console.WriteLine("20. f({0}).CompareTo(f1({1})) = {2}", f, f1, f1.CompareTo(f));
            int n = 2;
            Console.WriteLine("21. f({0})^{1} = {2}", f, n, f^n);
            Console.ReadKey();          
        }
    }
}
