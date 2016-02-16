using System;

namespace CollisionDetectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Main start of the 3 labs.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Can start the 3 different kinds of collision detection processes.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            do
            {
                Console.Write("-Detect Overlap Lab-" +
                    "\n1.) Spheres" +
                    "\n2.) Axially-Aligned Bounding Boxes" +
                    "\n3.) Line Segments" +
                    "\n\nSelect Wich detection process you would like to try:" +
                    "\n1-3 Restart the program to get back to the menu.");

                //Get the lab you want to try out.
                string answer = Console.ReadLine();
                int choice = Convert.ToInt16(answer);

                Console.Clear();
                switch (choice)
                {
                    //Sphere Lab
                    case 1:
                        DetectCircleOverlap detectCirlce =
                            new DetectCircleOverlap();
                        detectCirlce.Start();
                        break;
                    //AABB lab
                    case 2:
                        DetectAABBoverlap detectAABB =
                            new DetectAABBoverlap();
                        detectAABB.Start();
                        break;
                    //Line Segment
                    case 3:
                        DetectLineSegmentOverlap detectLine =
                            new DetectLineSegmentOverlap();
                        detectLine.Start();
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
            while (true);

        }


    }
}
