using System;


namespace R5T.Integra
{
    /// <summary>
    /// Allow wrapping an integer with a specific type.
    /// This is helpful in creating strongly-typed strings for integrally-typed data. Examples: FileID.
    /// Value is read-only.
    /// </summary>
    public abstract class TypedInteger : IEquatable<TypedInteger>, IComparable<TypedInteger>
    {
        public int Value { get; }


        public TypedInteger(int value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var objAsTypedInteger = obj as TypedInteger;

            var isEqual = this.Equals_Internal(objAsTypedInteger);
            return isEqual;
        }

        protected virtual bool Equals_Internal(TypedInteger other)
        {
            var isEqual = this.Value.Equals(other.Value);
            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var representation = this.Value.ToString();
            return representation;
        }

        public bool Equals(TypedInteger other)
        {
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Internal(other);
            return isEqual;
        }

        public int CompareTo(TypedInteger other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
