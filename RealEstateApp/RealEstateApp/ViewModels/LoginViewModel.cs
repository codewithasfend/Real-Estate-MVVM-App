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
    internal partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;


        [RelayCommand]
        async Task Login()
        {
            var response = await ApiService.Login(Email, Password);
            if (response)
            {
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Oops", "Something went wrong", "Cancel");

            }
        }

        [RelayCommand]
        void Register()
        {
            Shell.Current.GoToAsync("RegisterPage");
        }
    }
}
