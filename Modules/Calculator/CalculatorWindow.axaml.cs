using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PiGadget.Modules.Calculator
{
    public partial class CalculatorWindow : Window
    {
        public CalculatorWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var content = button.Content?.ToString();
                if (!string.IsNullOrEmpty(content))
                {
                    Display.Text += content;
                }
            }
        }
        private void OnClearClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Display.Text = string.Empty;
        }
        private void OnDeleteClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Display.Text))
            {
                Display.Text = Display.Text[..^1]; // Remove last character
            }
        }
        private void OnCloseClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
        private void OnEqualsClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                var token = Tokenize(Display.Text ?? string.Empty);
                var postfix = ToPostfix(token);
                double result = EvaluatePostfix(postfix);

                Display.Text = result.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Display.Text = "Error";
                Console.WriteLine(ex.Message);
            }
        }

        static List<string> Tokenize(string expression)
        {
            List<string> tokens = new List<string>();
            StringBuilder currentToken = new StringBuilder();

            foreach (char c in expression)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    currentToken.Append(c);
                }
                else if (char.IsLetter(c))
                {
                    continue;
                }
                else
                {
                    if (currentToken.Length > 0)
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                    tokens.Add(c.ToString());
                }
            }
            if (currentToken.Length > 0)
            {
                tokens.Add(currentToken.ToString());
            }
            return tokens;
        }
        static List<string> ToPostfix(List<string> tokens)
        {
            List<string> output = new List<string>();
            Stack<string> operatorStack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    // If number -> Output
                    output.Add(token);
                }
                else if (token == "(")
                {
                    operatorStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        output.Add(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0)
                    {
                        operatorStack.Pop(); // Pop the "("
                    }
                }
                else if (IsOperator(token))
                {
                    while (operatorStack.Count > 0 && Precedence(operatorStack.Peek()) >= Precedence(token))
                    {
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
            }

            while (operatorStack.Count > 0)
            {
                output.Add(operatorStack.Pop());
            }
            return output;
        }
        static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        static int Precedence(string op)
        {
            return op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                _ => 0,
            };
        }

        private double EvaluatePostfix(List<string> postfix)
        {
            Stack<double> values = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double num))
                {
                    values.Push(num);
                }
                else if (IsOperator(token))
                {
                    double right = values.Pop();
                    double left = values.Pop();
                    double result = token switch
                    {
                        "+" => left + right,
                        "-" => left - right,
                        "*" => left * right,
                        "/" => left / right,
                        _ => throw new InvalidOperationException("Invalid operator"),
                    };
                    values.Push(result);
                }
            }   

            return values.Pop();
        }
    }
}