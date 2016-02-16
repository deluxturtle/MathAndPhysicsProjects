
namespace CollisionDetectionLab
{
    /// <summary>
    /// @Author: Andrew Seba
    /// @Description: Base class for line segment. allows == operator
    ///  to compare lines.
    /// </summary>
    class LineSegment
    {
        public Point point1;
        public Point point2;

        public LineSegment(Point pPoint1, Point pPoint2)
        {
            point1 = pPoint1;
            point2 = pPoint2;


        }

        public static bool operator ==(LineSegment l1, LineSegment l2)
        {
            if(l1.point1 == l2.point1 && l1.point2 == l2.point2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(LineSegment l1, LineSegment l2)
        {
            if(l1.point1 != l2.point1 || l1.point2 != l2.point2)
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
