using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EconoTrack.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
