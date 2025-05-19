using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace HomeWork_2_1_Money
{
    internal class Program
    {
        //Money Bank_account = new Money(100, 56);
        static void Main()
        {
            int dollar = 0;
            int cents = 0;
            decimal totalPrice = 0;
            //decimal bankAccount;


            Money Bank_account = new Money(dollar, cents, out decimal bankAccount);

            Bank_account.NewAccount();


            Bank_account.MoneyShow();

            Product Laptop = new Product("Lenovo", 5, 1100.52M);
            Product Phone = new Product("Iphone", 10, 500.45M);
            Product Tablet = new Product("Samsung", 2, 300.78M);

            Product[] products = { Laptop, Phone, Tablet };
            while (true)
            {
                totalPrice = Product.Cart(products);

                Bank_account.MinusMoney(totalPrice);

                Bank_account.MoneyShow();
                Console.Write("Exit: 1 - Yes / 2 - No ");

                int.TryParse((Console.ReadLine()), out int exit);

                if (exit == 1)
                { break; }

                else if (exit == 2)
                { continue; }

                else 
                { Console.WriteLine("Incorrect format"); }

            }
        }
      

        public static void ErrorMesseng (string Msg) 
        {
           Console.WriteLine($"{Msg}") ;
           Console.ReadLine();
          
        }

    }
}
