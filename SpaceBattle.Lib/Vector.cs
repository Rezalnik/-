namespace SpaceBattle.Lib;


public class Vector
{
    public int[] v;

    public Vector(params int[] args)
    {
        v = args;
    }
    public int Size()
    {
        return v.Length;
    }
    public override string ToString()
    {
        var output = "Vector(";
        for (var i = 0; i < v.Length - 1; i++)
        {
            output += v[i].ToString() + ", ";
        }
        output += v[v.Length - 1].ToString() + ")";
        return output;
    }
    public override bool Equals(object? obj)
    {
        if (obj is Vector vector)
        {
            var isequal = true;
            if (Size() == vector.Size())
            {
                for (var i = 0; i < Size(); i++)
                {
                    isequal = isequal && (v[i] == vector[i]);
                }
            }
            else isequal = false;
            return isequal;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(v);
    }
    public int this[int index]
    {
        get
        {
            return v[index];
        }
    }
    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.Size() == v2.Size())
        {
            int[] v3 = new int[v1.Size()];
            for (var i = 0; i < v1.Size(); i++)
            {
                v3[i] = v1[i] + v2[i];
            }
            return new Vector(v3);
        }
        else throw new ArgumentException("Вектора имеют разные длины!");
    }
    public static Vector operator -(Vector v1, Vector v2)
    {
        if (v1.Size() == v2.Size())
        {
            int[] v3 = new int[v1.Size()];
            for (var i = 0; i < v1.Size(); i++)
            {
                v3[i] = v1[i] - v2[i];
            }
            return new Vector(v3);
        }
        else throw new ArgumentException("Вектора имеют разные длины!");
    }
    public static Vector operator *(int s, Vector v1)
    {
        int[] v2 = new int[v1.Size()];
        for (var i = 0; i < v1.Size(); i++)
        {
            v2[i] = s * v1[i];
        }
        return new Vector(v2);
    }
    public static Vector operator *(Vector v, int s)
    {
        return s * v;
    }
    public static bool operator ==(Vector v1, Vector v2)
    {
        var isequal = true;
        if (v1.Size() == v2.Size())
        {
            for (var i = 0; i < v1.Size(); i++)
            {
                isequal = isequal && (v1[i] == v2[i]);
            }
        }
        else isequal = false;
        return isequal;
    }
    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }
    public static bool operator <(Vector v1, Vector v2)
    {
        var isless = true;
        var l = true;
        for (int i = 0; i < Math.Min(v1.Size(), v2.Size()); i++)
        {
            isless = isless && !(v1[i] > v2[i]);
            if (v1[i] < v2[i]) l = false;
        }
        if (l && isless)
        {
            if (v1.Size() >= v2.Size()) isless = false;
        }
        return isless;
    }
    public static bool operator >(Vector v1, Vector v2)
    {
        return v2 < v1;
    }
}
