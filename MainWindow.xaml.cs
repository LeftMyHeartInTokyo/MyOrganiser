using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Organiser
{

    public partial class MainWindow : Window
    {
        private OrganiserElements organiserElements;
        public MainWindow()
        {
            InitializeComponent();
            organiserElements = new OrganiserElements();
            initHours();
            displayDayWithDate(DateTime.Today);
            makeGuestsElementsInvisible();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (Task.ifTaskIsValid(tittleTextBox.Text, hoursBeginComboBox.SelectedItem as HourWithMinutes,
                hoursEndComboBox.SelectedItem as HourWithMinutes))
            {
                try
                {
                    DateTime selectedDay = MainCalendar.SelectedDate.Value;
                    int ind = organiserElements.ListOfDays.ToList().IndexOf(new Day(selectedDay));
                    if (ind != -1)
                    {
                        Day day = organiserElements.ListOfDays.ElementAt(ind);
                        day.AddTask(tittleTextBox.Text, descTextBox.Text,
                            hoursBeginComboBox.SelectedItem as HourWithMinutes,
                            hoursEndComboBox.SelectedItem as HourWithMinutes);
                    }
                    else  //dzien niedodany              
                    {
                        organiserElements.AddNewDay(selectedDay);
                        ind = organiserElements.ListOfDays.ToList().IndexOf(new Day(selectedDay));
                        Day day = organiserElements.ListOfDays.ElementAt(ind);
                        day.AddTask(tittleTextBox.Text, descTextBox.Text,
                            hoursBeginComboBox.SelectedItem as HourWithMinutes,
                            hoursEndComboBox.SelectedItem as HourWithMinutes);
                    }
                    displayDayWithDate(selectedDay);

                }
                catch (System.InvalidOperationException ex)
                {
                    MessageBox.Show("The day is not selected", "Exception");
                }
            }
            else
                MessageBox.Show("Not valid task");
        }


        private void initHours()
        {
            foreach (HourWithMinutes hm in organiserElements.HoursOfDay)
            {
                hoursBeginComboBox.Items.Add(hm);
                hoursEndComboBox.Items.Add(hm);
            }
        }

        private void MainCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDay = MainCalendar.SelectedDate.Value;
            displayDayWithDate(selectedDay);
            PartyDay partyDay = organiserElements.ListOfPartyDays.ToList().Find(day => day.Date == selectedDay);
            if (partyDay != null)
            {
                DataContext = partyDay;
                makeGuestsElementsVisible();
            }
            else
            {
                DataContext = null;
                makeGuestsElementsInvisible();
            }
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if (Mouse.Captured is Calendar || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
            {
                Mouse.Capture(null);
            }
        }

        private void displayDayWithDate(DateTime date)
        {
            int ind = organiserElements.ListOfDays.ToList().IndexOf(new Day(date));
            if (ind != -1)
            {
                Day day = organiserElements.ListOfDays.ElementAt(ind);
                tasksTextBlock.Text = day.ToString();
            }
            else
                tasksTextBlock.Text = "The day has no task";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddPartyDay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime selectedDay = MainCalendar.SelectedDate.Value;
                int ind = organiserElements.ListOfDays.ToList().IndexOf(new Day(selectedDay));
                if (ind == -1)
                {
                    PartyDay pt = new PartyDay(selectedDay);
                    organiserElements.AddNewPartyDay(selectedDay);
                    DataContext = pt; //wybranie dnia do wyswietlanie w guestsListBox
                    makeGuestsElementsVisible();
                }
                else  //dzien niedodany              
                {
                    MessageBox.Show("The Party Day already added!");
                }
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Not valid", "Exception");
            }
           
        }

        private void addGuestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime selectedDay = MainCalendar.SelectedDate.Value;

                int ind = organiserElements.ListOfPartyDays.ToList().FindIndex(d => d.Date == selectedDay);
                if (ind != -1)
                {
                    PartyDay day = organiserElements.ListOfPartyDays.ElementAt(ind);
                    day.Guests.Add(addGuestsTextBox.Text.ToString());
                    addGuestsTextBox.Clear();
                    DataContext = day;
                }
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("The day not selected", "Exception");
            }
        }

        private void makeGuestsElementsVisible()
        {
            addGuestButton.Visibility = System.Windows.Visibility.Visible;
            guestsLabel.Visibility = System.Windows.Visibility.Visible;
            addGuestsLabel.Visibility = System.Windows.Visibility.Visible;
            addGuestsTextBox.Visibility = System.Windows.Visibility.Visible;
            guestsListBox.Visibility = System.Windows.Visibility.Visible;
        }

        private void makeGuestsElementsInvisible()
        {
            addGuestButton.Visibility = System.Windows.Visibility.Hidden;
            guestsLabel.Visibility = System.Windows.Visibility.Hidden;
            addGuestsLabel.Visibility = System.Windows.Visibility.Hidden;
            addGuestsTextBox.Visibility = System.Windows.Visibility.Hidden;
            guestsListBox.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
