using System;
using System.Collections.Generic;

namespace ProjectionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projection Lab");
            Vector3D vector1 = new Vector3D();
            vector1.SetRectGivenRect(2, 2, 2);
            Vector3D vector2 = new Vector3D();
            vector2.SetRectGivenRect(3, 3, 3);

            Console.WriteLine("Add: " + (vector1 + vector2));
            Console.WriteLine("Subtract: " + (vector1 - vector2));
            Console.WriteLine("Subtract: " + (vector2 - vector1));
            Console.WriteLine();
        }
    }
}
