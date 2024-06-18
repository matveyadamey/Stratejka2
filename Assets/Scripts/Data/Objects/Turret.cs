using System;

public class Turret : Object
{
    public override string Type { get; } = "turret";
    public override int Cost { get; } = 5;
    public override int PlayerNumber { get; }

    public Point Coodinate { get; set; }
    
    private Point _direction;

    public Turret()
    {
        
        PlayerNumber = CurrentPlayer.CurrentPlayerNumber;
    }

    public void SetDirection(Point p)
    {
        _direction = p - Coodinate;
    }

    public override bool IsDealtDamage(Point coord)
    {
        /*int dist1 = coord.GetDistSquared(new Point(0, 0));
        int dist2 = coord.GetDistSquared(_direction);
        return (dist1 == 2 && dist2 == 1) || dist2 == 0;*/
        if (coord.y != 0 && coord.y == _direction.y ||
            coord.x != 0 && coord.x == _direction.x ||
            coord.x == 0 && coord.y == 0)
            return true;
        return false;
    }
}
