using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser
{
    class OrganiserElements
    {
        private HashSet<Day> listOfDays;
        private HashSet<PartyDay> listOfPartyDays;
        private List<HourWithMinutes> hoursOfDay;
        public HashSet<Day> ListOfDays
        {
            get { return listOfDays; }
        }
        public HashSet<PartyDay> ListOfPartyDays
        {
            get { return listOfPartyDays; }
        }
         public List<HourWithMinutes> HoursOfDay
        {
            get { return hoursOfDay; }
        }
        public OrganiserElements()
        {
            listOfDays = new HashSet<Day>();
            listOfPartyDays = new HashSet<PartyDay>();
            //lista godzin doby co pol godziny
            hoursOfDay = new List<HourWithMinutes>();
            for (int hour = 0; hour < 24; hour++)
            {
                for (int halfhour = 0; halfhour <= 30; halfhour += 30)
                {
                    HourWithMinutes newhour = new HourWithMinutes(hour, halfhour);
                    hoursOfDay.Add(newhour);
                }
            }
        }

        public void AddNewDay(DateTime date)
        {
            Day newDay = new Day(date);
            listOfDays.Add(newDay);

        }
        public void AddNewPartyDay(DateTime date)
        {
            PartyDay newDay = new PartyDay(date);
            listOfDays.Add(newDay);
            listOfPartyDays.Add(newDay);
        }
    }
}
