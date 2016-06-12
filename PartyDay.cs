using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser
{
    class PartyDay : Day
    {
        public ObservableCollection<string> Guests { get; set; }
        public PartyDay(DateTime newDate) : base(newDate)
        {
            Guests = new ObservableCollection<string>();
        }

        public override int GetHashCode() //np. 19701231
        {
            return 10000 * Date.Year + 100 * Date.Month + Date.Day;
        }
        // Domysly comparer
        public int CompareTo(PartyDay otherDay)
        {
            if (otherDay == null)
                return 1;
            else
                return this.date.CompareTo(otherDay.Date);
        }

        public bool Equals(PartyDay other)
        {
            if (other == null) return false;
            return (this.date.Equals(other.Date));
        }

        public override string ToString()
        {
            return String.Format("Party Day: {0}\n{1}", this.Date.ToShortDateString(),
                TasksToString());
        }
    }
}
