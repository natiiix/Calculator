using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Infinite loop so that the calculator can be re-used
            while (true)
            {
                SolveProblem(GetProblem());
            }
        }

        private static string[] GetProblem()
        {
            // Tell the user to write their problem
            Console.Write("Enter your problem: ");
            // Read the problem from the console
            string strProblem = Console.ReadLine();
            // Separate different parts of the problem and return them
            return strProblem.Split(' ');
        }

        private static void SolveProblem(string[] parts)
        {
            // Incorrect problem syntax
            // There are supposed to be 3 parts (2 numbers and an operator)
            if (parts.Length != 3)
            {
                Console.WriteLine("Incorrect problem syntax!");
                Console.WriteLine("Correct syntax: <First Number>{space}<Operator>{space}<Second Number>");
                return;
            }

            // Try to parse the first number
            if (!double.TryParse(parts[0], out double num1))
            {
                Console.WriteLine("The first number ({0}) is invalid!", parts[0]);
                return;
            }

            // Try to parse the second number
            if (!double.TryParse(parts[2], out double num2))
            {
                Console.WriteLine("The second number ({0}) is invalid!", parts[2]);
                return;
            }

            double result = 0.0;

            // Perform the operation
            switch (parts[1])
            {
                // Addition
                case "+":
                    result = num1 + num2;
                    break;

                // Subtraction
                case "-":
                    result = num1 - num2;
                    break;

                // Multiplication
                case "*":
                    result = num1 * num2;
                    break;

                // Division
                case "/":
                    // Test for division by zero
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero!");
                        return;
                    }

                    result = num1 / num2;
                    break;

                // Invalid operator
                default:
                    Console.WriteLine("Invalid operator ({0})!", parts[1]);
                    return;
            }
            
            // Write the result value
            Console.WriteLine("Result: " + result.ToString());
        }
    }
}
