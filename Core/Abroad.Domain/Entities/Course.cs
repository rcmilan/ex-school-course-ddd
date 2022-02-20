using Abroad.Domain.Entities.Base;
using Abroad.Domain.Exceptions;

namespace Abroad.Domain.Entities
{
    public class Course : Entity<CourseId>
    {
        #region Persistence

        protected Course()
        {
        }

        public Guid CourseId
        { get => Id.Value; set { } }

        #endregion Persistence

        #region Entity State

        public string Name { get; private set; } = default!;
        public SchoolId ParentId { get; private set; } = default!;

        #endregion Entity State

        public Course(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.Course.Create e:
                    ParentId = new SchoolId(e.ParentId);
                    Id = new CourseId(e.Id);
                    Name = e.Name;

                    break;

                default:
                    throw new UnsupportedDomainEventException(@event);
            }
        }
    }

    public class CourseId : Value<CourseId>
    {
        public CourseId(Guid value) => Value = value;

        protected CourseId()
        {
        }

        public Guid Value { get; }
    }
}