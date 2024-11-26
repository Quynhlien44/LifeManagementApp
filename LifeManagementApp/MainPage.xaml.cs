using Microsoft.Maui.Storage;
using LifeManagementApp.MVVM.Services.ToDo;

namespace LifeManagementApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IToDoService _toDoService;

        public MainPage()
        {
            InitializeComponent();
            _toDoService = new ToDoService();
            DisplayWeatherInfo();
            DisplayUncompletedTasks();
        }

        private async void OnWeatherInfoClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MVVM.Pages.WeatherInfoPage));
        }

        private async void OnToDoTasksClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MVVM.Pages.ToDoTaskPage));
        }

        private void DisplayWeatherInfo()
        {
            string userCity = Preferences.Get("UserCity", string.Empty);
            string windWarning = Preferences.Get("WindWarningMessage", string.Empty);

            if (string.IsNullOrWhiteSpace(userCity))
            {
                WeatherStatusLabel.Text = "You have not set your current location yet. Kindly provide it in the Weather page.";
                WarningLabel.IsVisible = false;
            }
            else
            {
                string temperature = Preferences.Get("CurrentTemperature", "Unknown");
                string weatherDescription = Preferences.Get("WeatherDescription", "Unknown");
                WeatherStatusLabel.Text = $"Weather in {userCity}: {temperature}, {weatherDescription}";

                // Display wind warning if present
                WarningLabel.Text = windWarning;
                WarningLabel.IsVisible = !string.IsNullOrWhiteSpace(windWarning);
            }
        }

        private async void DisplayUncompletedTasks()
        {
            var toDoItems = await _toDoService.GetToDoItemsAsync();

            // Count the incomplete tasks
            int incompleteTaskCount = toDoItems.Count(task => !task.IsCompleted);

            // Update the label
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayWeatherInfo(); // Refresh weather info when MainPage appears
            DisplayUncompletedTasks(); // Refresh uncompleted tasks when MainPage appears
        }
    }
}
