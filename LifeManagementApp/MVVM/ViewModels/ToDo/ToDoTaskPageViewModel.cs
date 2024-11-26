using LifeManagementApp.MVVM.Models.ToDoModels;
using LifeManagementApp.MVVM.Services.ToDo;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LifeManagementApp.MVVM.ViewModels.ToDo
{
    public class ToDoTaskPageViewModel
    {            
        private readonly IToDoService _toDoService;
        public ObservableCollection<ToDoItem> ToDoItems { get; } = new ObservableCollection<ToDoItem>();
        public int IncompleteTaskCount => ToDoItems.Count(item => !item.IsCompleted);

        public event PropertyChangedEventHandler PropertyChanged;
        public ToDoTaskPageViewModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task LoadToDoItemAsync()
        {
            var toDoItems = await _toDoService.GetToDoItemsAsync();
            ToDoItems.Clear();
            foreach (var toDoItem in toDoItems)
            {
                ToDoItems.Add(toDoItem);
            }
            OnPropertyChanged(nameof(IncompleteTaskCount));
        }

        public async Task AddToDoItemAsync(string title)
        {
            var newToDoItem = new ToDoItem { Title = title, IsCompleted = false };
            await _toDoService.AddToDoItemAsync(newToDoItem);
            ToDoItems.Add(newToDoItem);
            OnPropertyChanged(nameof(IncompleteTaskCount));
        }

        public async Task ToggleToDoItemCompletionAsync(ToDoItem toDoItem)
        {
            var item = ToDoItems.FirstOrDefault(x => x.Id == toDoItem.Id);
            if (item != null)
            {
                item.IsCompleted = toDoItem.IsCompleted; // Update in memory
                await _toDoService.ToggleToDoItemCompletionAsync(item); // Persist to storage
                OnPropertyChanged(nameof(IncompleteTaskCount)); // Notify UI
            }
        }

        public async Task EditToDoItemTitleAsync(int id, string newTitle)
        {
            var item = ToDoItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                await _toDoService.EditToDoItemTitleAsync(id, newTitle);
                item.Title = newTitle;
            }
        }

        public async Task DeleteToDoItemAsync(int id)
        {
            await _toDoService.DeleteToDoItemAsync(id);
            var itemToRemove = ToDoItems.FirstOrDefault(x => x.Id == id);
            if (itemToRemove != null)
            {
                ToDoItems.Remove(itemToRemove);
            }
            OnPropertyChanged(nameof(IncompleteTaskCount));
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
