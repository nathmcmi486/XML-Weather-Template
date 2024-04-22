using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        string city = "Stratford";
        string country = "CA";

        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            Day day = Form1.days[0];
            double average = (day.tempHighN + day.tempLowN) / 2;
            Color[] colors = Form1.getColors(average);
            this.BackColor = colors[1];

            this.cityOutput.Text = $"{city} {country}";
            this.cityOutput.ForeColor = colors[0];
            this.tempLabel.Text = $"High: {Math.Round(day.tempHighN)}, Low: {Math.Round(day.tempLowN)}";
            this.tempLabel.ForeColor = colors[0];
            this.precepitationLabel.Text = $"{Convert.ToDouble(day.precipitation) * 100.0}% of Precepitation";
            this.precepitationLabel.ForeColor = colors[0];
            this.windLabel.Text = $"Wind: {Math.Round(Convert.ToDouble(day.windSpeed), 1)}m/s to the {day.windDirection}";
            this.windLabel.ForeColor = colors[0];
            this.humidityLabel.Text = $"Humidity: {Form1.days[0].humidity}%";
            this.humidityLabel.ForeColor = colors[0];
        }

        public void searchButtonClick(object sender, EventArgs e)
        {
            if (this.locationInput.Text == null)
            {
                this.cityOutput.Text = "Input is null";
                this.Refresh();
                return;
            }

            string[] split = this.locationInput.Text.Split(' ');

            if (split.Length != 2)
            {
                this.cityOutput.Text = "Invalid city country input";
                this.Refresh();
                return;
            }

            city = split[0];
            country = split[1];
            this.cityOutput.Text = $"{city} {country}";

            Form1.ExtractForecast(city, country);

            if (Form1.error == true)
            {
                Form1.error = false;
                this.cityOutput.Text = "Invalid city";
                return;
            }

            DisplayCurrent();

            this.Refresh();
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
    }
}
