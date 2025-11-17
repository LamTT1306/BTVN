using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_T1
{
    internal class Program1
    {
        public class PhuongTrinhBacNhat
        {
            protected double B;
            protected double C;

            public PhuongTrinhBacNhat(double b, double c)
            {
                B = b;
                C = c;
            }

            public virtual string GiaiPhuongTrinh()
            {
                if (B == 0)
                {
                    if (C == 0)
                    {
                        return "Phuong trinh vo so nghiem.";
                    }
                    else
                    {
                        return "Phuong trinh vo nghiem.";
                    }
                }
                else
                {
                    double x = -C / B;
                    return "Phuong trinh co nghiem x = " + x;
                }
            }
        }

        public class PhuongTrinhBacHai : PhuongTrinhBacNhat
        {
            private double A;
            public PhuongTrinhBacHai(double a, double b, double c) : base(b, c)
            {
                A = a;
            }
            public override string GiaiPhuongTrinh()
            {
                if (A == 0)
                {
                    return base.GiaiPhuongTrinh();
                }
                else
                {
                    double delta = Math.Pow(B, 2) - 4 * A * C;
                    if (delta < 0)
                    {
                        return "Phuong trinh vo nghiem.";
                    }
                    else if (delta == 0)
                    {
                        double x = -B / (2 * A);
                        return "Phuong trinh co nghiem kep x = " + x;
                    }
                    else
                    {
                        double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                        double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                        return "Phuong trinh co hai nghiem phan biet: x1 = " + x1 + ", x2 = " + x2;
                    }
                }
            }
        }

        public 
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Giai phuong trinh bac hai ax^2 + bx + c = 0");
            PhuongTrinhBacHai pt1 = new PhuongTrinhBacHai(1, -5, 6);
            Console.WriteLine("Phuong trinh: 1x^2 - 5x + 6 = 0");
            Console.WriteLine(pt1.GiaiPhuongTrinh());

            PhuongTrinhBacHai pt2 = new PhuongTrinhBacHai(0, 2, -4);
            Console.WriteLine("Phuong trinh: 0x^2 + 2x - 4 = 0");
            Console.WriteLine(pt2.GiaiPhuongTrinh());

            PhuongTrinhBacHai pt3 = new PhuongTrinhBacHai(1, 1, 1);
            Console.WriteLine("Phuong trinh: 1x^2 + 1x + 1 = 0");
            Console.WriteLine(pt3.GiaiPhuongTrinh());
        }
    }
}
