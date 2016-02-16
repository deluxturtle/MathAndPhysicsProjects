using System;

namespace CollisionDetectionLab
{
    class DetectCircleOverlap
    {

        /// <summary>
        /// Main process of getting the two circles from the user and then
        /// checking if they overlap.
        /// </summary>
        public void Start()
        {
            do
            {
                Circle circle1 = GetCircle("First Circle");
                Circle circle2 = GetCircle("Second Circle");

                if (OverlapCheck(circle1, circle2))
                {
                    Console.WriteLine("There is an overlap!");
                }
                else
                {
                    Console.WriteLine("There is no overlap!");
                }

                Console.WriteLine("\nEnter to try again.");
                Console.ReadLine();
                Console.Clear();

            }
            while (true);
        }

        /// <summary>
        /// Gets the user input of the center of the circle X,Y,Z then the 
        /// radius then returns the circle object.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        public Circle GetCircle(string pMessage)
        {
            float tempX = 0;
            float tempY = 0;
            float tempZ = 0;
            float radius = 1;
            Console.WriteLine("Please provide the center of the " + pMessage);

            //Get input for the first circle variables.
            try
            {
                Console.Write("X:");
                tempX = (float)Convert.ToDouble(Console.ReadLine());
                Console.Write("Y:");
                tempY = (float)Convert.ToDouble(Console.ReadLine());
                Console.Write("Z:");
                tempZ = (float)Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please provide the radius of the " +
                    pMessage);
                radius = (float)Convert.ToDouble(Console.ReadLine());
                while (radius <= 0)
                {
                    Console.WriteLine("Please enter a value greater than 0.");
                    radius = (float)Convert.ToDouble(Console.ReadLine());
                }

            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");
                GetCircle(pMessage);
            }

            Circle tempCircle = new Circle(tempX, tempY, tempZ, radius);
            return tempCircle;
        }


        /// <summary>
        /// Returns true if circles overlap.
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        bool OverlapCheck(Circle c1, Circle c2)
        {
            float distance = PointDistance(c1.center, c2.center);

            if ((c1.radius + c2.radius) >= distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a float of the distance between 2 points.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static float PointDistance(Point p1, Point p2)
        {
            float distanceX = p2.x - p1.x;
            float distanceY = p2.y - p1.y;
            float distanceZ = p2.z - p1.z;

            float distance = (float)Math.Sqrt(
                distanceX * distanceX +
                distanceY * distanceY +
                distanceZ * distanceZ);

            return distance;
        }

    }
}
