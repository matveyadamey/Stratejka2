using System;

public static class MapObject
{
    private static int _size = StartGame.Size;
    private static int _radiusOfDefeat = 1;
    public static Object[,] _map;

    public static Object GetObject(Point p)
    {
        return _map[p.x, p.y];
    }

    public static void DeleteObject(Point p)
    {
        _map[p.x, p.y] = null;
    }

    public static void SetObject(Object value, Point p)
    {
        if (!IsCoordValid(new Point(p.x, p.y)) || _map[p.x, p.y] != null)
        {
            throw new ArgumentOutOfRangeException();
        }
        _map[p.x, p.y] = value;
    }
    public static void MakeMapObject()
    {
        _map = new Object[_size, _size];
    }

    public static bool IsCoordValid(Point p)
    {
        return 0 <= p.x && p.x < _size && 0 <= p.y && p.y < _size;
    }

    public static bool IsDealtDamage(Point p, int ind)
    {
        if (!IsCoordValid(p))
        {
            throw new ArgumentOutOfRangeException();
        }
        for (int i = -_radiusOfDefeat; i <= _radiusOfDefeat; i++)
        {
            for (int j = -_radiusOfDefeat; j <= _radiusOfDefeat; j++)
            {
                Point checkСell = new Point(p.x - i, p.y - j);
                if (!IsCoordValid(checkСell) || _map[checkСell.x, checkСell.y] == null || _map[checkСell.x, checkСell.y].PlayerNumber == ind) 
                {
                    continue;
                }
                Point localCoord = p - checkСell;
                if(_map[checkСell.x, checkСell.y].IsDealtDamage(localCoord))
                { 
                    return true; 
                }
            }
        }
        return false;
    }
}
