using RealEstateApp.Views;

namespace RealEstateApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
            Routing.RegisterRoute("HomePage", typeof(HomePage));
            Routing.RegisterRoute("PropertiesListPage", typeof(PropertiesListPage));
            Routing.RegisterRoute("PropertyDetailPage", typeof(PropertyDetailPage));
            Routing.RegisterRoute("SearchPage", typeof(SearchPage));

            var accesstoken = Preferences.Get("accesstoken", string.Empty);
            if (string.IsNullOrEmpty(accesstoken))
            {
                GoToAsync("LoginPage");
            }
            else
            {
                GoToAsync("//HomePage");
            }
        }
    }
}
