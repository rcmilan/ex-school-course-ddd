using Abroad.Domain.Entities.Base;
using Abroad.Domain.Exceptions;

namespace Abroad.Domain.Entities
{
    public enum SchoolState
    {
        Active,
        Inactive,
    }

    public class School : AggregateRoot<Guid>
    {
        public School(Guid Id, string name)
        {
            Courses = new List<Course>();
            Apply(new Events.School.Create(Id, name));
        }

        protected School()
        {
            // Utilizado pelo EFCore
        }

        public List<Course> Courses { get; }
        public string Name { get; private set; } = default!;
        public SchoolState State { get; private set; } = SchoolState.Inactive;

        public void AddCourse(string name)
        {
            Apply(new Events.Course.Create(Guid.NewGuid(), Id, name));
        }

        protected override void EnsureValidState()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(Name))
                valid = false;

            if (!valid)
                throw new Exception("Estado inválido!");
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.School.Create createEvent:
                    Id = createEvent.Id;
                    Name = createEvent.Name;
                    State = SchoolState.Active;
                    break;

                // Course
                case Events.Course.Create createCourseEvent:
                    Course course = new(Apply);
                    ApplyToEntity(course, createCourseEvent);
                    Courses.Add(course);
                    break;

                default:
                    throw new UnsupportedDomainEventException(@event);
            }
        }
    }
}