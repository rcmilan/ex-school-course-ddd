using Abroad.Domain.Events;

namespace Abroad.Domain.Entities.Base
{
    public abstract class AggregateRoot<TID> : IInternalEventHandler
    {
        private readonly List<object> _changes;

        protected AggregateRoot() => _changes = new List<object>();

        public TID Id { get; protected set; } = default!;

        public void ClearChanges() => _changes.Clear();

        public IEnumerable<object> GetChanges() => _changes.AsEnumerable();

        public void Handle(object @event) => When(@event);

        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            _changes.Add(@event);
        }

        protected void ApplyToEntity(IInternalEventHandler entity, object @event) => entity?.Handle(@event);

        protected abstract void EnsureValidState();

        protected abstract void When(object @event);
    }
}