using System;
using System.Collections.Generic;

namespace ProjectionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            float tempMagnitude;
            float tempHeading;
            float tempPitch;
            //Holds the vector for the utility pole.
            Vector3D utilityPole = new Vector3D();
            //Holds the vector <0,0,0>
            Vector3D origin = new Vector3D();
            //Initialized the vectors we will use later.
            Vector3D legOne = new Vector3D();
            Vector3D legTwo = new Vector3D();
            Vector3D legThree = new Vector3D();
            //Using a temp vector to do some math with.
            Vector3D tempVector = new Vector3D();

            Console.WriteLine("_______________Projection Lab_______________");
            Console.WriteLine("Please Enter the angles of the Utility Pole:");
            Console.Write("Heading: ");

            //Get heading input for the utility pole.
            tempHeading = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("Pitch: ");
            //Get pitch input for the utility pole.
            tempPitch = (float)Convert.ToDouble(Console.ReadLine());

            //Create the utility pole vector.
            utilityPole.SetRectGivenMagHeadPitch(10.4f, tempHeading, tempPitch);

            //Start recieving input about legs.
            //Increment counter for how many legs we want.
            int legs = 0;
            do
            {
                Console.Write("Please enter the distance of leg " + (legs + 1) + ": ");
                tempMagnitude = (float)Convert.ToDouble(Console.ReadLine());
                Console.Write("Please enter the heading in degrees: ");
                tempHeading = (float)Convert.ToDouble(Console.ReadLine());
                Console.Write("Please Enter the pitch in degrees: ");
                tempPitch = (float)Convert.ToDouble(Console.ReadLine());

                //Depending on the leg counter depends on what leg we are setting.
                switch (legs)
                {
                    case 0:
                        legOne.SetRectGivenMagHeadPitch(tempMagnitude, tempHeading, tempPitch);
                        //Print the mag, head, and pitch from the origin.
                        legOne.PrintMagHeadPitch();
                        //Report closest point on Utility Pole.

                        break;
                    case 1:
                        legTwo.SetRectGivenMagHeadPitch(tempMagnitude, tempHeading, tempPitch);
                        tempVector.SetRectGivenMagHeadPitch(tempMagnitude, tempHeading, tempPitch);
                        tempVector += legOne;
                        //Print the mag, head, and pitch from the origin.
                        tempVector.PrintMagHeadPitch();
                        //Report the closest point on the Utility Pole.

                        break;
                    case 2:
                        legThree.SetRectGivenMagHeadPitch(tempMagnitude, tempHeading, tempPitch);
                        tempVector.SetRectGivenMagHeadPitch(tempMagnitude, tempHeading, tempPitch);
                        tempVector += legTwo + legOne;
                        //Print the mag, head, and pitch from the origin.
                        tempVector.PrintMagHeadPitch();
                        //Report the closest point on the Utility Pole.

                        break;
                }
                legs++;
            } while (legs < 3);

            Console.ReadKey();
        }
    }
}
