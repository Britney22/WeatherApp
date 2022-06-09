using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWeatherApp
{
    public partial class MainPage : ContentPage
    {
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
            var response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&units=metric&appid=9f09b912cf5f374307477a500df40269");
            var weatherData = JsonConvert.DeserializeObject<OpenWeatherData>(response);
            return weatherData;
        }
    }
}
    

