using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class PropertiesListPage : ContentPage
{
	public PropertiesListPage()
	{
		InitializeComponent();
		BindingContext = new PropertiesListViewModel();
	}
}