using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using XSSFilterEvasion.Api.Models;

namespace XSSFilterEvasion.Api.Data
{
    public class XSSFilterEvasionDbContext: DbContext, IXSSFilterEvasionDbContext
    {
        public XSSFilterEvasionDbContext(DbContextOptions options)
            :base(options) { }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<ToDo> ToDos { get; private set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(XSSFilterEvasionDbContext).Assembly);
        }

        public IXSSFilterEvasionDbContext AsNoTracking()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return this;
        }
    }
}
