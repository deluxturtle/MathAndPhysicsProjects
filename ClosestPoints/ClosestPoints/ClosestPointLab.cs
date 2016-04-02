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
            Console.WriteLine("Enter the Ship Vector.");
            ship = GetVectorRect();

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
            Console.WriteLine("Press Enter to start the Closest Point on Plane Lab.");
            //LineLab();
        }

        public void PlaneLab()
        {
            ship = GetVectorRect();

            //Ask for 3 points on the surface
            Console.WriteLine("Please enter 3 points on the surface.");
            Vector3D point1 = GetVectorRect();
            Vector3D point2 = GetVectorRect();
            Vector3D point3 = GetVectorRect();

            //Point1  is the starting point for both vectors
            Vector3D vector1_to_2 = point2 - point1;
            Vector3D vector1_to_3 = point3 - point1;
            Vector3D normal = vector1_to_2.Cross(vector1_to_3);

            Vector3D closestPoint = ship.ClosestPointPlane(normal, point1);


            Console.Write("Closest Point: ");
            closestPoint.PrintRect();

            Console.WriteLine("Distance: " + closestPoint.getMagnitude());
        }

        /// <summary>
        /// Asks the user for the rect coordinates for the ship.
        /// </summary>
        /// <returns></returns>
        Vector3D GetVectorRect()
        {
            Vector3D tempVector = new Vector3D();
            float x, y, z;

            Console.Write("-Vector Position: \nx: ");
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
