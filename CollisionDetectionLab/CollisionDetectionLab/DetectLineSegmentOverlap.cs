using System;

namespace CollisionDetectionLab
{
    class DetectLineSegmentOverlap
    {
        Point intersection;

        /// <summary>
        /// Main process of getting the two line segments from the user and
        /// checking to see if they overlap.
        /// </summary>
        public void Start()
        {
            do
            {
                Console.WriteLine("-Line Intersections-");
                LineSegment line1 = GetLineSegement("First Line");
                LineSegment line2 = GetLineSegement("Second Line");

                if(CheckForIntersection(line1, line2))
                {
                    Console.WriteLine("There is an Intersection at: " +
                        intersection);
                }

                Console.WriteLine("\nEnter to try again.");
                Console.ReadLine();
                Console.Clear();
            }
            while (true);
        }

        /// <summary>
        /// Checks for intersection between two lines Ax+By=C
        /// </summary>
        /// <returns></returns>
        bool CheckForIntersection(LineSegment pLine1, LineSegment pLine2)
        {
            float x;
            float y;

            if(pLine1 == pLine2)
            {
                Console.WriteLine("Same line infinitly many points.");
                return false;
            }


            Console.WriteLine("---Line-Equations---");
            /*
            (yone - ytwo)x + (-x + x2)y = xtwo*yone - one*ytwo
            Ax + By = C

            Grab the variables from the lines for the equation of line1.
            */
            float A = pLine1.point1.y - pLine1.point2.y;
            Console.Write("\n(" + A + ")x");
            float B = pLine1.point2.x - pLine1.point1.x;
            Console.Write(" + (" + B + ")y");
            float C = pLine1.point2.x * pLine1.point1.y - 
                pLine1.point1.x * pLine1.point2.y;
            Console.Write(" = " + C);

            /*
            (yone - ytwo)x + (-x + x2)y = xtwo*yone - one*ytwo
            Dx + Ey = F

            Grab the variables from the lines for the equation of line2.
            */
            float D = pLine2.point1.y - pLine2.point2.y;
            Console.Write("\n(" + D + ")x");
            float E = pLine2.point2.x - pLine2.point1.x;
            Console.Write(" + (" + E + ")y");
            float F = pLine2.point2.x * pLine2.point1.y -
                pLine2.point1.x * pLine2.point2.y;
            Console.WriteLine(" = " + F);


            /*
                CE - FB           AF - DC
            X = ---------     Y = -------
                AE - DB           AE - DB
            */

            float xTop = C * E - F * B;
            float yTop = A * F - D * C;

            //Check to see if the bottom AE-DB is 0 if so then no intersection.
            float bottom = A * E - D * B;
            
            Console.WriteLine("--------------------");


            
            if (bottom == 0)
            {

                /*
                if both the line 1 points.x are less than both line 2 points.x
                then its too far to intersect.
                */
                if(pLine1.point1.x < pLine2.point1.x &&
                    pLine1.point1.x < pLine2.point2.x &&
                    pLine1.point2.x < pLine2.point1.x &&
                    pLine1.point2.x < pLine2.point2.x)
                {
                    Console.WriteLine("Line1 is too far left from line2." +
                        "\nNo Intersection." );
                    return false;
                }
                if (pLine1.point1.x > pLine2.point1.x &&
                    pLine1.point1.x > pLine2.point2.x &&
                    pLine1.point2.x > pLine2.point1.x &&
                    pLine1.point2.x > pLine2.point2.x)
                {
                    Console.WriteLine("Line1 is too far right from line2." +
                        "\nNo Intersection.");
                    return false;
                }
                /*
                If both the line 1 y values are less than or greater than 
                line 2 y values then they are too far away to intersect.
                */
                if (pLine1.point1.y > pLine2.point1.y &&
                    pLine1.point1.y > pLine2.point2.y &&
                    pLine1.point2.y > pLine2.point1.y &&
                    pLine1.point2.y > pLine2.point2.y)
                {
                    Console.WriteLine("Line1 is too far above from line2." +
                        "\nNo Intersection.");
                    return false;
                }
                if (pLine1.point1.y < pLine2.point1.y &&
                    pLine1.point1.y < pLine2.point2.y &&
                    pLine1.point2.y < pLine2.point1.y &&
                    pLine1.point2.y < pLine2.point2.y)
                {
                    Console.WriteLine("Line1 is too far below from line2." +
                        "\nNo Intersection.");
                    return false;
                }

                //CHECK TO SEE IF the tops both == 0 then there are infinitly
                // many points and theres no point Intersection.
                else if (xTop == 0 && yTop == 0)
                {
                    Console.WriteLine("Infinitly many points!");
                    return false;
                }
            }
            else//then calculate bottom because its not 0
            {
                x = xTop / bottom;
                y = yTop / bottom;
                //save the aquired intersection point between the two Lines*
                intersection = new Point(x, y);


                //check to see if the intersection point lies between the line 
                //segment points.
                if (!CheckOnSegement(pLine1))
                {
                    Console.WriteLine("Intersection does not lie on line 1!");
                    return false;
                }
                else if (!CheckOnSegement(pLine2))
                {
                    Console.WriteLine("Intersection does not lie on line 2!");
                    return false;
                }
                //CHECK TO SEE IF the tops both == 0 then there are infinitly
                // many points and theres no point Intersection.
                else if(xTop == 0 && yTop == 0)
                {
                    Console.WriteLine("Infinitly many points!");
                    return false;
                }
            }

            /* Need to check for parrallel using Ax +By = C
                By = -Ax +C        Ey = -Dx + C
                y = (-A/B)x + C    y = (-D/E)x + C
                using their slope we can see if they are parallel.
            */
            if ((-A)/B == (-D) / E)
            {
                Console.WriteLine("Parallel lines. No Intersection.");
                return false;
            }

            //Finaly there must be an intersection!
            return true;

        }

