using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_2__Instrument
{
    class Instrument
    {
    
        public void ShowInfo(string Name)
        {
            Console.WriteLine($"Инструмент {Name}");
        }       
        // видає звук музичного інструменту
        public void ShowSound(string Sound)
        {
            Console.WriteLine($"{Sound}");
        }
        //відображає опис музичного інструменту
        public void ShowHistory(string History)
        {
            Console.WriteLine($"Історія інструменту {History}");
        }
        // відображає опис інструменту
        public void ShowDesc(string Desc)
        {
            Console.WriteLine($"Опис інструменту {Desc}");
        }

    }
}
