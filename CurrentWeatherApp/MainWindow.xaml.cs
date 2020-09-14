using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CurrentWeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherData currentData;
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Get image form API
        /// </summary>
        private BitmapImage getWeatherImage()
        {
            const string adress = "https://www.metaweather.com/static/img/weather/png/64/";
            const string ext = ".png";
            string name = "s";
            name = currentData.consolidated_weather[0].weather_state_abbr;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(adress + name + ext);
            bitmapImage.EndInit();
            return bitmapImage;
        }
        /// <summary>
        /// Get data from API
        /// </summary>
        /// <param name="locationWoeid"></param>
        private static WeatherData getData(long locationWoeid)
        {
            WebClient client = new WebClient();
            var str = client.DownloadString("https://www.metaweather.com/api/location/" + locationWoeid);
            WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(str);
            return weatherData;
        }
        /// <summary>
        /// Get location form API
        /// </summary>
        /// <param name="inputText"></param>
        private static long getLocation(string inputText)
        {
            WebClient client = new WebClient();
            string str = client.DownloadString("https://www.metaweather.com/api/location/search/?query=" + inputText);
            var locationData = JsonConvert.DeserializeObject<List<LocationData>>(str);
            return locationData[0].woeid;
        }
        /// <summary>
        /// Update controls data.
        /// </summary>
        private void dataUpdate()
        {
            locationNameLabel.Content = currentData.title;
            tempLabel.Content = currentData.consolidated_weather[0].the_temp;
            minTempLabel.Content = currentData.consolidated_weather[0].min_temp;
            maxTempLabel.Content = currentData.consolidated_weather[0].max_temp;
            maxTempLabel.Content = currentData.consolidated_weather[0].max_temp;
            pressureLabel.Content = currentData.consolidated_weather[0].air_pressure;
            humidityLabel.Content = currentData.consolidated_weather[0].humidity;
            weatherImage.Source = getWeatherImage();
        }

        private void inputButtom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputText = inputTextbox.Text;
                long locationWoeid = getLocation(inputText);
                this.currentData = getData(locationWoeid);
                dataUpdate();
            }
            catch
            {

            }
            
        }
    }
}
