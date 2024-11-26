using LifeManagementApp.MVVM.ViewModels.Weather;
namespace LifeManagementApp.MVVM.Pages;

public partial class WeatherInfoPage : ContentPage
{
	public WeatherInfoPage()
	{
		InitializeComponent();
		BindingContext = new WeatherInfoPageViewModel();
	}
}