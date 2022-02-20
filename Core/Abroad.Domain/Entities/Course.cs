using Abroad.Domain.Entities.Base;
using Abroad.Domain.Exceptions;

namespace Abroad.Domain.Entities
{
    public class Course : Entity<Guid>
    {
        public Course(Action<object> applier) : base(applier)
        {
        }

        protected Course()
        {
            // Utilizado pelo EFCore
        }

        public string Name { get; private set; } = default!;
        public Guid ParentId { get; private set; } = default!;

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.Course.Create e:
                    ParentId = e.ParentId;
                    Id = e.Id;
                    Name = e.Name;

                    break;

                default:
                    throw new UnsupportedDomainEventException(@event);
            }
        }
    }
}