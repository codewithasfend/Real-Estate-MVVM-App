using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.ViewModels
{
    internal partial class HomeViewModel : ObservableObject
    {
        public ObservableCollection<TrendingProperty> TrendingPropertiesCollection { get; set; } = new ObservableCollection<TrendingProperty>();
        public ObservableCollection<Category> CategoriesCollection { get; set; } = new ObservableCollection<Category>();

        public HomeViewModel()
        {
            GetCategories();
            GetTrendingProperties();
        }

        private async Task GetTrendingProperties()
        {
            var trendingProperties = await ApiService.GetTrendingProperties();
            foreach (var property in trendingProperties)
            {
                TrendingPropertiesCollection.Add(property);
            }
        }

        [ObservableProperty]
        string username = "Hi " + Preferences.Get("username", string.Empty);

        async Task GetCategories()
        {
            var categories = await ApiService.GetCategories();
            foreach (var category in categories)
            {
                CategoriesCollection.Add(category);
            }
        }

        [ObservableProperty]
        Category selectedCategory;

        [RelayCommand]
        void GoToPropertiesList()
        {
            if (selectedCategory == null) return;
            Shell.Current.GoToAsync("PropertiesListPage?Category=" + SelectedCategory.Id);
            SelectedCategory = null;
        }

        [ObservableProperty]
        TrendingProperty selectedProperty;

        [RelayCommand]
        void GoToPropertyDetail()
        {
            if (selectedProperty == null) return;
            Shell.Current.GoToAsync("PropertyDetailPage?Property=" + SelectedProperty.Id);
            SelectedProperty = null;
        }

        [RelayCommand]
        void Search()
        {
            Shell.Current.GoToAsync("SearchPage");
        }
    }
}
