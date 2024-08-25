using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class PropertyDetailPage : ContentPage
{
	public PropertyDetailPage()
	{
		InitializeComponent();
		BindingContext = new PropertyDetailViewModel();
	}
}