using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
	}
}