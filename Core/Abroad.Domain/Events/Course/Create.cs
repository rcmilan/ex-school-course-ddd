namespace Abroad.Domain.Events.Course
{
    public record Create(Guid Id, Guid ParentId, string Name);
}