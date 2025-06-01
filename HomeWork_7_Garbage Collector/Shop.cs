using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7_Garbage_Collector
{
    internal class Shop : IDisposable 
    {
        string Name { get; set; }
        string Location { get; set; }
        string Type { get; set; }

        public Shop(string name, string location, string type)
        {
            Name = name;
            Location = location;
            Type = type;
        }
   
        public void Dispose()
        {
            Console.WriteLine($"Shop {Name} was deleted from memory");
        }
        ~Shop() // Finalizer to ensure resources are cleaned up
        {
            Dispose();
        }
    }
}