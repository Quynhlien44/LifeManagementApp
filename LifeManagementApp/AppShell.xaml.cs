using LifeManagementApp.MVVM.Pages;

namespace LifeManagementApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WeatherInfoPage), typeof(MVVM.Pages.WeatherInfoPage));
            Routing.RegisterRoute(nameof(ToDoTaskPage), typeof(MVVM.Pages.ToDoTaskPage));
        }
    }
}
