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

        decimal currNumb = 0;
        string input = "";
        char lastPressed = 'c'; //Used to check for illegal inputs (i.e. two operators in a row or an illegal combination)
        bool dec = false;
        int decPlace = 0;

        Stack<Stack<decimal>> numberStack = new Stack<Stack<decimal>>();

        Stack<Stack<char>> operatorStack = new Stack<Stack<char>>();

        Stack<decimal> numbers;
        Stack<char> operators;

        

        public MainWindow()
        {
            initializeStack();
            InitializeComponent();
        }

        private void initializeStack() {
            Stack<decimal> firstStackNumbers = new Stack<decimal>();
            Stack<char> firstStackOperators = new Stack<char>();
            numbers = firstStackNumbers;
            operators = firstStackOperators;
        }

        //Input number buttons
        //The numbers must grow with button inputs
        private void inputNumb(int number) 
        {
            if (lastPressed == '=')
            {
                resetCalc();
            }
            if (dec)
            {
                decPlace++;
                double prec = (number * Math.Pow(10, decPlace * -1));
                currNumb = currNumb + (decimal) prec;

            } 
            else 
            {
                currNumb = (currNumb * 10) + number;
                lastPressed = 'N';
            }
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
            if (dec) 
            {
                dec = false;
                decPlace = 0;
            }
            if (lastPressed != ')'){
                numbers.Push(currNumb);
                input = input + currNumb.ToString() + op;
            } else {
                input = input + op;
            }
            operators.Push(op);
            currNumb = 0;
            display.Text = "0";
            history.Text = input;
            lastPressed = 'O';
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
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


        private void addSubCalc()
        {
            System.Console.WriteLine("Doing addition");
            decimal num1;
            decimal num2;
            char currOp = operators.Pop();
            num1 = numbers.Pop();
            if (operators.Count() != 0) {
                if ((operators.Peek() == '*') || (operators.Peek() == '/') || (operators.Peek() == '%'))
                {
                    multDivModCalc();
                } 
                else if (operators.Peek() == '^')
                {
                    expCalc();
                } 
            }
            
            num2 = numbers.Pop();
            System.Console.WriteLine("Calculating " + num1 + " " + currOp + " " + num2);
            
            if (currOp == '+')
            {
                numbers.Push(num1 + num2);
            }
            else 
            {
                numbers.Push(num2 - num1);
            }
            System.Console.WriteLine("Result: " + numbers.Peek());
            System.Console.WriteLine("Operator: " + operators.Count());
            
        }

        private void multDivModCalc() 
        {
            System.Console.WriteLine("Doing multiplication");
            decimal num1;
            decimal num2;
            char currOp = operators.Pop();
            num1 = numbers.Pop();
            if (currOp == '^')
            {
                expCalc();
            }

            num2 = numbers.Pop();
            System.Console.WriteLine("Calculating " + num1 + " " + currOp + " " + num2);
            
            if (currOp == '*')
            {
                numbers.Push(num1 * num2);
            }
            else if (currOp == '/')
            {
                numbers.Push(num2 / num1);
            }
            else 
            {
                numbers.Push(num2 % num1);
            }
            System.Console.WriteLine("Result: " + numbers.Peek());
            System.Console.WriteLine("Operator: " + operators.Count());

        }

        private void expCalc() 
        {
            System.Console.WriteLine("Doing exponent");
            double num1 = (double)numbers.Pop();
            double num2 = (double)numbers.Pop();
            double exp = Math.Pow(num2, num1);
            numbers.Push((decimal)exp);
            operators.Pop();
        }

        private void btnEq_Click(object sender, RoutedEventArgs e)
        /*
        Calculation will occur until no operators remain on operator stack.
        Output will be final calculation
        */
        {
            if (lastPressed != ')') {
                numbers.Push(currNumb);
                input = input + currNumb.ToString();
                history.Text = input;
            }

            while (operators.Count > 0)
            {
                System.Console.WriteLine("Number of numbers on stack: " + numbers.Count());
                System.Console.WriteLine("Number of operators on stack: " + operators.Count() + " Top: " + operators.Peek());
                if ((operators.Peek() == '+') ||  (operators.Peek() == '-'))
                {
                    addSubCalc();
                }
                else if ((operators.Peek() == '*') || (operators.Peek() == '/') || (operators.Peek() == '%'))
                {
                    multDivModCalc();
                }
                else if (operators.Peek() == '^')
                {
                    expCalc();
                }

            }
            currNumb = numbers.Pop();
            display.Text = currNumb.ToString();
            lastPressed = '=';
        }

        private void btnLB_Click(object sender, RoutedEventArgs e)
        {
            input = input + '(';
            Stack<decimal> nextStackNumbers = new Stack<decimal>();
            Stack<char> nextStackOperators = new Stack<char>();
            numberStack.Push(nextStackNumbers);
            operatorStack.Push(nextStackOperators);
            numbers = nextStackNumbers;
            operators = nextStackOperators;
            currNumb = 0;
            display.Text = "0";
            history.Text = input;
            lastPressed = '(';
            System.Console.WriteLine("Size of stacks: numbers: " + numberStack.Count() + " operators: " + operatorStack.Count());

        }

        private void btnRB_Click(object sender, RoutedEventArgs e)
        {
            numbers.Push(currNumb);
            input = input + currNumb.ToString();
            input = input + ')';
            history.Text = input;
            
            while (operators.Count > 0)
            {
                System.Console.WriteLine("Number of numbers on stack: " + numbers.Count());
                System.Console.WriteLine("Number of operators on stack: " + operators.Count());
                if ((operators.Peek() == '+') ||  (operators.Peek() == '-'))
                {
                    addSubCalc();
                }
                else if ((operators.Peek() == '*') || (operators.Peek() == '/') || (operators.Peek() == '%'))
                {
                    multDivModCalc();
                }
                else if (operators.Peek() == '^')
                {
                    expCalc();
                }

            }
            decimal bracketResult = numbers.Pop();
            numbers = numberStack.Pop();
            numbers.Push(bracketResult);
            operators = operatorStack.Pop();

            currNumb = 0;
            display.Text = "0";
            history.Text = input;
            lastPressed = ')';
            System.Console.WriteLine("Size of stacks: numbers: " + numberStack.Count() + " operators: " + operatorStack.Count());
            System.Console.WriteLine("Current number on stack " + numbers.Peek());
        }

        private void btnC_Click(object sender, RoutedEventArgs e) 
        {
            resetCalc();
        }

        private void resetCalc() {
            initializeStack();
            currNumb = 0;
            history.Text ="";
            display.Text = "0";
            input = "";
            lastPressed = 'C';
            if (dec)
            {
                dec = false;
                decPlace = 0;
            }
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            if (lastPressed == 'N')
            {
                currNumb = 0;
                display.Text = "0";
            }
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            dec = true;
            input = input + '.';
            lastPressed = '.';
        }

        private void btnDel_Click(object sender, RoutedEventArgs e) 
        {

            if (lastPressed == 'N')
            {
                if (dec)
                {

                }
                else
                {
                    currNumb = (currNumb - (currNumb % 10))/10;
                    display.Text = currNumb.ToString();
                }
            }
            if (lastPressed == 'O')
            {
                operators.Pop();
                history.Text = history.Text.Substring(0, history.Text.Length-2);
            }
        }

    }
}
