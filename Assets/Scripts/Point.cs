public struct Point
{
    public int x;
    public int y;
    private static int _upBorderCenter = 4;
    private static int _downBorderCenter = 5;
    private static int _leftBorderCenter = 4;
    private static int _rightBorderCenter = 5;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }


    public static void SetCenterBorders(int up, int down)
    {
        _upBorderCenter = up;
        _downBorderCenter = down;
        _leftBorderCenter = up;
        _rightBorderCenter = down;
}

    public int GetDistSquared(Point _p)
    {
        Point dist = new(x - _p.x, y - _p.y);
        return dist.x * dist.x + dist.y * dist.y;
    }

    public static bool IsPointInCenter(Point p)
    {
        return (p.x >= _leftBorderCenter && p.x <= _rightBorderCenter) &&
            (p.y >= _upBorderCenter && p.y <= _downBorderCenter);
    }

    public static Point operator -(Point a) => new Point(-a.x, -a.y);
    public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);
    public static Point operator -(Point a, Point b) => a + (-b);
    public static bool operator ==(Point a, Point b) => (a.x == b.x) && (a.y == b.y);
    public static bool operator !=(Point a, Point b) => !(a == b);
}


