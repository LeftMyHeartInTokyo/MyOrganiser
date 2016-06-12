using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Organiser
{
    class Task
    {
        private DateTime begin;
        private DateTime end;
        private String title;
        private String shortDescription;
        private int duration;
        public Task(String titt, String desc, DateTime day, HourWithMinutes b, HourWithMinutes e)
        {
            title = titt;
            shortDescription = desc;
            begin = new DateTime(day.Year, day.Month, day.Day, b.Hour, b.Minutes, 0);
            end = new DateTime(day.Year, day.Month, day.Day, e.Hour, e.Minutes, 0);
        }

        public Task()
        {

        }

        public DateTime Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }

        public String Title
        {
            get { return title; }
            set
            {
                if (value.Length < 80)
                    title = value;
            }
        }

        public String ShortDescription
        {
            get { return shortDescription; }
            set
            {
                if (value.Length < 150)
                    shortDescription = value;
            }
        }

        public override string ToString()
        {
            String taskString = String.Format("{0} - {1}\n{2}\n{3}\n",
                begin.ToShortTimeString(), end.ToShortTimeString(), title, shortDescription);
            return taskString;
        }

        public static bool ifTaskIsValid(String titt, HourWithMinutes b, HourWithMinutes e)
        {
            if (titt.Length == 0 || titt.Length > 80 || b.CompareTo(e) != -1 || e == null || b == null)
                return false;
            else
                return true;
        }
    }
}
