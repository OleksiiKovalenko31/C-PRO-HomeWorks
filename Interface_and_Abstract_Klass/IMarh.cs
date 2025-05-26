using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_3_Interface_and_Abstract_Klass
{
    interface IMarh
    {
        void IntMax(int[] array);
        //{
        //    if (array == null || array.Length == 0)
        //    {
        //        Console.WriteLine("Array is empty or null.");
        //        return;
        //    }

        //    int max = array[0];
        //    foreach (var num in array)
        //    {
        //        if (num > max)
        //        {
        //            max = num;
        //        }
        //    }
        //    Console.WriteLine($"Maximum value in the array: {max}");
        //}

        void IntMin(int[] array);
            //{
            //if (array == null || array.Length == 0)
            //{
            //    Console.WriteLine("Array is empty or null.");
            //    return;
            //}
            //int min = array[0];
            //foreach (var num in array)
            //{
            //    if (num < min)
            //    {
            //        min = num;
            //    }
            //}
            //Console.WriteLine($"Minimum value in the array: {min}");
        //}

        void FloatAvg(int [] array);

        void BoolSearh(int[] array);
       

          
        
    }
}
