namespace HomeWork_2_3_Structures
{
    struct Program
    {
        static void Main() // я так розумію це не зовсім те що треба!
        {
            var symbol = 'a';
            var number = 10;

            string numbersystem8 =  Convert.ToString(number, 8);
            string numbersystem16 = Convert.ToString(number, 16);
            string numbersystem2 = DecToBin(number);          
            string symbolsystem2 = Convert.ToString(symbol, 2);

            Console.WriteLine($" символ  {number}  в двочиной системе - {numbersystem2}");
            Console.WriteLine($" число {number} в шестинаричной системе - {numbersystem16}");
            Console.WriteLine($" число {number} в восмеричной системе - {numbersystem8}");
            Console.WriteLine($" символ {symbol} в двочиной системе - {symbolsystem2}");



        }
        static string DecToBin(int n)
        {
            if (n == 0)    //базовый сценарий - выход из рекурсии 
                return "0";

            if (n / 2 > 0)
                return DecToBin(n / 2) + (char)(n % 2 + '0');
            else
                return "" + (char)(n % 2 + '0');
        }

    }
}
