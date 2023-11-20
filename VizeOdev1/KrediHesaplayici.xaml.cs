
using Microsoft.Maui.Controls;
using System;

namespace VizeOdev
{
    public partial class KrediHesaplayici : ContentPage
    {
        public KrediHesaplayici()
        {
            InitializeComponent();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == SliderLoanAmount)
            {
                EntryLoanAmount.Text = $"{SliderLoanAmount.Value:F0}";
            }
            else if (sender == SliderInterestRate)
            {
                EntryInterestRate.Text = $"{SliderInterestRate.Value:F2}";
            }
            else if (sender == SliderLoanTerm)
            {
                EntryLoanTerm.Text = $"{SliderLoanTerm.Value:F0}";
            }
        }

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            if (sender == EntryLoanAmount && double.TryParse(EntryLoanAmount.Text, out double loanAmount))
            {
                SliderLoanAmount.Value = loanAmount;
            }
            else if (sender == EntryInterestRate && double.TryParse(EntryInterestRate.Text, out double interestRate))
            {
                SliderInterestRate.Value = interestRate;
            }
            else if (sender == EntryLoanTerm && int.TryParse(EntryLoanTerm.Text, out int loanTerm))
            {
                SliderLoanTerm.Value = loanTerm;
            }
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            if (double.TryParse(EntryLoanAmount.Text, out double loanAmount) &&
                double.TryParse(EntryInterestRate.Text, out double interestRate) &&
                int.TryParse(EntryLoanTerm.Text, out int loanTerm))
            {
                double monthlyInterestRate = interestRate / 100 / 12;
                double months = loanTerm;

                double monthlyPayment = loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, months) /
                                         (Math.Pow(1 + monthlyInterestRate, months) - 1);

                LabelResult.Text = $"Aylık ödeme: {monthlyPayment:F2}";
            }
            else
            {
                LabelResult.Text = "Lütfen geçerli değerler girin.";
            }
        }
    }
}