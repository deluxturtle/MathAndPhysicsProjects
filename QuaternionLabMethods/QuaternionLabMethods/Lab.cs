using System;
using QuaternionLab;
using VectorClassLab;

namespace QuaternionLabMethods
{
    class Lab
    {
        public void Start()
        {

            //Create The Point
            Quaternion p = new Quaternion(1, new Vector3D(0,2,-3));
            Quaternion q = new Quaternion(2, new Vector3D(4, -1, 1));
            Console.WriteLine("{0,-20} {1,30}", "p:",p);
            Console.WriteLine("{0,-20} {1,30}", "q:", q);

            Console.WriteLine("\nAddition & Subtraction");
            Console.WriteLine("{0,-20} {1,30}","p + q",(p + q));
            Console.WriteLine("{0,-20} {1,30}", "p - q", (p - q));

            Console.WriteLine("\nScalar:");
            Console.WriteLine("{0,-20} {1,30}", "2 * p:", 2 & p);
            Console.WriteLine("{0,-20} {1,30}", "2 * q:", 2 & q);

            Console.WriteLine("\nProduct:");
            Console.WriteLine("{0,-20} {1,30}", "p * q", p * q);

            Console.WriteLine("\nMagnitudes:");
            Console.WriteLine("{0,-20} {1,30}", "|p|", p.getMagnitude());
            Console.WriteLine("{0,-20} {1,30}", "|q|", q.getMagnitude());

            Console.WriteLine("\nConjugate:");
            Console.WriteLine("{0,-20} {1,30}", "p*", p.getConjugate());
            Console.WriteLine("{0,-20} {1,30}", "q*", q.getConjugate());

            Console.WriteLine("\nInverse:");
            Console.WriteLine("{0,-20} {1,30}", "p^-1", p.getInverse());
            Console.WriteLine("{0,-20} {1,30}", "q^-1", q.getInverse());

            Console.ReadKey();
        }
    }
}
