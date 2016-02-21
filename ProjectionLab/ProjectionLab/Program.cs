using System;
using System.Collections.Generic;

namespace ProjectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: This program will take in input of a flight path of a bee
    /// it will output the distance, heading, and pitch from the origin, and 
    /// output the distance heading and pitch to the top of the pole.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Temp value holders to create legs of the bee.
            float tempMagnitude;
            float tempHeading;
            float tempPitch;

            //Created a list to hold all our legs.
            List<Vector3D> legList = new List<Vector3D>();

            //Holds the vector for the utility pole.
            Vector3D utilityPole = new Vector3D();
            //Using a temp vector to do some math with.
            Vector3D beeFromOrigin = new Vector3D();
            //Get a point on the pole thinking of a line that goes from 0,0,0 to the pole vector (tip).
            Vector3D pointOnThePole = utilityPole & 0.5f;
            do
            {
                //Reset list of legs.
                legList = new List<Vector3D>();

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
                //Increment counter to limit the amount of legs.
                int legs = 0;
                do
                {
                    Console.Write("Please enter the distance of leg " + (legs + 1) + ": ");
                    tempMagnitude = (float)Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please enter the heading in degrees: ");
                    tempHeading = (float)Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please Enter the pitch in degrees: ");
                    tempPitch = (float)Convert.ToDouble(Console.ReadLine());

                    //Create a leg that will hold our current input.
                    Vector3D tempLeg = new Vector3D();
                    tempLeg.SetRectGivenMagHeadPitch(tempMagnitude, tempHeading, tempPitch);

                    
                    //Add the leg to the list of legs.
                    legList.Add(tempLeg);

                    //Reset bee from Origin
                    beeFromOrigin = new Vector3D();

                    //Add all the legs up in the list to get our current bee vector.
                    foreach(Vector3D leg in legList)
                    {
                        beeFromOrigin += leg;
                    }
                    //Print the mag, head, and pitch from the origin.
                    beeFromOrigin.PrintMagHeadPitch();

                    //Get the vector from the point on the pole
                    //Using S = P + Proj d PQ
                    Vector3D closestPoint = pointOnThePole + ((beeFromOrigin - pointOnThePole) ^ utilityPole);

                    //Report closest point on Utility Pole.
                    Console.Write("Closest Point:");
                    closestPoint.PrintRect();
                    Console.Write("\n");
                    //Go to the next leg.
                    legs++;
                } while (legs < 3);

                /*Report the distance and direction needed for the bee to fly
                directly from its final location to the top of the pole.*/
                Console.WriteLine("Distance and Direction needed to reach the top of the pole:");
                Vector3D vectorFromTopOfPole = (utilityPole - beeFromOrigin);
                vectorFromTopOfPole.PrintMagHeadPitch();

                //Reset Console for more vector fun.
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
    }
}
