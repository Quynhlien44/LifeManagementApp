using LifeManagementApp.MVVM.Services.ToDo;

namespace LifeManagementApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddScoped<IToDoService, ToDoService>();
            var app = builder.Build();
            app.Services.GetService<IToDoService>();
            MainPage = new AppShell();
        }
    }
}
