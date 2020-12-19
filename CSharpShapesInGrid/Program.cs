using System;

namespace CSharpShapesInGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shapes in a Grid");
            Console.WriteLine("Enter number of X points");
            var xEntry = Console.ReadLine();
            Console.WriteLine("Enter number of Y points");
            var yEntry = Console.ReadLine();

            var xPoints = int.Parse(xEntry);
            var yPoints = int.Parse(yEntry);
            var numberOfTringles = TringlesInGrid(xPoints, yPoints);

            Console.WriteLine($"Total Triangle = {numberOfTringles}");
            Console.ReadLine();
        }

        private static int TringlesInGrid(int xPoints, int yPoints)
        {
            var total = 0;
            var totalDots = xPoints * yPoints;
            for (var pointId1 = 0; pointId1 < totalDots; pointId1++)
            {
                for (var pointId2 = 0; pointId2 < totalDots; pointId2++)
                {
                    for (var pointId3 = 0; pointId3 < totalDots; pointId3++)
                    {
                        var pt1 = Get2DPointFromPointId(pointId1, xPoints);
                        var pt2 = Get2DPointFromPointId(pointId2, xPoints);
                        var pt3 = Get2DPointFromPointId(pointId3, xPoints);

                        if (AreOnSameLine(pt1, pt2, pt3))
                        {
                            continue;
                        }
                        
                        total++;
                    }
                }
            }

            return total / 6;
        }

        private static  Point Get2DPointFromPointId(int pointId, int xPoints)
        {
            return new Point
            {
                X = pointId / xPoints,
                Y = pointId % xPoints
            };
        }

        private static bool AreOnSameLine(Point point1, Point point2, Point currPoint)
        {
            if (AreEqual(point1, point2) || AreEqual(point1, currPoint) || AreEqual(point2, currPoint))
            {
                return true;
            }

            // https://stackoverflow.com/questions/11907947/how-to-check-if-a-point-lies-on-a-line-between-2-other-points

            var dxc = currPoint.X - point1.X;
            var dyc = currPoint.Y - point1.Y;

            var dxl = point2.X - point1.X;
            var dyl = point2.Y - point1.Y;

            return  (dxc * dyl - dyc * dxl) == 0;
        }

        public static bool AreEqual(Point point1, Point point2)
        {
            return (point1.X == point2.X && point1.Y == point2.Y);
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
