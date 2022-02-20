using Abroad.Domain.Entities.Base;
using Abroad.Domain.Exceptions;

namespace Abroad.Domain.Extensions
{
    public static class ValueExtensions
    {
        public static void MustBe<T>(this Value<T> value) where T : Value<T>
        {
            if (value == null)
                throw new InvalidValueException(typeof(T), "cannot be null");
        }

        public static void MustNotBeNull<T>(this Value<T> value) where T : Value<T>
        {
            if (value == null)
                throw new InvalidValueException(typeof(T), "cannot be null");
        }
    }
}