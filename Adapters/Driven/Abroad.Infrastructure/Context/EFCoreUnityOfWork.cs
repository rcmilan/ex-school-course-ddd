using Abroad.Domain.Repositories;

namespace Abroad.Infrastructure.Context
{
    public class EFCoreUnityOfWork : IUnityOfWork
    {
        private readonly AbroadContext _context;

        public EFCoreUnityOfWork(AbroadContext context)
        {
            this._context = context;
        }

        public Task Commit() => _context.SaveChangesAsync();
    }
}
