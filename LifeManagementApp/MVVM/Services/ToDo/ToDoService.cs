using LifeManagementApp.MVVM.Models.ToDoModels;
using System.Text.Json;

namespace LifeManagementApp.MVVM.Services.ToDo
{
    public class ToDoService : IToDoService
    {
        private const string ToDoStorageKey = "ToDoList";
        private List<ToDoItem> _toDoItems;
        public ToDoService()
        {
            //_toDoItems = new List<ToDoItem>();
            var savedData = Preferences.Get(ToDoStorageKey, string.Empty);
            _toDoItems = string.IsNullOrEmpty(savedData)
                ? new List<ToDoItem>()
                : JsonSerializer.Deserialize<List<ToDoItem>>(savedData) ?? new List<ToDoItem>();
        }

        public async Task<List<ToDoItem>> GetToDoItemsAsync()
        {
            return await Task.FromResult(_toDoItems);
        }

        public async Task AddToDoItemAsync(ToDoItem toDoItem)
        {
            toDoItem.Id = _toDoItems.Count > 0 ? _toDoItems.Max(x => x.Id) + 1 : 1;
            _toDoItems.Add(toDoItem);
            SaveToStorage();
            await Task.CompletedTask;
        }

        public async Task ToggleToDoItemCompletionAsync(ToDoItem toDoItem)
        {
            var existingItem = _toDoItems.FirstOrDefault(x => x.Id == toDoItem.Id);
            if (existingItem != null)
            {
                existingItem.IsCompleted = !existingItem.IsCompleted;
            }
            SaveToStorage();
            await Task.CompletedTask;
        }

        public async Task EditToDoItemTitleAsync(int id, string newTitle)
        {
            var existingItem = _toDoItems.FirstOrDefault(x => x.Id == id);
            if (existingItem != null)
            {
                existingItem.Title = newTitle;
            }
            SaveToStorage();
            await Task.CompletedTask;
        }

        public async Task DeleteToDoItemAsync(int id)
        {
            var itemToRemove = _toDoItems.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                _toDoItems.Remove(itemToRemove);
            }
            SaveToStorage();
            await Task.CompletedTask;
        }

        private void SaveToStorage()
        {
            // Serialize the list and save to Preferences
            var data = JsonSerializer.Serialize(_toDoItems);
            Preferences.Set(ToDoStorageKey, data);
        }
    }
}
