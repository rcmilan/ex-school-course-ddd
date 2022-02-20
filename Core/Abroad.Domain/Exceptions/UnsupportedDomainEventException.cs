namespace Abroad.Domain.Exceptions
{
    public class UnsupportedDomainEventException : Exception
    {
        public UnsupportedDomainEventException(object @event) : base($"Evento não implementado! {@event}")
        {

        }
    }
}
