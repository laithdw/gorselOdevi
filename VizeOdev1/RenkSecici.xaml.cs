using System;
using Microsoft.Maui.Controls;

namespace VizeOdev
{
    public partial class RenkSecici : ContentPage
    {
        private Color _currentColor;

        public RenkSecici()
        {
            InitializeComponent();
        }

        private void setBGcolor()
        {
            lbl.BackgroundColor = Color.FromRgb((int)slR.Value, (int)slG.Value, (int)slB.Value);
        }


        private void slR_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblR.Text = e.NewValue.ToString("0");
            setBGcolor();
        }

        private void slG_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblG.Text = e.NewValue.ToString("0");
            setBGcolor();
        }

        private void slB_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblB.Text = e.NewValue.ToString("0");
            setBGcolor();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (rdoDec.IsChecked)
            {
                Clipboard.SetTextAsync($" {(int)slR.Value} , {(int)slG.Value},{(int)slB.Value}");
            }
            else
            {

                Clipboard.SetTextAsync($" {(byte)slR.Value:x2} , {(byte)slG.Value:x2},{(byte)slB.Value:x2}");


            }

        }
        private void OnRandomColorButtonClicked(object sender, EventArgs e)
        {
            var random = new Random();
            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);

            slR.Value = red;
            slG.Value = green;
            slB.Value = blue;
        }
    }
}