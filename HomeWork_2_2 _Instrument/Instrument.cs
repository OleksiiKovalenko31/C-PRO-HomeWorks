using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_2__Instrument
{
    class Instrument
    {
        //Поля класса
        //private string name;
        //private string desc;
        //private string sound;
        //private string history;


        // Конструктор класса
        public Instrument(/*string inName, string inDesc, string inSound, string inHistory*/)
        {
            //inName = name;
            //inDesc = desc;
            //inSound = sound;
            //inHistory = history;
        }

        // Свойства класса
        public string Name { get; set; }

        public string Desc  { get; set; }
      
        public string Sound { get; set; }

        public string History { get; set; }


        // відображає назву музичного інструменту
        public void ShowInfo()
        {
            Console.WriteLine($"Инструмент: {Name}");
        }
        // видає звук музичного інструменту
        public void ShowSound()
        {
            Console.WriteLine($"{Sound}");
        }
        //відображає опис музичного інструменту
        public void ShowHistory()
        {
            Console.WriteLine($"Історія інструменту {History}");
        }
        // відображає опис інструменту
        public void ShowDesc()
        {
            Console.WriteLine($"Опис інструменту {Desc}");
        }

    }
}
