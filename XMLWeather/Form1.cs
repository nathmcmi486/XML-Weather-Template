using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // TODO: create list to hold day objects
        public static List<Day> days = new List<Day>();
        public static bool error = false;

        public Form1()
        {
            InitializeComponent();

            ExtractForecast("Stratford", "CA");
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static void ExtractForecast(string city, string country)
        {
            days.Clear();
            XmlReader reader;
            try
            {
                reader = XmlReader.Create($"http://api.openweathermap.org/data/2.5/forecast/daily?q={city},{country}&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");
            } catch (WebException ex)
            {
                error = true;
                return;
            }

            while (reader.Read())
            {
                Day d = new Day();
                // date
                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

                // precipitation
                reader.ReadToFollowing("precipitation");
                d.precipitation = reader.GetAttribute("probability");

                // wind
                reader.ReadToFollowing("windDirection");
                d.windDirection = reader.GetAttribute("name");
                reader.ReadToFollowing("windSpeed");
                d.windSpeed = reader.GetAttribute("mps");

                // temp
                reader.ReadToFollowing("temperature");
                d.tempLow = reader.GetAttribute("min");
                d.tempHigh = reader.GetAttribute("max");

                reader.ReadToFollowing("humidity");
                d.humidity = reader.GetAttribute("value");

                reader.ReadToFollowing("clouds");
                d.visibility = reader.GetAttribute("value");

                d.convert_to_ints();
                days.Add(d);
            }
        }

        public static Color[] getColors(double average)
        {
            Color[] colors = new Color[2];
            if (average < 0.0)
            {
                colors[0] = Color.Black;
                colors[1] = Color.White;
            }
            else if (average > 0.0 && average < 10.0)
            {
                colors[0] = Color.LightGray;
                colors[1] = Color.DarkBlue;
            }
            else if (average > 9.0 && average < 16.0)
            {
                colors[0] = Color.Gray;
                colors[1] = Color.Yellow;
            }

            return colors;
        }

        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list


            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");
            reader.ReadToFollowing("temprature");
            days[0].currentTemp = reader.GetAttribute("value");
        }
    }
}
