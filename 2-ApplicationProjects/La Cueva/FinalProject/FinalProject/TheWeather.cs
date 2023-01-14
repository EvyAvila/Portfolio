using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class TheWeather
    {
        public string theWeatherType;
        public int theIndex = 0;

        public TheWeather() { }
        
        public TheWeather(string _weather)
        {
            theWeatherType = _weather;
        }

        public List<TheWeather> theForcast = new List<TheWeather>();

        public void AddingWeather()
        {
            theForcast.Add(new TheWeather("Sunny"));
            theForcast.Add(new TheWeather("Cloudy"));
            theForcast.Add(new TheWeather("Windy"));
            theForcast.Add(new TheWeather("Foggy"));
            theForcast.Add(new TheWeather("Rainy"));
        }

        public string ShowWeather()
        {
            AddingWeather();
            string output = "";

            output += $"It's {theForcast[theIndex].theWeatherType}";

            return output;
        }
    }
}
