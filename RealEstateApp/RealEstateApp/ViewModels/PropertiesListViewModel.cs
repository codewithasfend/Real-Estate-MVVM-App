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
    [QueryProperty("Category", "Category")]
    internal partial class PropertiesListViewModel : ObservableObject
    {
        [ObservableProperty]
        int category;

        public ObservableCollection<PropertyByCategory> PropertyByCategoryCollection { get; set; } = new ObservableCollection<PropertyByCategory>();

        partial void OnCategoryChanged(int value)
        {
            GetPropertiesList(value);
        }


        private async Task GetPropertiesList(int category)
        {
            var propertyByCategory = await ApiService.GetPropertyByCategory(category);
            foreach (var property in propertyByCategory)
            {
                PropertyByCategoryCollection.Add(property);
            }
        }

        [RelayCommand]
        void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }

        [ObservableProperty]
        PropertyByCategory selectedProperty;

        [RelayCommand]
        void GoToPropertyDetail()
        {
            if (selectedProperty == null) return;
            Shell.Current.GoToAsync("PropertyDetailPage?Property="+ SelectedProperty.Id);
            SelectedProperty = null;
        }
    }
}
