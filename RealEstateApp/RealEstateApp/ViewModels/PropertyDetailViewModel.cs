using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.ViewModels
{
    [QueryProperty("Property", "Property")]
    internal partial class PropertyDetailViewModel : ObservableObject
    {
        private BookmarkItemService bookmarkItemService = new BookmarkItemService();

        [ObservableProperty]
        int property;

        int propertyId;

        [ObservableProperty]
        PropertyDetail propertyDetail;

        [ObservableProperty]
        string bookmarkIcon = "bookmark_empty_icon";

        partial void OnPropertyChanged(int value)
        {
            GetPropertyDetail(value);
            propertyId = value;
            UpdateBookmarkButton();
        }

        private async Task GetPropertyDetail(int value)
        {
            var detail = await ApiService.GetPropertyDetail(value);
            PropertyDetail = detail;
        }

        [RelayCommand]
        void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        void Call()
        {
            PhoneDialer.Open(PropertyDetail.Phone);
        }

        [RelayCommand]
        void Message()
        {
            var message = new SmsMessage("Hi ! I am interested in your property", PropertyDetail.Phone);
            Sms.ComposeAsync(message);
        }

        [RelayCommand]
        void ToggleBookmark()
        {
            var existingBookmark = bookmarkItemService.Read(propertyId);
            if (existingBookmark != null) 
            { 
                bookmarkItemService.Delete(existingBookmark);
            }
            else
            {
                var bookmarkedProperty = new BookmarkedProperty()
                {
                    PropertyId = propertyId,
                    IsBookmarked = true,
                    Name = PropertyDetail.Name,
                    Address = PropertyDetail.Address,
                    Price = PropertyDetail.Price,
                    ImageUrl = PropertyDetail.ImageUrl,
                };

                bookmarkItemService.Create(bookmarkedProperty);
            }
            UpdateBookmarkButton();
        }

        void UpdateBookmarkButton()
        {
            var existingBookmark = bookmarkItemService.Read(propertyId);
            if (existingBookmark != null)
            {
                BookmarkIcon = "bookmark_fill_icon";
            }
            else
            {
                BookmarkIcon = "bookmark_empty_icon";
            }

        }
       
    }
}
