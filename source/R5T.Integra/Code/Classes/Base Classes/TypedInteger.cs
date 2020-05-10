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
        #region Static

        public static bool operator== (TypedInteger a, TypedInteger b)
        {
            if (a is null)
            {
                var output = b is null;
                return output;
            }
            else
            {
                var output = a.Equals(b);
                return output;
            }
        }

        public static bool operator !=(TypedInteger a, TypedInteger b)
        {
            var output = !(a == b);
            return output;
        }

        #endregion


        public int Value { get; }


        public TypedInteger(int value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            // No type-check required since (obj as TypedString).GetType() will still return the actual type.

            var objAsTypedInteger = obj as TypedInteger;

            var isEqual = this.Equals_Value(objAsTypedInteger);
            return isEqual;
        }

        protected virtual bool Equals_Value(TypedInteger other)
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
            // Required type-check for derived classes using the base class TypedString.Equals(TypedString).
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Value(other);
            return isEqual;
        }

        public int CompareTo(TypedInteger other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
