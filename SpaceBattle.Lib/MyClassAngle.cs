namespace SpaceBattle.Lib;

public class Degrees
{
    public int ang;

    public Degrees(int a)
    {
        ang = a % 360;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Degrees angle)
        {
            return ang == angle.ang;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return 0;
    }

    public static Degrees operator +(Degrees a1, Degrees a2)
    {
        int a3;
        a3 = a1.ang + a2.ang;
        return new Degrees(a3);
    }

    public static Degrees operator -(Degrees a1, Degrees a2)
    {
        int a3;
        a3 = a1.ang - a2.ang;
        return new Degrees(a3);
    }

    public static Degrees operator *(int s, Degrees a1)
    {
        int a2;
        a2 = s * a1.ang;
        return new Degrees(a2);
    }

    public static Degrees operator *(Degrees a1, int s)
    {
        return s * a1;
    }

    public static bool operator ==(Degrees a1, Degrees a2)
    {
        return a1 == a2;
    }

    public static bool operator !=(Degrees a1, Degrees a2)
    {
        return a1 != a2;
    }

    public static bool operator <(Degrees a1, Degrees a2)
    {
        return a1 < a2;
    }

    public static bool operator >(Degrees a1, Degrees a2)
    {
        return a1 > a2;
    }

}
