using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kotlin.Properties;
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
    internal partial class SearchViewModel : ObservableObject
    {
        public ObservableCollection<SearchProperty> SearchPropertyCollection { get; set; } = new ObservableCollection<SearchProperty>();

        [ObservableProperty]
        string searchText;

        [RelayCommand]
        async Task PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchText)) return;
            SearchPropertyCollection.Clear();
            var properties = await ApiService.FindProperties(SearchText);
            foreach (var property in properties)
            {
                SearchPropertyCollection.Add(property);
            }
        }
        [RelayCommand]
        void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }

        [ObservableProperty]
        SearchProperty selectedProperty;

        [RelayCommand]
        void GoToPropertyDetail()
        {
            if (selectedProperty == null) return;
            Shell.Current.GoToAsync("PropertyDetailPage?Property=" + SelectedProperty.Id);
            SelectedProperty = null;
        }
    }
}
