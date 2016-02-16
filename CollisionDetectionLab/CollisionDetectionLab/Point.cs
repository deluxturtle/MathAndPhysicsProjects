using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionDetectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Base class to hold x,y,z variables.
    /// </summary>
    class Point
    {
        public float x;
        public float y;
        public float z;

        //3D
        public Point(float pX, float pY, float pZ)
        {
            x = pX;
            y = pY;
            z = pZ;
        }

        //2D
        public Point(float pX, float pY)
        {
            x = pX;
            y = pY;
            z = 0;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }

        public static bool operator ==(Point p1, Point p2)
        {
            if(p1.x == p2.x && p1.y == p2.y && p1.z == p2.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Point p1, Point p2)
        {
            if(p1.x != p2.x || p1.y != p2.y || p1.z != p2.z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
