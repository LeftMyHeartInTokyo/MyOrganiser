using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser
{
    class Day : IEquatable<Day>, IComparable<Day>
    {
        protected DateTime date;
        protected List<Task> tasks;

        public Day()
        {
            tasks = new List<Task>();
        }

        public Day(DateTime newDate)
        {
            date = newDate;
            tasks = new List<Task>();
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public List<Task> Tasks
        {
            get { return tasks; }
        }

        public void AddTask(String tittle, String desc, HourWithMinutes b, HourWithMinutes e)
        {
            Task newTask = new Task(tittle,desc,this.date, b,e);            
            tasks.Add(newTask);

        }
        //wypisanie wszystkich zadan(tasks) danego dnia
        public String TasksToString()
        {
            StringBuilder tasksString = new StringBuilder();
            foreach (Task t in tasks)
            {
                tasksString.Append(t.ToString());
            }

            return tasksString.ToString();
        }

        
        public override int GetHashCode() //np. 19701231
        {
            return 10000 * Date.Year + 100 * Date.Month + Date.Day;
        }
        // Domysly comparer
        public int CompareTo(Day otherDay)
        {
            if (otherDay == null)
                return 1;
            else
                return this.date.CompareTo(otherDay.Date);
        }

        public bool Equals(Day other)
        {
            if (other == null) return false;
            return (this.date.Equals(other.date));
        }
       
      

        public override string ToString()
        {
            return String.Format("Day: {0}\n{1}", this.Date.ToShortDateString(),
                TasksToString());
        }

        
    }
}
