using System.Text.RegularExpressions;

namespace Calculator;

internal static class SimpleCalculator
{

    public static void Main()
    {
        var inputExpression = Console.ReadLine();
        if (inputExpression == null) return;
        const string pattern = @"^\d*,?\d+\s[\+|\-|\*|\/]\s\d*,?\d+$";
        if (!Regex.IsMatch(inputExpression, pattern))
        {
            Console.WriteLine("Wrong input!"); 
            return;
        }
        var expression = new Expression(inputExpression);
        var result = expression.Calculate();
        Console.WriteLine("Result: " + result);

    }
}

public class Expression
{
    private readonly double _a;
    private readonly double _b;
    private readonly char _operation;

    public Expression(string input)
    {
        var parsedInput = input.Split();
        _a = Convert.ToDouble(parsedInput[0]);
        _b = Convert.ToDouble(parsedInput[2]);
        _operation = Convert.ToChar(parsedInput[1]);
    }

    public double Calculate()
    {
        var result = double.NaN;
        if (_operation == '/' && _b == 0)
        {
            Console.WriteLine("Dividing by 0!");
        }
        else
        {
            result = _operation switch
            {
                '+' => _a + _b,
                '-' => _a - _b,
                '*' => _a * _b,
                '/' => _a / _b,
                _ => double.NaN
            };
        }
        
        return result;
    }
}

