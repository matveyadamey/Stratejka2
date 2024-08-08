public struct Point
{
    public int x;
    public int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }


    public int GetDistSquared(Point _p)
    {
        Point dist = new(x - _p.x, y - _p.y);
        return dist.x * dist.x + dist.y * dist.y;
    }

    public static Point operator -(Point a) => new Point(-a.x, -a.y);
    public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);
    public static Point operator -(Point a, Point b) => a + (-b);
    public static bool operator ==(Point a, Point b) => (a.x == b.x) && (a.y == b.y);
    public static bool operator !=(Point a, Point b) => !(a==b);
}


