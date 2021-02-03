using XSSFilterEvasion.Api.Models;
using XSSFilterEvasion.Api.ValueObjects;

namespace XSSFilterEvasion.Api.Features
{
    public static class ToDoExtensions
    {
        public static ToDoDto ToDto(this ToDo toDo)
        {
            return new ToDoDto
            {
                ToDoId = toDo.ToDoId,
                Name = toDo.Name,
                HtmlBody = Html.Create(toDo.HtmlBody).Value,
                Completed = toDo.Completed,
                Modified = toDo.Modified
            };
        }
    }
}
