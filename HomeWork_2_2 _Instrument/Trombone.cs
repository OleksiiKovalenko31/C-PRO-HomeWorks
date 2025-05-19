using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_2__Instrument
{
    class Trombone : Instrument
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Sound { get; set; }

        public string History { get; set; }
        public Trombone() : base()
        {
            Name = "Тромбон";
            Desc = "Тромбон - це мідний духовий музичний інструмент, що належить до сімейства труб.";
            History = "Тромбон виник в XV столітті в Європі.";
            Sound = "Тромбон звучить гучно і потужно.";
        }
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
