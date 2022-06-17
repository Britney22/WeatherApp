using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static MyWeatherApp.WeatherData;

namespace MyWeatherApp
{
    public partial class MainPage : ContentPage
    {
        private readonly OpenWeatherData    weatherData;

        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var data = await GetWeatherData();
            BindingContext = data;
        }
        private async Task<OpenWeatherData> GetWeatherData()
        {
            var location = await Geolocation.GetLocationAsync();
            var Latitude = location.Latitude;
            var Longitude = location.Longitude;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("accept", "application/json");
            
            var response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=-33.9025,lon=18.5869&units=metric&appid=5270d59b217e8e0027bc734b6124f18d");
           
            var weatherData = JsonConvert.DeserializeObject<OpenWeatherData>(response);
            return weatherData;
        }
    }
}
    

