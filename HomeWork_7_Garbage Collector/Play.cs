using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7_Garbage_Collector
{
    internal class Play : IDisposable // IDisposable(0) is not a valid syntax, it should be IDisposable
    {
       string Name { get; set; }
       string Autor {  get; set; }
       string Gerne { get; set; }
       string Date { get; set; }

        internal Play (string name, string autor, string gerne, string date)
        {
            Name = name;
            Autor = autor;
            Gerne = gerne;
            Date = date;
        }

        internal  void PlayInfo()
        {
            StringBuilder allInfoPlay = new StringBuilder();
            allInfoPlay.Append ($"Name Play - {Name}\n");
            allInfoPlay.Append ($"Autor - {Autor}\n");
            allInfoPlay.Append ($"Gerne - {Gerne}\n");
            allInfoPlay.Append($"Data - {Date} \n");
            
            Console.WriteLine(allInfoPlay.ToString());

        }

      public void Dispose()
        {
            
            Console.WriteLine($"Play {Name} was deleted from memory");
        }

        ~Play() // Finalizer to ensure resources are cleaned up
        {
            Dispose();
        }
    }
}
