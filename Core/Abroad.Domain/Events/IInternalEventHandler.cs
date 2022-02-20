namespace Abroad.Domain.Events
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}
