using System;

namespace CollisionDetectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description:This class has functions to detect overlaps on 
    /// Axially-Aligned Boxes in 2D and 3D
    /// </summary>
    class DetectAABBoverlap
    {
        bool ThreeD = false;

        public void Start()
        {
            do
            {
                //Ask if its 3D
                Console.WriteLine("3D? y/n");
                //Get Input for question.
                string input = Console.ReadLine().ToLower();

                do
                {
                    switch (input)
                    {
                        case "y":
                        case "yes":
                            ThreeD = true;
                            break;
                        case "n":
                        case "no":
                            ThreeD = false;
                            break;
                        case "exit":
                        case "quit":
                            return;
                        default:
                            break;
                    }
                }
                while (input != "y" &&
                    input != "yes" &&
                    input != "n" &&
                    input != "no");


                AABB box1 = GetAABB("Box1");
                AABB box2 = GetAABB("Box2");

                if (OverlapCheck(box1, box2))
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
        /// Checks to see if the two boxes are overlapping.
        /// </summary>
        /// <param name="pBox1"></param>
        /// <param name="pBox2"></param>
        /// <returns></returns>
        bool OverlapCheck(AABB pBox1, AABB pBox2)
        {

            //Check the x distance between boxes using the x centers.
            Point box1CenterX =
                new Point(pBox1.minPoint.x + pBox1.maxPoint.x * 0.5f, 0);
            Point box2CenterX =
                new Point(pBox2.minPoint.x + pBox2.maxPoint.x * 0.5f, 0);

            float box1RadiusX = DetectCircleOverlap.PointDistance(
                new Point(pBox1.minPoint.x, 0),
                new Point(pBox1.maxPoint.x, 0)) * 0.5f;
            float box2RadiusX = DetectCircleOverlap.PointDistance(
                new Point(pBox2.minPoint.x, 0),
                new Point(pBox2.maxPoint.x, 0)) * 0.5f;

            float distanceX = DetectCircleOverlap.PointDistance(box1CenterX,
                box2CenterX);

            if ((box1RadiusX + box2RadiusX) < distanceX)
            {
                Console.WriteLine("No overlap in the X axis.");
                return false;
            }

            //Check for Y Overlap
            Point box1CenterY =
                new Point(pBox1.minPoint.y + pBox1.maxPoint.y * 0.5f, 0);
            Point box2CenterY =
                new Point(pBox2.minPoint.y + pBox2.maxPoint.y * 0.5f, 0);

            float box1RadiusY = DetectCircleOverlap.PointDistance(
                new Point(0, pBox1.minPoint.y),
                new Point(0, pBox1.maxPoint.y)) * 0.5f;
            float box2RadiusY = DetectCircleOverlap.PointDistance(
                new Point(0, pBox2.minPoint.y),
                new Point(0, pBox2.maxPoint.y)) * 0.5f;

            float distanceY = DetectCircleOverlap.PointDistance(box1CenterY,
                box2CenterY);

            if ((box1RadiusY + box2RadiusY) < distanceY)
            {
                Console.WriteLine("No overlap in the Y axis.");
                return false;
            }

            if (ThreeD)
            {
                //Check for Z Overlap
                Point box1CenterZ =
                    new Point(pBox1.minPoint.z + pBox1.maxPoint.z * 0.5f, 0);
                Point box2CenterZ =
                    new Point(pBox2.minPoint.z + pBox2.maxPoint.z * 0.5f, 0);

                float box1RadiusZ = DetectCircleOverlap.PointDistance(
                    new Point(0, 0, pBox1.minPoint.z),
                    new Point(0, 0, pBox1.maxPoint.z)) * 0.5f;
                float box2RadiusZ = DetectCircleOverlap.PointDistance(
                    new Point(0, 0, pBox2.minPoint.z),
                    new Point(0, 0, pBox2.maxPoint.z)) * 0.5f;

                float distanceZ = DetectCircleOverlap.PointDistance(box1CenterZ,
                    box2CenterZ);

                if((box1RadiusZ + box2RadiusZ) < distanceZ)
                {
                    Console.WriteLine("No overlap in the Z axis.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Starts the process of getting input to create the AABB.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        public AABB GetAABB(string pMessage)
        {
            Point tempMin;
            Point tempMax;
            Console.WriteLine(
                "Please provide the first Point of the " + pMessage);

            tempMin = GetPoint(pMessage + " Point One");
            tempMax = GetPoint(pMessage + " Point Two");

            AABB tempBox = new AABB(tempMin, tempMax);
            return tempBox;
        }

        /// <summary>
        /// Returns the point from input given. Assigns Z to 0 if not 3D.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        public Point GetPoint(string pMessage)
        {
            float tempX = 0;
            float tempY = 0;
            float tempZ = 0;

            try
            {
                Console.WriteLine("Please enter values for " + pMessage);
                Console.Write("X:");
                tempX = (float)Convert.ToDouble(Console.ReadLine());
                Console.Write("Y:");
                tempY = (float)Convert.ToDouble(Console.ReadLine());
                if (ThreeD)
                {
                    Console.Write("Z:");
                    tempZ = (float)Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    tempZ = 0;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");
                GetPoint(pMessage);
            }

            return new Point(tempX, tempY, tempZ);
        }
    }
}
