using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2_2__Instrument
{
    class Cello : Instrument
    {
       
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Sound { get; set; }
        public string History { get; set; }
        public Cello() : base()
        {
            Name = "Віолончель";
            Desc = "Віолончель - це струнний музичний інструмент, що належить до сімейства скрипок.";
            History = "Віолончель виникла в Італії в XVI столітті.";
            Sound = "Віолончель звучить глибоко і емоційно.";
        }
     
 

    }
}
