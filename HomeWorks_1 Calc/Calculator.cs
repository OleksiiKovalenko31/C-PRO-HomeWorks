using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks_1_Calc
{
    class Calculator
    {

       

      public static void operation(decimal number1, decimal number2, string? operation, out decimal result)
      {
            //if (string.IsNullOrEmpty(operation) || operation != "/" || operation != "*" || operation != "+" || operation != "-")
            //{
            //    Visualisator_calc.ShowError("Ошибка ввода. Пожалуйста, введите операцию.");
            //    result = 0;
            //    return;
            //}
            //else
            //{
                switch (operation)
                {

                    //case ConsoleKey.D1:
                    //case ConsoleKey.Add:
                    case "+":
                        result = Add(number1, number2);
                        break;
                    //case ConsoleKey.D2:
                    //case ConsoleKey.Subtract:
                    case "-":
                        result = Subtract(number1, number2);
                        break;
                    //case ConsoleKey.D3:
                    //case ConsoleKey.Multiply:
                    case "*":
                        result = Multiply(number1, number2);
                        break;
                    //case ConsoleKey.D4:
                    //case ConsoleKey.Divide:
                    case "/":
                        if (number2 == 0)
                        {
                            Visualisator_calc.ShowError("Ошибка. Деление на ноль невозможно.");
                            result = 0;
                        return;
                    }
                        result = Divide(number1, number2);
                        break;

                    default:
                        result = 0;
                        break;
                }


            //}
       }
            


        public static decimal Add(decimal a, decimal b)
        {
            return a + b;
        }
        public static decimal Subtract(decimal a, decimal b)
        {
            return a - b;
        }
        public static decimal Multiply(decimal a, decimal b)
        {
            return a * b;
        }
        public static decimal Divide(decimal a, decimal b)
        {
            if (b == 0 || a == 0)
                throw new DivideByZeroException("Нельзя делить на ноль.");
            return a / b;
        }
    }
    
}
