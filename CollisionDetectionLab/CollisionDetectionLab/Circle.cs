using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionDetectionLab
{
    /// <summary>
    /// @Author:Andrew Seba
    /// @Description: Base Circle class that holds a center that's a point and a 
    /// radius variable.
    /// </summary>
    class Circle
    {
        public float radius;
        public Point center;

        public Circle(float pX, float pY, float pZ, float pRadius)
        {
            radius = pRadius;
            center = new Point(pX, pY, pZ);
        }
    }
}
