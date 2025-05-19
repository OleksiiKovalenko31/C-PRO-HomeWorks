using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_1_Money
{
    class Product
    {
        string nameModel;
        int inQuantity;
        decimal onePrice;

        public Product(string model, int quantity, decimal price)
        {
           nameModel = model;
          inQuantity = quantity;
          onePrice = price;
        }
        public string NameModel // Поле nameModel
        {
            get { return nameModel; }
            set { nameModel = value; }
        } 
        public int InQuantity // Поле inQuantity
        {
            get { return inQuantity; }
            set { inQuantity = value; }
        }
        public decimal OnePrice // Поле onePrice
        {
            get { return onePrice; }
            set { onePrice = value; }
        }

        public static decimal Cart(Product[] purchase)
        {
            decimal totalPrice = 0;

            Console.WriteLine("Select product and quantity");
            int i = 0;
            foreach (var item in purchase)
            {
                Console.WriteLine($"{++i} - {item.NameModel} - {item.OnePrice}$");
            }

            Console.Write("Enter the number of the product you want to buy: ");
            bool productNumberInput = int.TryParse(Console.ReadLine(), out int productNumber);
            
            if (!productNumberInput || productNumber < 0 || productNumber > purchase.Length)
            {
                Program.ErrorMesseng("Invalid input. Please enter a valid product number.");
            }
            Console.Write("Enter the quantity of the product you want to buy: ");

            bool quantityInput = int.TryParse(Console.ReadLine(), out int quatityInput);
            if (!quantityInput || quatityInput < 0)
            {
                Program.ErrorMesseng("Invalid input. Please enter a valid quantity.");
                totalPrice =0.0M;
                return totalPrice;
            }
            else
            {

                if (quatityInput > purchase[productNumber - 1].InQuantity)
                {
                    Console.WriteLine($"We do not have that many {purchase[productNumber - 1].NameModel} in stock");
                    return 0.00M;
                }
                else
                {
                    totalPrice = purchase[productNumber - 1].OnePrice * (decimal)quatityInput;

                    Console.WriteLine($"You selected {purchase[productNumber - 1].NameModel} in quantity of {quatityInput} pcs for the total cost of {totalPrice}$");

                    return totalPrice;
                }
            }

        } // Метод Cart для выбора товара для покупок
    }
}
