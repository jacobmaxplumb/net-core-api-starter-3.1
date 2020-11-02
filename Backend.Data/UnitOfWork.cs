using System.Threading.Tasks;
using Backend.Core;
using Backend.Core.Repositories;
using Backend.Data.Repositories;

namespace Backend.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RaiseAndReviewDbContext _context;
        private ColorRepository _colorRepository;

        public UnitOfWork(RaiseAndReviewDbContext context)
        {
            this._context = context;
        }

        public IColorRepository Colors => _colorRepository ??= new ColorRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}