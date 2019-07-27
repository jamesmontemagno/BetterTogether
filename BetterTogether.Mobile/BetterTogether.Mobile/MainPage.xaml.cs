using BetterTogether.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

// ClintonRocksmith cheered 33 July 26, 2019
// mattleibow cheered 5 July 26, 2019
// lachlanwgordon cheered 6 July 26, 2019

namespace BetterTogether.Mobile
{
    public partial class MainPage : ContentPage
    {
        public Command GetWeatherCommand { get; }
        public ObservableCollection<WeatherForecast> Items { get; }
        string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:51221" : "http://localhost:51221";
        public MainPage()
        {
            InitializeComponent();
            GetWeatherCommand = new Command(async () => await ExecuteGetWeather());
            Items = new ObservableCollection<WeatherForecast>();
            BindingContext = this;
        }
        async Task ExecuteGetWeather()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                var client = new WeatherAPIClient(BaseUrl, new HttpClient());
                var items = await client.WeatherForecastAsync();
                foreach (var item in items)
                    Items.Add(item);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error!", $"Something has gone wrong: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
