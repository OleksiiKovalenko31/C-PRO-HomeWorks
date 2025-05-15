using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks_1_Calc
{
    class Visualisator_calc
    {
        
        public static void StartMenu()
        {
            Console.WriteLine("Добро пожаловать в простой калькулятор!");
            Console.WriteLine("Возможные действиядля выполния:");

            Console.WriteLine("1. Сложение '+'");
            Console.WriteLine("2. Вычитание '-'");
            Console.WriteLine("3. Умножение '*'");
            Console.WriteLine("4. Деление '/'");
            Console.WriteLine("5. При не корректных даных занчение будет '0' ");

            Console.WriteLine();

        }

        public static void Number (out decimal result)
        {
            //try { 
            Console.Write("Введите число:  ");
            string? isNumber1 = Console.ReadLine();
            bool input1 = decimal.TryParse(isNumber1, out decimal number);

            if (!input1 || string.IsNullOrEmpty(isNumber1))
            {
              ShowError ("Ошибка ввода. Пожалуйста, введите число.");

            }
            
                result = number;
            return;
        }
//            catch (Exception ex)
//            {
//                ShowError(ex.Message);
//                 result = 0;
//            }
//}

        public static void ShowError(string error)
        {
            Console.WriteLine($"Ошибка: {error} значение будет '0'");
            Console.ReadLine();
        }
    }


}
