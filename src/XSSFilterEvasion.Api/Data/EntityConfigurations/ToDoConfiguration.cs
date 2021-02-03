using XSSFilterEvasion.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XSSFilterEvasion.Api.ValueObjects;

namespace XSSFilterEvasion.Api.Data
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasQueryFilter(p => !p.Deleted.HasValue)
                .Property(x => x.HtmlBody)
                .HasConversion(
                property => (string)property,
                property => (Html)property);
        }
    }
}
