using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp, currentTime, condition, location, tempHigh, tempLow, 
            windSpeed, windDirection, precipitation, visibility, humidity;

        public double tempHighN, tempLowN;
        public int day, month, year;

        public Day()
        {
            date = currentTemp = currentTime = condition = location = tempHigh = tempLow
                = windSpeed = windDirection = precipitation = visibility = humidity = "";
        }

        public string format()
        {
            string ret = $"{date}\nHigh: {tempHigh} Low: {tempLow} | Precipitation: {Convert.ToDouble(precipitation) * 100.0}% \n Wind: {windSpeed}m/s to {windDirection}";

            return ret;
        }

        public void convert_to_ints()
        {
            tempHighN = Convert.ToDouble(tempHigh);
            tempLowN = Convert.ToDouble(tempLow);

            if (date == null)
            {
                return;
            }

            string[] splitDate = date.Split('-');
            year = Convert.ToInt32(splitDate[0]);
            month = Convert.ToInt32(splitDate[1]);
            day = Convert.ToInt32(splitDate[2]);
        }
    }
}
