using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3_Interface_and_Abstract_Klass
{
    public class MyArray: IMarh , IOutput, ISort

    {
        //int[] Array { get; set; } // Property to hold the array
        public int[] _array;
        public MyArray(int size)
        {
            _array = new int[size];
            return ; // Initialize the array with the specified size

        }
        public int[] FillArray()
        {
            
            Random random = new Random();
            for (int i = 0; i <_array.Length; i++)
            {
                int number = random.Next(100);
                _array[i] = number; // Filling with random numbers between 1 and 100
            }

            return _array;

        }
        

        public void Show() // Call the method from the IOutput interface
        {
            _array = FillArray(); // Fill the array with random numbers
            Console.WriteLine("Array contents:");
            foreach (var item in _array)
            {
                Console.Write($"{item}  " );
            }
            Console.WriteLine();
        } 
        public void Show(string? info) // Call the method from the IOutput interface
        {
            Console.WriteLine(info);
            Show();
        }
      

        public void IntMax(int[] array) // Call the method from the IMarh interface
       
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Array is empty or null.");
                return;
            }

            int max = array[0];
            foreach (var num in array)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine($"Maximum value in the array: {max}");
          
        }

        public void IntMin(int[] array) // Call the method from the IMarh interface
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Array is empty or null.");
                return;
            }
            int min = array[0];
            foreach (var num in array)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            Console.WriteLine($"Minimum value in the array: {min}");
        }

        public void FloatAvg(int[] array) // Call the method from the IMarh interface
        {
            if (array == null || array.Length == 0)
            {
                Console.WriteLine("Array is empty or null.");
                return;
            }
            float sum = 0;
            foreach (var num in array)
            {
                sum += num;
            }
            float avg = sum / array.Length;
            Console.WriteLine($"Average value in the array: {avg}");
        }

        public void BoolSearh(int[] array) // Call the method from the IMarh interface
        {
            {
                
                


                while (true)
                {
                    Console.Write("Enter a value to search in the array: ");
                    string? numberInput = Console.ReadLine();
                    bool searhNumber = int.TryParse(numberInput, out int number);
                    if (!searhNumber)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        return;
                    }
                    if (array == null || array.Length == 0)
                    {
                        Console.WriteLine("Array is empty or null.");
                        return;
                    }
                    bool found = false;
                    foreach (var num in array)
                    {
                        if (num == number)
                        {
                            found = true;
                            break;
                        }
                        else
                        {
                            found = false;
                            
                        }
                    }
                    Console.WriteLine(found ? $"Value {number} FOUND in the array." : $"Value {number} NOT FOUND in the array.");

                    // Ask if the user wants to exit or continue
                    Console.WriteLine();                   
                    Console.Write("Exit: 1 - Yes / 2 - No   ");

                    int.TryParse(Console.ReadLine(), out int exit);

                    if (exit == 1)
                    { break; }

                    else if (exit == 2)
                    { continue; }

                    else { Console.WriteLine("Incorrect format"); }
                }
            }
        }


        public void SortAsc(int[] array) // Call the method from the ISort interface
        {
            Array.Sort(array);
            Console.WriteLine("Sorted array in ascending order: ");
           
            foreach (var item in array)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
        }

        public void SortDesc(int[] array) // Call the method from the ISort interface
        {
            Array.Sort(array);
            Array.Reverse(array);
            Console.WriteLine("Sorted array in descending order: ");
            foreach (var item in array)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
        }

        public void SortByParam(bool isAsc, int[] array) // Call the method from the ISort interface
        {  
              
            
            if (isAsc)
                {
                    SortAsc(array);
                   
                }
                else if (!isAsc)
                {
                    SortDesc(array);                  
                }
               

              

            
        }









    }

}
