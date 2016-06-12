using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser
{
    class HourWithMinutes
    {
        private int hour;
        private int minutes;

        public int Hour
        {
            get { return hour; }
        }

        public int Minutes
        {
            get { return minutes; }
        }
        public HourWithMinutes(int h, int m)
        {
            if(h > -1 && h < 24)
                hour = h;
            if(m > -1 && m < 60)
                minutes = m;
        }

        public override string ToString()
        {
            String min, h;
            if (minutes < 10)
                min = "0" + minutes.ToString();
            else
                min = minutes.ToString();
            if (hour < 10)
                h = "0" + hour.ToString();
            else
                h = hour.ToString();
            return String.Format("{0}:{1}", h, min);
        }

        public int CompareTo(HourWithMinutes other)//1 wieksze this, -1 mniejsze, 0 rowne
        {
            if (other.Hour > this.Hour)
                return -1;
            else if (other.Hour < this.Hour)
                return 1;
            else 
            {
                if (other.Minutes > this.minutes)
                    return -1;
                else if (other.Minutes < this.minutes)
                    return 1;
                else
                    return 0;
            }
        }
    }
}
