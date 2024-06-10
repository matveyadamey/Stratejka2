public abstract class Object
{
    public abstract string Type { get; }
    public abstract int Cost { get; }
    public abstract int PlayerNumber { get; }

    public abstract bool IsDealtDamage(Point coord);
}
