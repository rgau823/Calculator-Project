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
using System.Diagnostics;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double number1 = 0;
        double number2 = 0;
        string operation = "";
        string input = "";
        bool newNumber = false;
        Stack<double> numbers = new Stack<double>();
        Stack<char> operators = new Stack<char>();

        public MainWindow()
        {
            InitializeComponent();
            operators.Push('#');
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 1;
            display.Text = number1.ToString();
            newNumber = true;

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 2;
            display.Text = number1.ToString();
            newNumber = true;

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 3;
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 4;
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 5;
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 6;
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 7;
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 8;
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10) + 9;
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (!newNumber) number1 = 0;
            number1 = (number1 * 10);
            display.Text = number1.ToString();
            newNumber = true;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                numbers.Push(number1);
                input = input + number1.ToString() + "+";
            }
            else
            {
                input = input + "+";
            }
            

            while (operators.Peek() == '*' || operators.Peek() == '/' || operators.Peek() == '^')
            {
                if (operators.Peek() == '*')
                {
                    number1 = numbers.Pop();
                    number2 = numbers.Pop();
                    numbers.Push(number1 * number2);
                    Console.WriteLine(numbers.Peek());
                    operators.Pop();
                }
                else if (operators.Peek() == '/')
                {
                    number1 = numbers.Pop();
                    number2 = numbers.Pop();
                    numbers.Push(number1 / number2);
                    Console.WriteLine(numbers.Peek());
                    operators.Pop();
                }
                else
                {
                    number1 = numbers.Pop();
                    number2 = numbers.Pop();
                    numbers.Push(Math.Pow(number2, number1));
                }
            }
            operators.Push('+');
            display.Text = "0";
            newNumber = false;
            history.Text = input;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                numbers.Push(number1);
                input = input + number1.ToString() + "-";
            }
            else
            {
                input = input + "-";
            }

            while (operators.Peek() == '*' || operators.Peek() == '/' || operators.Peek() == '^')
            {
                if (operators.Peek() == '*')
                {
                    number1 = numbers.Pop();
                    number2 = numbers.Pop();
                    numbers.Push(number1 * number2);
                    Console.WriteLine(numbers.Peek());
                    operators.Pop();
                }
                else if (operators.Peek() == '/')
                {
                    number1 = numbers.Pop();
                    number2 = numbers.Pop();
                    numbers.Push(number1 / number2);
                    Console.WriteLine(numbers.Peek());
                    operators.Pop();
                }
                else
                {
                    number1 = numbers.Pop();
                    number2 = numbers.Pop();
                    numbers.Push(Math.Pow(number2, number1));
                }
            }
            operators.Push('-');
            display.Text = "0";
            newNumber = false;
            history.Text = input;
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                numbers.Push(number1);
                input = input + number1.ToString() + "*";
            }
            else
            {
                input = input + "*";
            }

            if (operators.Peek() == '^')
            {
                number1 = numbers.Pop();
                number2 = numbers.Pop();
                numbers.Push(Math.Pow(number2, number1));
            }
            operators.Push('*');
            newNumber = false;
            display.Text = "0";
            history.Text = input;
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                numbers.Push(number1);
                input = input + number1.ToString() + "/";
            }
            else
            {
                input = input + "/";
            }

            if (operators.Peek() == '^')
            {
                number1 = numbers.Pop();
                number2 = numbers.Pop();
                numbers.Push(Math.Pow(number2, number1));
            }
            operators.Push('/');
            numbers.Push(number1);
            newNumber = false;
            display.Text = "0";
            history.Text = input;
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                numbers.Push(number1);
                input = input + number1.ToString() + "%";
            }
            else
            {
                input = input + "%";
            }
            if (operators.Peek() == '^')
            {
                number1 = numbers.Pop();
                number2 = numbers.Pop();
                numbers.Push(Math.Pow(number2, number1));
            }
            operators.Push('%');
            display.Text = "0";
            newNumber = false;
            history.Text = input;
        }

        private void btnPlsNeg_Click(object sender, RoutedEventArgs e)
        {
            number1 = (number1 * -1);
            display.Text = number1.ToString();

        }

        private void btnExp_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                numbers.Push(number1);
                input = input + number1.ToString() + "^";
            }
            else
            {
                input = input + "^";
            }
            operators.Push('^');
            display.Text = "0";
            newNumber = false;
            history.Text = input;
        }

        private void btnEq_Click(object sender, RoutedEventArgs e)
        {
            if (newNumber)
            {
                numbers.Push(number1);
            }
            if(numbers.Count + 1 <= operators.Count)
            {
                display.Text = "Error!";
                numbers.Clear();
                operators.Clear();
                number1 = 0;
                return;
            }
            char op = '#';
            while(operators.Peek() != '#')
            {
                op = operators.Pop();
                number1 = numbers.Pop();
                number2 = numbers.Pop();
                Trace.WriteLine("New operation: ");
                Trace.WriteLine(op);
                Trace.WriteLine(number1.ToString());
                Trace.WriteLine(number2.ToString());
                
                switch (op)
                {
                    case '+':
                        numbers.Push(number1 + number2);
                        break;
                    case '-':
                        numbers.Push((-1*number1) + number2);
                        break;
                    case '*':
                        numbers.Push(number1 * number2);
                        break;
                    case '/':
                        numbers.Push((1/number1) * number2);
                        break;
                    case '^':
                        numbers.Push(Math.Pow(number2, number1));
                        break;
                }
            }
            if (operators.Peek() == '#' && op != '#')
            {

            }
            if(input[input.Length - 1] != ')')
            {
                input = input + number1.ToString();
            }
            input = input + "=";
            display.Text = numbers.Peek().ToString();
            number1 = numbers.Pop();
            newNumber = false;
            history.Text = input;
            input = "";
        }

        private void btnLB_Click(object sender, RoutedEventArgs e)
        {
            
            if (newNumber)
            {
                operators.Push('*');
                numbers.Push(number1);
                input = input + number1.ToString() + "*";
            } 
            input = input + "(";
            operators.Push('(');
            newNumber = false;
            display.Text = number1.ToString();
            history.Text = input;
        }

        private void btnRB_Click(object sender, RoutedEventArgs e)
        {
            numbers.Push(number1);
            while (operators.Peek() != '(')
            {
                char op = operators.Pop();
                number1 = numbers.Pop();
                number2 = numbers.Pop();
                Trace.WriteLine("New operation: ");
                Trace.WriteLine(op);
                Trace.WriteLine(number1.ToString());
                Trace.WriteLine(number2.ToString());

                switch (op)
                {
                    case '+':
                        numbers.Push(number1 + number2);
                        break;
                    case '-':
                        numbers.Push(number2 - number1);
                        break;
                    case '*':
                        numbers.Push(number1 * number2);
                        break;
                    case '/':
                        numbers.Push(number2 / number1);
                        break;
                    case '^':
                        numbers.Push(Math.Pow(number2, number1));
                        break;
                }
            }
            input = input + number1.ToString()+ ")";
            newNumber = false;
            operators.Pop();
            history.Text = input;
            
        }
    }
}
