﻿namespace Abroad.Domain.Exceptions
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(Type type, string message) : base($"Value of {type.Name} {message}")
        {
        }
    }
}
