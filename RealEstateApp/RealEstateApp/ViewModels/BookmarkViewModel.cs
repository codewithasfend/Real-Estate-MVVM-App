using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.ViewModels
{
    internal partial class BookmarkViewModel : ObservableObject
    {
        public ObservableCollection<BookmarkedProperty> BookmarksCollection { get; set; } = new ObservableCollection<BookmarkedProperty>();
        private BookmarkItemService bookmarkItemService = new BookmarkItemService();


        void GetBookmarks()
        {
            BookmarksCollection.Clear();
            var bookmarks = bookmarkItemService.ReadAll();
            foreach (var bookmark in bookmarks)
            {
                BookmarksCollection.Add(bookmark);
            }
        }

        [RelayCommand]
        void LoadBookmarks()
        {
            GetBookmarks();
        }

        [ObservableProperty]
        BookmarkedProperty selectedProperty;

        [RelayCommand]
        void GoToPropertyDetail()
        {
            if (selectedProperty == null) return;
            Shell.Current.GoToAsync("PropertyDetailPage?Property=" + SelectedProperty.PropertyId);
            SelectedProperty = null;
        }
    }
}
