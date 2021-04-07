using System;
using System.Windows;

namespace TipCalculator.Wpf
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!tryInputIntoDouble(TextBoxAmount.Text) || !tryInputIntoDouble(TextBoxPercentage.Text)) return;
            var amount = Convert.ToDouble(TextBoxAmount.Text);
            var percent = Convert.ToDouble(TextBoxPercentage.Text);
            var totalTip = amount / 100 * percent;
            var totalAmount = amount - totalTip;

            if (percent <= 30)
            {
                LblTipAmount.Content = totalTip;
                LblTotalAmount.Content = totalAmount;
            }
            else
            {
                MessageBox.Show("The percentage must be less than or equal to 30", "Error", MessageBoxButton.OK);
            }
        }

        private bool tryInputIntoDouble(string inputAmount)
        {
            try
            {
                var tryAmount = Convert.ToDouble(inputAmount);
                return true;
            }
            catch
            {
                var error = inputAmount;
                MessageBox.Show($"Value {error} is incorrect", "error", MessageBoxButton.OK);
                return false;
            }
        }
    }
}