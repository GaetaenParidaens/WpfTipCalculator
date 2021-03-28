using System;
using System.Windows;


namespace TipCalculator.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (tryInputIntoDouble(TextBoxAmount.Text) == true && tryInputIntoDouble(TextBoxPercentage.Text) == true)
            {
                double amount = Convert.ToDouble(TextBoxAmount.Text);
                double percent = Convert.ToDouble(TextBoxPercentage.Text);
                double totalTip = (amount / 100) * percent;
                double totalAmount = amount - totalTip;

                if (percent <= 30)
                {
                    lblTipAmount.Content = totalTip;
                    lblTotalAmount.Content = totalAmount;
                }
                else
                {
                    MessageBox.Show("The percentage must be less than or equal to 30", "Error", MessageBoxButton.OK);
                }
            }
        }

        public bool tryInputIntoDouble(string inputAmount)
        {
            try
            {
                double tryAmount = Convert.ToDouble(inputAmount);
                return true;
            }
            catch
            {
                string error = inputAmount;
                MessageBox.Show($"Value {error} is incorrect", "error", MessageBoxButton.OK);
                return false;
            }
        }
    }
}
