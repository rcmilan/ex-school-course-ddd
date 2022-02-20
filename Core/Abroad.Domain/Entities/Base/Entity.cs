using Abroad.Domain.Events;

namespace Abroad.Domain.Entities.Base
{
    public abstract class Entity<TID> : IInternalEventHandler
    {
        private readonly Action<object> _applier = default!;

        protected Entity(Action<object> applier) => _applier = applier;

        protected Entity()
        { }

        public TID Id { get; protected set; } = default!;

        public void Handle(object @event) => When(@event);

        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);
        }

        protected abstract void When(object @event);
    }
}