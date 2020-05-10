using System;


namespace R5T.Integra
{
    public class TypedIntegerExtensions
    {
        public static bool ValueEquals(TypedInteger a, TypedInteger b)
        {
            var valueEquals = a.Value.Equals(b.Value);
            return valueEquals;
        }
    }
}
