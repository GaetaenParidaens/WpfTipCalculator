using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TipCalculator.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
			if (tryInputIntoDouble(TextBoxAmount.Text) == true && tryInputIntoDouble(TextBoxPercentage.Text) == true )
			{
				double amount = Convert.ToDouble(TextBoxAmount.Text);
				double percent = Convert.ToDouble(TextBoxPercentage.Text);
				double totalTip = (amount / 100) * percent;
				double totalAmount = amount - totalTip;

				if (percent <= 30)
				{
					TextBoxTipAmount.Content = totalTip;
					TextBoxTotalAmount.Content = totalAmount;
				}
				else
				{
					MessageBox.Show("Percent is groter dan 30", "Error", MessageBoxButton.OK); 
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
