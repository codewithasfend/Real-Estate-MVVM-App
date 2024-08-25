using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.ViewModels
{
    internal partial class SettingsViewModel :  ObservableObject
    {
        [RelayCommand]
        void Logout()
        {
            Preferences.Set("accesstoken", string.Empty);
            Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
