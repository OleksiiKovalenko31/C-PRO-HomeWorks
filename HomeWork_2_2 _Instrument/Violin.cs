using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_2__Instrument
{
    class Violin : Instrument
    {
        public string Name { get; set; }

        public string Desc { get; set; }

        public string Sound { get; set; }

        public string History { get; set; }

        public Violin(/*string inName, string inDesc, string inSound, string inHistory*/) : base(/*inName, inDesc, inSound, inHistory*/)
        {
           Name = "Скрипка";
           Desc = "Скрипка - це струнний музичний інструмент, що належить до сімейства скрипок.";
           History = "Скрипка виникла в Італії в XVI столітті.";
           Sound = "Скрипка звучить мелодійно і ніжно.";
        }

        // відображає назву музичного інструменту
  
        
    } 
}
