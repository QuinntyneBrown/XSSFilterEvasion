using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using XSSFilterEvasion.Api.Models;

namespace XSSFilterEvasion.Api.Data
{
    public interface IXSSFilterEvasionDbContext
    {
        DbSet<ToDo> ToDos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IXSSFilterEvasionDbContext AsNoTracking();
    }
}
