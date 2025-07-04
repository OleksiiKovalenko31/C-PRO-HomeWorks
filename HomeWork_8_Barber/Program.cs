using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork_8_Barber

{
    internal class Program
    {
        static void Main()
        {


            //for (int i = 0; i < 5; i++)
            //{
            //    Klient klient = new Klient(i);
            //}

            Barber barber = new Barber(1);


        }
        internal static void Fibonacсi(int x, int y, int counter)
        {

            int sum;

            sum = x + y;
            y = x;
            x = sum;

            counter = ++counter;

            //Console.Write($"{sum}, ");

            if (counter == 40)
            // Recursive call to ProcessSimulation with updated values
            {
                Console.WriteLine($"Barber працює (Fibonacсi)");
                //Console.WriteLine($"Counter reached {counter}, stopping recursion, last nimeric {sum}.");
                return;
            }
            else
            {
                Fibonacсi(x, y, counter);
            }


        }

        internal static void PrimeNumbers(int start, int end, int counter = 0)
        {
            //Console.Write("Введите конец диапазона от 2 до : ");
            //int end = int.Parse(Console.ReadLine());
            for (int i = start; i <= end; i++)
            {
                bool b = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0 & i % 1 == 0)
                    {
                        b = false;
                    }
                }
                if (b)
                {
                    counter++;
                    Console.Write($"{i} ");
                }
            }
            //Console.WriteLine($"к-ть простих чисел {counter}");
            Console.WriteLine($"Barber працює (PrimeNumbers)");
            //return ;
        }

        internal static void PowerOfNmber(int x, int y, int counter)
        {
            int result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }
            counter++;
            //Console.WriteLine($"Результат піднесення {x} до степеня {y} дорівнює {result}. Кількість операцій: {counter}");
            if (counter < 20)
            {
                PowerOfNmber(x, y + 1, counter);
            }
            else
            {
                //Console.WriteLine($"Результат піднесення {x} до степеня {y} дорівнює {result}\nДосягнуто ліміт операцій: {counter}");
                Console.WriteLine($"Barber працює (PowerOfNmber)");
                return;
            }
        }
    }

    internal class Klient
    {
        Semaphore semaphoreKlient = new Semaphore(1, 3);
        Semaphore semaphoreBarber = new Semaphore(1, 1);
        Thread barberThread;
        Thread klientThread;
        int counter = 2;

        public Klient(int name)
        {
            barberThread = new Thread(BarberWork);
            barberThread.Name = $"Барбер {name}";

            klientThread = new Thread(KlientWork);
            klientThread.Name = $"Клієнт {name}";
            klientThread.Start();
        }
        internal void KlientWork()
        {
            Console.WriteLine($"{klientThread.Name} зайшов в барбершоп.");
            Console.WriteLine($"{klientThread.Name}  очікує обслуговування.");
            semaphoreKlient.WaitOne();  // Очікування доступу до семафора клієнта
            semaphoreBarber.WaitOne(); // Очікування доступу до семафора барбера
            //barberThread.Start(); // Запуск потоку барбера, якщо він ще не запущений
            BarberWork(); // Виклик методу для обслуговування клієнта
            semaphoreKlient.Release(); // Звільнення семафора клієнта
            semaphoreBarber.Release();
            Console.WriteLine($"Клієнт {klientThread.Name} залишає барбершоп.");

            //}
        }
        internal void BarberWork() // Метод для імітації роботи барбера 
        {

            Action<int, int, int> ProcessSimulation;
            Action<int, int, int>[] methods = { Program.Fibonacсi, Program.PrimeNumbers, Program.PowerOfNmber };
            Random random = new Random();
            int randomindex = random.Next(0, methods.Length);
            ProcessSimulation = methods[randomindex];


            lock (klientThread) ; // Очікування доступу до семафора барбера
            {

                Console.WriteLine($"{klientThread.Name}  обслуговується барбером {barberThread.Name}.");
                ProcessSimulation(2, 1, 0); // Виклик методу для обслуговування клієнта
                Thread.Sleep(1000); // Симуляція часу обслуговування клієнта
                Console.WriteLine($"Барбер {barberThread.Name} закінчив обслуговування клієнта {klientThread.Name}.");
            }
            //counter--;


        }
    }

    internal class Barber
    {
        internal Semaphore semaphoreKlient = new Semaphore(1, 3);
        internal Semaphore semaphoreBarber = new Semaphore(1, 1);
        Thread klient;
        private Thread barber;
        //internal Thread klientThread;
        private int counter = 2;
        public Barber(int name)
        {
        barber = new Thread(BarberWork);
            barber.Name = $"Барбер {name}";
            barber.Start(); // Запуск потоку барбера
            //klientThread = new Thread(KlientWork);
            //klientThread.Name = $"Клієнт {name}";
            //klientThread.Start();
        }



        internal void KlientWork()
        {
            
            Console.WriteLine($"{klient.Name} зайшов в барбершоп.");                     
        }
        internal void BarberWork() 
        {
            for (int i = 0; i < 5; i++)
            {
                klient = new Thread(KlientWork);
                klient.Name = $"Клієнт {i}";
                klient.Start();

            }




            Action<int, int, int> ProcessSimulation;
            Action<int, int, int>[] methods = { Program.Fibonacсi, Program.PrimeNumbers, Program.PowerOfNmber };
            Random random = new Random();
            int randomindex = random.Next(0, methods.Length);

            ProcessSimulation = methods[randomindex];

            //Console.WriteLine($"{klient.Name} зайшов в барбершоп.");
            //semaphoreKlient.WaitOne();  // Очікування доступу до семафора клієнта
          
            semaphoreKlient.WaitOne();  // Очікування доступу до семафора клієнта
            //Console.WriteLine($"{klient.Name}  очікує обслуговування.");
            semaphoreBarber.WaitOne(); // Очікування доступу до семафора барбера

            ProcessSimulation(2, 1, 0); // Виклик методу для обслуговування клієнта
            semaphoreBarber.Release();
            semaphoreKlient.Release(); // Звільнення семафора клієнта
            Console.WriteLine($"Клієнт {klient.Name} залишає барбершоп.");



            if (!klient.IsAlive) // Перевірка, чи потік клієнта все ще активний
            {
                return; // Якщо потік клієнта не запущений, вихід з методу
            }
            BarberWork(); // Виклик методу для обслуговування клієнта
        }
    }
}