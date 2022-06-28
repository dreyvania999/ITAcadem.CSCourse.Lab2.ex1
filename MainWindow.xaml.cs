using System;
using System.Windows;

namespace ITAcadem.CSCourse.Lab1.ex1
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
        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            double number;
            if (!double.TryParse(inputText.Text, out number))
            {
                MessageBox.Show("Пожалуйста, введите число типа double(Пример: 12,233 или 33)");
                return;
            }

            if (number <= 0)
            {
                MessageBox.Show("Введите положительное число");
                return;
            }

            double square = Math.Sqrt(number);

            frameworkLabel.Content = string.Format(square + " (При использовании .NET Framework)");

            decimal numberDecimal;
            if (!decimal.TryParse(inputText.Text, out numberDecimal))
            {
                MessageBox.Show("Пожалуйста, введите десятичную дробь");
                return;
            }


            decimal delta = Convert.ToDecimal(Math.Pow(10, -28));
            decimal guess = numberDecimal / 2;
            decimal result = ((numberDecimal / guess) + guess) / 2;


            while (Math.Abs(result - guess) > delta)
            {
                guess = result;
                result = ((numberDecimal / guess) + guess) / 2;
            }
            newtonLabel.Content = string.Format(result + "(При использовании Newton)");
        }

    }
}
