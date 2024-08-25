using Newtonsoft.Json;
using RealEstateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateApp.Services
{
    internal class ApiService
    {
       public static async Task<bool> RegisterUser(string name, string email, string password, string phone)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password,
                Phone = phone
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/users/register", content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

       public static async Task<bool> Login(string email, string password)
        {

            var login = new Login()
            {
                Email = email,
                Password = password
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/users/login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var tokenResult = JsonConvert.DeserializeObject<Token>(jsonResult);
                Preferences.Set("accesstoken", tokenResult.AccessToken);
                Preferences.Set("userId", tokenResult.UserId);
                Preferences.Set("username", tokenResult.UserName);
                return true;
            }
            return false;
        }


        public static async Task<List<Category>> GetCategories()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/categories");
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        public static async Task<List<TrendingProperty>> GetTrendingProperties()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/TrendingProperties");
            return JsonConvert.DeserializeObject<List<TrendingProperty>>(response);
        }

        public static async Task<List<SearchProperty>> FindProperties(string address)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/SearchProperties?address=" + address);
            return JsonConvert.DeserializeObject<List<SearchProperty>>(response);
        }

        public static async Task<List<PropertyByCategory>> GetPropertyByCategory(int categoryId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/PropertyList?categoryId=" + categoryId);
            return JsonConvert.DeserializeObject<List<PropertyByCategory>>(response);
        }


        public static async Task<PropertyDetail> GetPropertyDetail(int propertyId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesstoken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Properties/PropertyDetail?id=" + propertyId);
            return JsonConvert.DeserializeObject<PropertyDetail>(response);
        }

    }
}
