using Microsoft.Maui.Controls;

namespace VizeOdev
{
    public partial class VKIHesaplayici : ContentPage
    {
        public VKIHesaplayici()
        {
            InitializeComponent();
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            if (double.TryParse(EntryHeight.Text, out double height) && double.TryParse(EntryWeight.Text, out double weight))
            {
                double heightInMeters = height / 100;
                double bmi = weight / (heightInMeters * heightInMeters);
                string bmiStatus = GetBmiStatus(bmi);
                LabelResult.Text = $"Vücut Kitle İndeksi: {bmi:F2} ({bmiStatus})";
            }
            else
            {
                LabelResult.Text = "Lütfen geçerli boy ve kilo değerleri girin.";
            }
        }

        private string GetBmiStatus(double bmi)
        {
            if (bmi < 16)
                return " Çok Ciddi Zayıflık";
            else if (bmi >= 16 && bmi < 16.9)
                return " Ciddi Zayıflık";
            else if (bmi >= 17 && bmi < 18.4)
                return " Hafif Zayıflık";
            else if (bmi >= 18.5 && bmi < 24.9)
                return " Normal";
            else if (bmi >= 25 && bmi < 29.9)
                return " Fazla Kilolu";
            else if (bmi >= 30 && bmi < 34.9)
                return " Obez (Obezite 1)";
            else if (bmi >= 35 && bmi < 39.9)
                return " Obez (Obezite 2)";
            else
                return " Çok Ciddi Obez (Obezite 3)";
        }
    }
}