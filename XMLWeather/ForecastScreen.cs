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
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            for (int i = 0; i < Form1.days.Count(); i++)
            {
                Day day = Form1.days[i];
                day.convert_to_ints();

                double average = (day.tempHighN + day.tempLowN) / 2;
                Color[] colors = Form1.getColors(average);

                switch (i)
                {
                    case 0:
                        day.convert_to_ints();  
                        day1Label.Text = String.Format($"{day.month}/{day.day} High: {Math.Round(day.tempHighN, 0)} Low: {Math.Round(day.tempLowN, 0)}");

                        day1Label.ForeColor = colors[0];
                        day1Label.BackColor = colors[1];

                        break;
                    case 1:
                        day2Label.Text = String.Format($"{day.month}/{day.day} High: {Math.Round(day.tempHighN, 0)} Low: {Math.Round(day.tempLowN, 0)}");

                        day2Label.ForeColor = colors[0];
                        day2Label.BackColor = colors[1];


                        break;
                    case 2:
                        day3Label.Text = String.Format($"{day.month}/{day.day} High: {Math.Round(day.tempHighN, 0)} Low: {Math.Round(day.tempLowN, 0)}");

                        day3Label.ForeColor = colors[0];
                        day3Label.BackColor = colors[1];

                        break;
                    case 3:
                        day4Label.Text = String.Format($"{day.month}/{day.day} High: {Math.Round(day.tempHighN, 0)} Low: {Math.Round(day.tempLowN, 0)}");

                        day4Label.ForeColor = colors[0];
                        day4Label.BackColor = colors[1];

                        break;
                    case 4:
                        day5Label.Text = String.Format($"{day.month}/{day.day} High: {Math.Round(day.tempHighN, 0)} Low: {Math.Round(day.tempLowN, 0)}");

                        day5Label.ForeColor = colors[0];
                        day5Label.BackColor = colors[1];

                        break;
                    case 5:
                        day6Label.Text = String.Format($"{day.month}/{day.day} High: {Math.Round(day.tempHighN, 0)} Low: {Math.Round(day.tempLowN, 0)}");

                        day6Label.ForeColor = colors[0];
                        day6Label.BackColor = colors[1];

                        break;
                    case 6:
                        day7Label.Text = String.Format($"{day.month}/{day.day} High: {Math.Round(day.tempHighN, 0)} Low: {Math.Round(day.tempLowN, 0)}");

                        day7Label.ForeColor = colors[0];
                        day7Label.BackColor = colors[1];

                        break;
                    default:
                        break;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
