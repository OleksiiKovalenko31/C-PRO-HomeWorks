using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_OperatorOverloading
{
    internal class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public double Area { get; set; } // in square kilometers
        public City(string name, int population, double area)
        {
            Name = name;
            Population = population;
            Area = area;
        }
        public static City operator +(City c1, City c2)
        {
            return new City(c1.Name + " & " + c2.Name, c1.Population + c2.Population, c1.Area + c2.Area);
        }
        public static City operator -(City c1, City c2)
        {
            return new City(c1.Name + " - " + c2.Name, Math.Max(0, c1.Population - c2.Population), Math.Max(0, c1.Area - c2.Area));

        }
        public static bool operator >(City c1, City c2)
        {
            return c1.Population > c2.Population;
        }
        public static bool operator <(City c1, City c2)
        {

            return c1.Population < c2.Population;
        }
        public static bool operator ==(City c1, City c2)
        {
            return c1.Population == c2.Population && c1.Area == c2.Area && c1.Name == c2.Name;
        }
        public static bool operator !=(City c1, City c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return $"{Name}: Population = {Population}, Area = {Area} sq.km";
        }

    }
}
