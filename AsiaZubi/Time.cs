using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsiaZubi
{
    public struct Time : IEquatable<Time> , IComparable<Time> 
    {
        private readonly byte _hours;
        private readonly byte _minutes;
        private readonly byte _seconds;
        private readonly long _miliseconds;

        public byte Hours { get { return _hours; } }
        // set { byte _hours = value; }
        public byte Minutes { get { return _minutes; } }
        //set { byte _minutes = value;  dzieki temu mozna zmienic wartosci prywatne
        public byte Seconds { get { return _seconds; } }
        // set { byte _seconds = value; }

        public long Miliseconds { get { return _miliseconds; } } 
        public Time (byte hours , byte minutes , byte seconds, long miliseconds ) : this ()
        {
            hours = _hours;
            minutes = _minutes;
            seconds = _seconds;
            miliseconds = _miliseconds;
            
        }

        public Time(byte hours, byte minutes, byte seconds) : this()
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _miliseconds = 0;
        }

        public Time(byte hours, byte minutes) : this()
        {
            _hours = hours;
            _minutes = minutes;
            _seconds = 0;
            _miliseconds = 0;
        }

        public Time(byte hours) : this()
        {
            _hours = hours;
            _minutes = 0;
            _seconds = 0;
            _miliseconds = 0;
            TestValues();


        }

        public Time (string tekst) :this() // zawsze w strukturach
        {
            string[] tabCZAS = tekst.Split(':');
            if ( tabCZAS.Length!=4 )
            {
                throw new ArgumentException("zly format");
            }

            _hours = byte.Parse(tabCZAS[0]);
            _minutes = Convert.ToByte(tabCZAS[1]);
            _seconds = Convert.ToByte(tabCZAS[2]);
            _miliseconds = Convert.ToUInt16(tabCZAS[3]);
            TestValues();




        }

        private void TestValues() //dodac modulo xD
        {
            if ( Hours > 23 )
            {
                throw new ArgumentOutOfRangeException();
            }
            
            if ( Minutes >59)
            {
                throw new ArgumentOutOfRangeException();
            }

            if ( Seconds >59)
            {
                throw new ArgumentOutOfRangeException();
            }
            if(Miliseconds > 999)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int CompareTo(Time other) // mowi co jest rowne sobie i ktora zmienna wieksza od ktorej 
        {
            var timeThis = this.Zwracanie_milisekund();
            var timeOther = other.Zwracanie_milisekund();
            return timeThis.CompareTo(timeOther);
           //w innym przypadku  == 0
          // x>y == 1 
          // x<y == -1 (chyba xd )
        }

        public bool Equals(Time other) // porownuje czy zmienne struktury sa sobie rowne
        {
            return this.Zwracanie_milisekund() == other.Zwracanie_milisekund(); 
            // gdyby bylo bez przejscia na milisekundy to trzeba by porownywac wszystkie wartosci po kolei 
        }

        public  long Zwracanie_milisekund()
        {
          return ((((Hours * 60) + Minutes) * 60 + Seconds)* 1000 + Miliseconds);
            // moj czas zamieniony na milisekunde ;P
        }

        public override string ToString()
        {
            return Hours + ':' + Minutes + ":" + Seconds + ":" + Miliseconds;
        }

        public static Time FromMiliseconds(long miliseconds)
        {
            var milliseconds = miliseconds % 1000;
            var tempSeconds = miliseconds / 1000;
            var seconds = (byte)(tempSeconds % 60);
            var tempMinutes = tempSeconds / 0;
            var minutes = (byte) (tempMinutes % 60 );
            var tempHours = tempMinutes / 60;
            var hours = (byte)(tempHours % 24);

            return new Time(hours, minutes, seconds, miliseconds);
            
        }

        public Time Plus(Time time)
        {
            return Plus(time.Hours, time.Minutes, time.Seconds, time.Miliseconds);
        }

        public Time Plus (byte hour , byte minute , byte second, long millisecond)
        {
            Time obiekt1 = new Time();
            
        }

        //public Time Minus(TimePeriod)
        //{
        //    return
        //}
    }
}
