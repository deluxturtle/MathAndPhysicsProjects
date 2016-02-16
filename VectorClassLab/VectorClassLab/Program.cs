using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorClassLab
{
    class Program
    {

        static void Main(string[] args)
        {


            do
            {
                //Choose your program
                Console.WriteLine("Choose your program. | 1 or 2 | / \"Exit\"");
                string input =Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Program1();
                        break;
                    case "2":
                        Console.Clear();
                        Program2();
                        break;
                    case "QUIT":
                    case "EXIT":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.Clear();

            } while (true);

        }


        //Vector with magnitude heading and pitch.
        static void Program2()
        {
            //Create vector
            Vector3D vector = new Vector3D();
            do
            {
                Console.WriteLine("~~~ Vector 3D Lab Part-2 ~~~ by: Andrew Seba");
                Console.WriteLine("MenuOptions, hit Enter, or \"Quit\"");
                string input = Console.ReadLine().ToUpper();
                Console.Clear();
                switch (input)
                {//Console.WriteLine();
                    case "":
                        Console.Write("Enter the vector's Magnitude:");
                        float tempMag = (float)Convert.ToDouble(Console.ReadLine());

                        Console.Write("\nEnter the vector's Heading:");
                        float tempHeading = (float)Convert.ToDouble(Console.ReadLine());
                        
                        Console.Write("\nEnter the vector's Pitch:");
                        try
                        {
                            float tempPitch = (float)Convert.ToDouble(Console.ReadLine());
                            vector.SetRectGivenMagHeadPitch(tempMag, tempHeading, tempPitch);

                        }
                        catch
                        {
                            vector.SetRectGivenPolar(tempMag, tempHeading);
                        }
                        break;
                    case "QUIT":
                    case "EXIT":
                        return;
                    default:
                        Console.Clear();
                        break;
                }
                Console.Clear();

                //Display output
                vector.PrintRect();
                vector.PrintMagHeadPitch();
                vector.PrintAngles();

                //Pause
                Console.WriteLine("Enter any key to continue.");
                Console.ReadKey();

                //restart
                Console.Clear();
            } while (true);

        }

        //Vector given rect.
        static void Program1()
        {
            float x = 0;
            float y = 0;
            float z = 0;
            //Create vector
            Vector3D vector = new Vector3D();
            do
            {
                Console.WriteLine("~~~ Vector 3D Lab Part-1 ~~~ by: Andrew Seba");
                Console.WriteLine("\n-3D or or 2D vector?");

                string input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "3D":
                        Console.WriteLine("Enter the vector in rectangular components.");
                        Console.WriteLine("Ex_ <x,y,x>");

                        //Get Input
                        Console.Write("x:");
                        x = (float)Convert.ToDouble(Console.ReadLine());
                        Console.Write("y:");
                        y = (float)Convert.ToDouble(Console.ReadLine());
                        Console.Write("z:");
                        z = (float)Convert.ToDouble(Console.ReadLine());

                        vector.SetRectGivenRect(x, y, z);

                        break;
                    case "2D":

                        //Get Input
                        Console.Write("x:");
                        x = (float)Convert.ToDouble(Console.ReadLine());
                        Console.Write("y:");
                        y = (float)Convert.ToDouble(Console.ReadLine());

                        vector.SetRectGivenRect(x, y);

                        break;
                    case "QUIT":
                    case "EXIT":
                        return;
                    default:
                        Console.Clear();
                        break;
                }

                //Display output
                vector.PrintRect();
                vector.PrintMagHeadPitch();
                vector.PrintAngles();

                //Pause
                Console.WriteLine("Enter any key to continue.");
                Console.ReadKey();

                //restart
                Console.Clear();
            } while (true);
        }
    }
}
