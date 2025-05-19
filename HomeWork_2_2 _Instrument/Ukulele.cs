using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_2__Instrument
{
    class Ukulele : Instrument
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Sound { get; set; }

        public string History { get; set; }

        public Ukulele() : base()
        {
            Name = "Укулеле";
            Desc = "Укулеле - це струнний музичний інструмент, що походить з Гавайських островів.";
            History = "Укулеле виникло в XIX столітті.";
            Sound = "Укулеле звучить весело і радісно.";
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
