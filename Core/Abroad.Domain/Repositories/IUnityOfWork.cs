namespace Abroad.Domain.Repositories
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}
