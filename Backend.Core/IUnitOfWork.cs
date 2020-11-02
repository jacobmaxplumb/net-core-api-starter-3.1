using System;
using System.Threading.Tasks;
using Backend.Core.Repositories;

namespace Backend.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IColorRepository Colors { get; }
        Task<int> CommitAsync();
    }
}