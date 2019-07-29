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

namespace BetterTogether.Mobile
{
    public partial class MainPage : ContentPage
    {
        public Command GetWeatherCommand { get; }
        public ObservableCollection<WeatherForecast> Items { get; }

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
                var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
                            "http://10.0.2.2:51221" :
                            "http://localhost:51221";

                
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
