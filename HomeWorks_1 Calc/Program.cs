using System;
using System.Text;

namespace HomeWorks_1_Calc
{
    internal class Program
    {
        static void Main()
        {
            

            //Calculator Simple_calculator = new Calculator();

            Visualisator_calc.StartMenu();
            Console.ReadLine();
            Console.Clear();
            while (true)
            {
                StringBuilder History = new StringBuilder();

                Visualisator_calc.Number(out decimal number1);
                History.Append($"Выражение: {number1} ");
                Console.Clear();
                Console.WriteLine(History);

                string? operation = Console.ReadLine();
                Console.Clear();

                History.Append($"{operation} ");
                Console.WriteLine(History);


                Visualisator_calc.Number(out decimal number2);
                History.AppendLine($"{number2} ");
                Console.Clear();
                Console.WriteLine(History);


                decimal result;
                Calculator.operation(number1, number2, operation, out result);
                Console.WriteLine($"Равно {result}");


                Console.WriteLine("Exit: 1 - Yes / 2 - No");

                int.TryParse((Console.ReadLine()), out int exit);

                if (exit == 1)

                { break; }

                else if (exit == 2)

                { Console.Clear(); continue; }

                else { Console.WriteLine("Incorrect format"); }
            }
        }
        
    }
}
