using LifeManagementApp.MVVM.ViewModels.ToDo;
using LifeManagementApp.MVVM.Services.ToDo;
using LifeManagementApp.MVVM.Models.ToDoModels;

namespace LifeManagementApp.MVVM.Pages;

public partial class ToDoTaskPage : ContentPage
{
    private readonly ToDoTaskPageViewModel _toDoTaskPageViewModel;

    public ToDoTaskPage()
    {
        InitializeComponent();
        _toDoTaskPageViewModel = new ToDoTaskPageViewModel(new ToDoService());
        BindingContext = _toDoTaskPageViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _toDoTaskPageViewModel.LoadToDoItemAsync();
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        var newTaskTitle = NewTaskEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(newTaskTitle))
        {
            await _toDoTaskPageViewModel.AddToDoItemAsync(newTaskTitle);
            NewTaskEntry.Text = string.Empty; // Clear the input after adding
        }
        else
        {
            await DisplayAlert("Error", "Task title cannot be empty.", "OK");
        }
    }

    private async void OnTaskCompletionToggled(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is ToDoItem task)
        {
            task.IsCompleted = checkBox.IsChecked; // Update state
            var viewModel = BindingContext as ToDoTaskPageViewModel;
            if (viewModel != null) await viewModel.ToggleToDoItemCompletionAsync(task);
        }
    }

/* Fix later
    private async void OnEditTaskClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int taskId)
        {
            var newTitle = await DisplayPromptAsync("Edit Task", "Enter new task title:");
            if (!string.IsNullOrEmpty(newTitle))
            {
                await _toDoTaskPageViewModel.EditToDoItemTitleAsync(taskId, newTitle);

                // Refresh the UI
                var updatedTask = _toDoTaskPageViewModel.ToDoItems.FirstOrDefault(t => t.Id == taskId);
                if (updatedTask != null)
                {
                    updatedTask.Title = newTitle;
                }
            }
        }
    }
*/

    private async void OnDeleteTaskClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int taskId)
        {
            var confirm = await DisplayAlert("Delete Task", "Are you sure you want to delete this task?", "Yes", "No");
            if (confirm)
            {
                await _toDoTaskPageViewModel.DeleteToDoItemAsync(taskId);
            }
        }
    }
}
