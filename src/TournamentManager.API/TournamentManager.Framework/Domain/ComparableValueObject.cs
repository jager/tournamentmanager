    
namespace TournamentManager.Framework.Domain;
public class ComparableValueObject<T> : ValueObject<T>, IComparable where T : IComparable
{
    protected ComparableValueObject(T value) : base(value)
    {
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        var otherComparableValue = obj as ComparableValueObject<T>;

        if (otherComparableValue != null)
            return Value.CompareTo(otherComparableValue.Value);
        throw new ArgumentException("Improper object type");
    }

    private bool Equals(ComparableValueObject<T> other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value.Equals(other.Value);
    }

    public override bool Equals(object obj)
    {
        return Equals((ComparableValueObject<T>)obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(ComparableValueObject<T> left, ComparableValueObject<T> right)
    {
        if (ReferenceEquals(left, null)) return ReferenceEquals(right, null);
        return left.Equals(right);
    }

    public static bool operator >(ComparableValueObject<T> left, ComparableValueObject<T> right)
    {
        return Compare(left, right) > 0;
    }

    public static bool operator <(ComparableValueObject<T> left, ComparableValueObject<T> right)
    {
        return Compare(left, right) < 0;
    }

    public static bool operator !=(ComparableValueObject<T> left, ComparableValueObject<T> right)
    {
        return !(left == right);
    }

    private static int Compare(ComparableValueObject<T> left, ComparableValueObject<T> right)
    {
        return left.CompareTo(right);
    }
}