        /// <summary>
        /// Checks if the intersection point lies between the line segment.
        /// returns false if one check fails. returns true if it is between
        /// both line segments.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        bool CheckOnSegement(LineSegment line)
        {
            //X checking
            //If the first point is on the left side of the right point.
            if (line.point1.x < line.point2.x)
            {
                //check to see if the intersection is in the line segement
                if (line.point1.x < intersection.x &&
                    intersection.x < line.point2.x)
                {
                    //Keep Going
                }
                else
                {
                    Console.WriteLine("Intersection doesn't lie on segment.");
                    return false;
                }
            }
            //if the second point is on the left side of the first point.
            else if (line.point2.x < line.point1.x)
            {
                //and check to see if the intersection in in the line segment.
                if (line.point2.x < intersection.x &&
                    intersection.x < line.point1.x)
                {
                    //Keep Going
                }
                else
                {
                    Console.WriteLine("Intersection doesn't lie on segment.");
                    return false;
                }
            }
            else if(line.point1.x == intersection.x &&
                line.point2.x == intersection.x)
            {
                //Keep going because the x is equal and the intersecion does
                //lie on the line!
            }
            else
            {
                Console.WriteLine("Intersection X is different than the" +
                    " vertical line X");
                return false;
            }

            //Y checking
            //If the first point is below the second point then.
            if(line.point1.y < line.point2.y)
            {
                //check to see if the intersection is in the line segment
                if(line.point1.y < intersection.y &&
                    intersection.y < line.point2.y)
                {
                    //Keep Going
                }
                else
                {
                    Console.WriteLine("Intersection doesn't lie on segment.");

                    return false;
                }
            }
            //If the second point is below the first point.
            else if (line.point2.y < line.point1.y)
            {
                //if the second point is below the first point.
                if (line.point2.y < intersection.y &&
                    intersection.y < line.point1.y)
                {
                    //Then both checks are good!
                }
                else
                {
                    Console.WriteLine("Intersection doesn't lie on segment.");
                    return false;
                }
            }
            //If the line is horizontal and the intersection is the same y
            else if(line.point1.y == intersection.y &&
                line.point2. y == intersection.y)
            {
                //Keep going because the y is equal and the intersection does
                //lie on the line!
            }
            else
            {
                Console.WriteLine("Intersection Y is different than the" +
                    " horizontal line Y");
                return false;
            }


            return true;
        }

        /// <summary>
        /// Gets the user input of the the two points of a line.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        LineSegment GetLineSegement(string pMessage)
        {
            Point point1 = GetPoint("Point One");
            Point point2 = GetPoint("Point Two");

            return new LineSegment(point1, point2);

        }

        /// <summary>
        /// Returns the point from input given.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <returns></returns>
        Point GetPoint(string pMessage)
        {
            float tempX = 0;
            float tempY = 0;

            try
            {
                Console.WriteLine("Please enter values for " + pMessage);
                Console.Write("X:");
                tempX = (float)Convert.ToDouble(Console.ReadLine());
                Console.Write("Y:");
                tempY = (float)Convert.ToDouble(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");
                GetPoint(pMessage);
            }

            return new Point(tempX, tempY);
        }
    }
}
