using TodoApi.Models;

namespace TodoApi.Repositories;
public interface IToDoRepository
{
    Task AddToDoItem(ToDoItem todoItem);
    Task<List<ToDoItem>> GetToDoItems();
    Task<ToDoItem> GetToDoItemById(Guid id);
    Task UpdateToDoItem(ToDoItem todoItem);
    Task DeleteToDoItem(Guid id);
}