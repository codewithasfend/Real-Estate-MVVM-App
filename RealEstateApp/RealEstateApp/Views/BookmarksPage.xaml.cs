using RealEstateApp.ViewModels;

namespace RealEstateApp.Views;

public partial class BookmarksPage : ContentPage
{
	public BookmarksPage()
	{
		InitializeComponent();
		BindingContext = new BookmarkViewModel();
	}
}