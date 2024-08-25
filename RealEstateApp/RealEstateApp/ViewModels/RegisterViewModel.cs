using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RealEstateApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.ViewModels
{
    internal partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string phone;


        [RelayCommand]
        async Task Register()
        {
            var response = await ApiService.RegisterUser(Name,Email,Password,Phone);
            if (response)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Oops", "Something went wrong", "Cancel");

            }
        }

        [RelayCommand]
        void Login()
        {
            Shell.Current.GoToAsync("///LoginPage");
        }
    }
}
