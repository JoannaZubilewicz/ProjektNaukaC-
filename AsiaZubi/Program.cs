using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsiaZubi
{
    class Program
    {
        static void Main(string[] args)
        {
            Time cos = new Time("15:20:30:182");
            var zmienna = cos.Zwracanie_milisekund();
            Time time2 = Time.FromMiliseconds(zmienna);
            Console.WriteLine(cos.Equals(time2));
            Console.ReadKey();
        }
    }
}
