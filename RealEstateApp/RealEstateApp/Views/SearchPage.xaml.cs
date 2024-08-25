using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
		BindingContext = new SearchViewModel();
	}
}