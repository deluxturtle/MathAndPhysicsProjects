using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionDetectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Class object for Axially-Aligned Boxes
    /// </summary>
    class AABB
    {
        public Point minPoint;
        public Point maxPoint;

        public AABB(Point point1, Point point2)
        {
            minPoint = point1;
            maxPoint = point2;
        }
    }
}
