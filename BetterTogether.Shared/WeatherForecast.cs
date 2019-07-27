using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetterTogether.Shared
{
    public partial class WeatherForecast
    {
        //public DateTimeOffset Date { get; set; }

        //public int TemperatureC { get; set; }

        //public string Summary { get; set; }

        [JsonIgnore]
        public string DisplayDate => Date.Date.ToShortDateString();

        [JsonIgnore]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
