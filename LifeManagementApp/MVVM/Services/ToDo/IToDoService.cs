using LifeManagementApp.MVVM.Models.ToDoModels;

namespace LifeManagementApp.MVVM.Services.ToDo
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetToDoItemsAsync();
        Task AddToDoItemAsync(ToDoItem toDoItem);
        Task ToggleToDoItemCompletionAsync(ToDoItem toDoItem);
        Task EditToDoItemTitleAsync(int id, string newTitle);
        Task DeleteToDoItemAsync(int id);
    }
}
