using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Day
    {
        public bool IfWork { get; set; }
        public TimeSpan StartClock { get; set; }
        public TimeSpan EndClock { get; set; }
        public override string ToString()
        {
            return StartClock+" - "+ EndClock;
        }
        public double NumHours()
        {
            return EndClock.Hours - StartClock.Hours + (EndClock.Minutes - StartClock.Minutes) / 60;
        }
        public Day()
        {
            
        }
        
    }
}
