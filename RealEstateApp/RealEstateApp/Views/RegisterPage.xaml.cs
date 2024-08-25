using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
		BindingContext = new RegisterViewModel();
	}
}