using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (resultTextBox.Text == "0" || (operation != "" && firstNumber != 0)) 
            {
                resultTextBox.Text = "";
            }
            resultTextBox.Text += button.Content;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            if (!string.IsNullOrEmpty(resultTextBox.Text) && resultTextBox.Text != ".")
            {
                firstNumber = double.Parse(resultTextBox.Text);
              
                resultTextBox.Text = "";
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(resultTextBox.Text) && resultTextBox.Text != "." && !string.IsNullOrEmpty(operation))
            {
                secondNumber = double.Parse(resultTextBox.Text);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "×":
                        result = firstNumber * secondNumber;
                        break;
                    case "÷":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            resultTextBox.Text = "Error";
                            return;
                        }
                        break;
                    case "%":
                        result = firstNumber % secondNumber;
                        break;
                }

                resultTextBox.Text = result.ToString();
                firstNumber = result;
                operation = "";
            }
        }


        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(resultTextBox.Text))
            {
                resultTextBox.Text = resultTextBox.Text.Substring(0, resultTextBox.Text.Length - 1);
                if (string.IsNullOrEmpty(resultTextBox.Text))
                {
                    resultTextBox.Text = "0";
                }
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultTextBox.Text.Contains("."))
            {
                resultTextBox.Text += ".";
            }
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
       
        }
    }
}