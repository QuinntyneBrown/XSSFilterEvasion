using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using XSSFilterEvasion.Api.ValueObjects;

namespace XSSFilterEvasion.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ToDo
    {
        [Key]
        public Guid ToDoId { get; set; }

        public string Name { get; set; }
        public Html HtmlBody { get; set; }
        public DateTime? Deleted { get; set; }
        public DateTime? Completed { get; set; }
        public DateTime Modified { get; set; } = DateTime.UtcNow;
    }

}
