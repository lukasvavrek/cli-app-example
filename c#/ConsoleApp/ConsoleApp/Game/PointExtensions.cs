namespace ConsoleApp.Game;

public static class PointExtensions
{
    public static bool SameAs(this Point point, Point p2) => point.X == p2.X && point.Y == p2.Y;

    public static double DistanceFrom(this Point p1, Point p2)
    {
        // sqrt (x2-x1)^2 + (y2-y1)^2
        var x = Math.Pow(p2.X - p1.X, 2);
        var y = Math.Pow(p2.Y - p1.Y, 2);

        return Math.Sqrt(x + y);
    }

    public static Point GoTo(this Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(point.X, point.Y + 1),
            Direction.Down => new Point(point.X, point.Y - 1),
            Direction.Left => new Point(point.X - 1, point.Y),
            Direction.Right => new Point(point.X + 1, point.Y),
            _ => throw new NotImplementedException("Invalid direction.")
        };
    }
}