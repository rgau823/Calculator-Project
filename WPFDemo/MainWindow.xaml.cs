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

        double currNumb = 0;
        string operation = "";
        string input = "";
        char lastPressed; //Used to check for illegal inputs (i.e. two operators in a row or an illegal combination)
        Stack<double> numbers = new Stack<double>();
        Stack<char> operators = new Stack<char>();

        public MainWindow()
        {
            InitializeComponent();
            operators.Push('#');
        }

        //Input number buttons
        //The numbers must grow with button inputs
        private void inputNumb(int number) {
            currNumb =  currNumb * 10) + number;
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(1);
            display.Text =  currNumb.ToString();


        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(2);
            display.Text =  currNumb.ToString();

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(3);
            display.Text =  currNumb.ToString();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(4);
            display.Text =  currNumb.ToString();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(5);
            display.Text =  currNumb.ToString();
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(6);
            display.Text =  currNumb.ToString();
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(7);
            display.Text =  currNumb.ToString();
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(8);
            display.Text =  currNumb.ToString();
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(9);
            display.Text =  currNumb.ToString();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            inputNumb(0);
            display.Text =  currNumb.ToString();
        }

        private void operatorPush (char op) 
        {
            numbers.Push(currNumb);
            input = input + currNumb.ToString() + op;
            operators.Push(op);
            display.Text = "0";

            history.Text = input;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            System.Console.WriteLine("Hello world!");
            operatorPush('+');
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            operatorPush('-');
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            operatorPush('*');
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            operatorPush('/');
        }

        private void btnMod_Click(object sender, RoutedEventArgs e)
        {
            operatorPush('%');
        }

        private void btnPlsNeg_Click(object sender, RoutedEventArgs e)
        {
            currNumb *= -1;
            display.Text = currNumb.ToString();
        }

        private void btnExp_Click(object sender, RoutedEventArgs e)
        {
            operatorPush('^');
        }

        private void bracketCalc()
        {

        }

        private void addSubCalc()
        {
            
            double num1;
            double num2;

            if ((operators.Peek() == '*') || (operators.Peek() == '/')|| (operators.Peek() == '%'))
            {
                num1 = numbers.Pop();
                multDivModCalc();
            } 
            else if ((operators.Peek() == '^')) 
            {
                num1 = numbers.Pop();
                expCalc();
            } 
            else 
            {
                num1 = numbers.Pop();
                num2 = numbers.Pop();
            }
            if (operators.Peek() == '+')
            {
                numbers.Push(num1 + num2);
            }
            else 
            {
                numbers.Push(num1 - num2);
            }
            
        }

        private void multDivModCalc() 
        {
            double num1;
            double num2;
            if (operators.Peek() == '^')
            {
                expCalc();
            }
            else 
            {
                num1 = numbers.Pop();
                num2 = numbers.Pop();
                if (operators.Peek() == '*')
                {
                    numbers.Push(num1 * num2);
                }
                else if (operators.Peek() == '/')
                {
                    numbers.Push(num1 / num2);
                }
                else if  (operators.Peek() == '%')
                {
                    numbers.Push(num1 % num2);
                }
            }
        }

        private void expCalc() 
        {
            double num1 = numbers.Pop();
            double num2 = numbers.Pop();
            numbers.Push(Math.Pow(num1, num2));
        }

        private void btnEq_Click(object sender, RoutedEventArgs e)
        /*
        Calculation will occur until no operators remain on operator stack.
        */
        {
            while (operators.Count > 0)
            {
                if (operators.Peek() == ')') 
                {
                    bracketCalc(); 
                }
                if ((operators.Peek() == '+') ||  (operators.Peek() == '-')
                {
                    addSubCalc();
                }
                else if ((operators.Peek() == '*') || (operators.Peek() == '/') || (operators.Peek() == '%'))
                {
                    multDivModCalc();
                }
                else
                {
                    expCalc();
                }

            }
        }

        private void btnLB_Click(object sender, RoutedEventArgs e)
        {
            operators.Push('(');

        }

        private void btnRB_Click(object sender, RoutedEventArgs e)
        {
            operators.Push(')');
        }

    }
}
