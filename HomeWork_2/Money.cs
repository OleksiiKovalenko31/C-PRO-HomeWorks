using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_1_Money
{
    class Money
    {
        private int _dollars;
        private int _cents;
       


        private int Dollars
        {
            get { return _dollars; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Dollars cannot be negative");
                _dollars = value;
            }
        } // Поле _dollars

        private int Cents
        {
            get { return _cents; }
            set { _cents = value; }
        } // Поле _cents

        public Money(int dollars, int cents, out decimal _bankAccount) // Конструктор 
        {

          
            {
                Dollars = dollars;
                Cents = cents; 
                _bankAccount = (decimal)_dollars + (decimal)_cents / 100;

            }
        }
        public void  MoneyShow ()
        {
           
            Console.WriteLine($"On your account {Dollars}.{Cents}$");
            Console.WriteLine("--------------------------------------");
        } // Метод MoneyShow  вывод на экран

        public void NewAccount()
        {
            Console.WriteLine("Welcome to the bank creation account!");
            Console.WriteLine("Please enter the amount of money you want to deposit in your account: ");

            Console.Write("Enter the amount of money in dollars: ");
            bool dollarsInput = int.TryParse(Console.ReadLine(), out _dollars);
            if (!dollarsInput || _dollars < 0)
            {
                Console.WriteLine("Invalid input, the default value will be set 10000.");
                _dollars = 10000;
            }
            else if (_dollars < 0)
            {
                Console.WriteLine("Dollars cannot be negative, the default value will be set 10000");
                _dollars = 10000;
            }

            Console.Write("Enter the amount of money in cents: ");
            int _centsInput;
            bool centsInput = int.TryParse(Console.ReadLine(), out _centsInput);
            if (!centsInput || _cents < 0)
            {
                Console.WriteLine("Invalid input, the default value will be set 99.");
                _centsInput = 99;
            }
            else if (_cents < 0)
            {
                Console.WriteLine("Cents cannot be negative, the default value will be set 99");
                _centsInput = 99;
            }


            if (_centsInput >= 100)
            {

                _dollars += _centsInput / 100;
                _cents += _centsInput - (_centsInput /100)*100 ;
            }
            else if (_cents < 0)
            {
                Console.WriteLine("Dollars cannot be negative");
                _cents = 0;
            }
            else
            {
                _cents = _centsInput;
            }
        } // Создание аккаунта 

        public void MinusMoney(decimal bpurchaseAmount) // Метод MinusMoney снятие  денег со счета
        {
            decimal _bankAccount = (decimal)Dollars + (decimal)Cents / 100;
          

            if (bpurchaseAmount > _bankAccount)
            {
                Program.ErrorMesseng("Not enough money on the account");

            }
            else
            {

                if ((int)((bpurchaseAmount - Math.Truncate(bpurchaseAmount)) * 100) > Cents)
                {

                    Dollars -= 1; // Снимаем 1 доллар
                    Cents = 100 + Cents - (int)((bpurchaseAmount - Math.Truncate(bpurchaseAmount)) * 100);
                }
                else if ((int)((bpurchaseAmount - Math.Truncate(bpurchaseAmount)) * 100) == 0)
                {
                    Cents = Cents + 0;
                }
                else
                {
                    Cents -= (int)((bpurchaseAmount - Math.Truncate(bpurchaseAmount)) * 100);

                }


                if (Dollars < 0) // Проверка на то, что на счету достаточно денег
                {
                    Program.ErrorMesseng("Not enough money on the account");
                }
                else { Dollars -= (int)Math.Truncate(bpurchaseAmount); }


            } /*else { Program.ErrorMesseng("Not enough money on the account"); }*/


        }
    }
}
