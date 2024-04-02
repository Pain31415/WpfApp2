using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private double? firstNumber = null;
        private double? secondNumber = null;
        private string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (operation == "")
            {
                // Зберігаємо перше число, 
                // множимо його на 10 
                // і додаємо нову цифру
                firstNumber = (firstNumber ?? 0) * 10 + double.Parse(number);
                txtDisplay.Text = firstNumber.ToString();
            }
            else
            {
                // Зберігаємо друге число, 
                // множимо його на 10 
                // і додаємо нову цифру
                secondNumber = (secondNumber ?? 0) * 10 + double.Parse(number);
                txtDisplay.Text = secondNumber.ToString();
            }
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                if (operation == "")
                {
                    // Додаємо десяткову крапку до першого числа
                    firstNumber = double.Parse(txtDisplay.Text + ".");
                }
                else
                {
                    // Додаємо десяткову крапку до другого числа
                    secondNumber = double.Parse(txtDisplay.Text + ".");
                }

                txtDisplay.Text += ".";
            }
        }

        private void BtnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                // Змінюємо знак першого числа
                firstNumber = -(firstNumber ?? 0);
            }
            else
            {
                // Змінюємо знак другого числа
                secondNumber = -(secondNumber ?? 0);
            }

            txtDisplay.Text = (operation == "" ? firstNumber : secondNumber).ToString();
        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();

            if (operation != "=")
            {
                secondNumber = null;
            }
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;

            if (firstNumber != null && secondNumber != null)
            {
                switch (operation)
                {
                    case "+":
                        result = firstNumber.Value + secondNumber.Value;
                        break;
                    case "-":
                        result = firstNumber.Value - secondNumber.Value;
                        break;
                    case "*":
                        result = firstNumber.Value * secondNumber.Value;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Ділення на нуль неможливе!");
                            return;
                        }

                        result = firstNumber.Value / secondNumber.Value;
                        break;
                }

                txtDisplay.Text = result.ToString();
                firstNumber = result;
                secondNumber = null;
                operation = "";
            }
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            secondNumber = null;
            txtDisplay.Text = (firstNumber ?? 0).ToString();
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = null;
            secondNumber = null;
            operation = "";
            txtDisplay.Text = "";
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.D0 || e.Key == System.Windows.Input.Key.NumPad0)
            {
                BtnNumber_Click(btn0, null);
            }
            else if (e.Key == System.Windows.Input.Key.D1 || e.Key == System.Windows.Input.Key.NumPad1)
            {
                BtnNumber_Click(btn1, null);
            }
            else if (e.Key == System.Windows.Input.Key.D2 || e.Key == System.Windows.Input.Key.NumPad2)
            {
                BtnNumber_Click(btn2, null);
            }
            else if (e.Key == System.Windows.Input.Key.D3 || e.Key == System.Windows.Input.Key.NumPad3)
            {
                BtnNumber_Click(btn3, null);
            }
            // Add similar cases for other numbers if needed
        }
    }
}