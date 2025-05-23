using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_2__Instrument
{
    class Trombone : Instrument
    {
   
        public string Name { get; set; } // задаємо значення по замовчуванню

        public string Desc { get; set; }

        public string Sound { get; set; }

        public string History { get; set; }
        public Trombone()
        {
            Name = "Тромбон";
            Desc = "Тромбон - це мідний духовий музичний інструмент, що належить до сімейства труб.";
            History = "Тромбон виник в XV столітті в Європі.";
            Sound = "Тромбон звучить гучно і потужно.";
        }
     
    }
}
