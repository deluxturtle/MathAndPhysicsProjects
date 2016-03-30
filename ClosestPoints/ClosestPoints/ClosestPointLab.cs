using System;
using VectorClassLab;

namespace ClosestPoints
{
    class ClosestPointLab
    {
        Vector3D ship = new Vector3D();
        Vector3D movingObject = new Vector3D();
        Vector3D direction = new Vector3D();

        public void LineLab()
        {

            float x, y, z;
            float heading, pitch;

            //Get the Ships position.
            ship = GetShipPosition();

            //Get the moving object position.
            Console.Clear();
            Console.Write("Moving Obj Position: \nx: ");
            x = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("y: ");
            y = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("z: ");
            z = (float)Convert.ToDouble(Console.ReadLine());
            movingObject.SetRectGivenRect(x, y, z);

            //Get the direction vector of the moving object.
            Console.Clear();
            Console.Write("Direction of Moving Object: \nHeading: ");
            heading = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("Pitch: ");
            pitch = (float)Convert.ToDouble(Console.ReadLine());
            direction.SetRectGivenMagHeadPitch(1, heading, pitch);

            //Get the closest point to the path of the moving object.
            Vector3D closestPoint = ship.ClosestPointLine(movingObject, direction);

            //print the closest point.
            Console.Write("Closest Point: ");
            closestPoint.PrintRect();

            //print the distance.
            Console.WriteLine("Distance: " + closestPoint.getMagnitude());

            //Restart Lab.
            Console.WriteLine("Enter to do the Closest Point on Plane.");
            Console.ReadKey();
            Console.Clear();
            //LineLab();
        }

        public void PlaneLab()
        {
            ship = GetShipPosition();

        }

        /// <summary>
        /// Asks the user for the rect coordinates for the ship.
        /// </summary>
        /// <returns></returns>
        Vector3D GetShipPosition()
        {
            Vector3D tempVector = new Vector3D();
            float x, y, z;

            Console.Write("Ship Position: \nx: ");
            x = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("y: ");
            y = (float)Convert.ToDouble(Console.ReadLine());
            Console.Write("z: ");
            z = (float)Convert.ToDouble(Console.ReadLine());

            tempVector.SetRectGivenRect(x, y, z);
            return tempVector;
        }

        
    }
}
