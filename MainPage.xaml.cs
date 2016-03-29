using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Yoda
{
    public partial class MainPage : PhoneApplicationPage
    {
        DateTime targetDay = DateTime.Now;
        DatePickerCustom datePicker;
        IsolatedStorageSettings settings;
        const string GROUP = "GROUP";
        const string HIDE_CANCELED = "HIDE_CANCELED";

        public MainPage()
        {
            InitializeComponent();
            updateDateLabel(targetDay);

            settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains(GROUP)) {
                settings.Add(GROUP, 1);
                settings.Save();
            }
            if (!settings.Contains(HIDE_CANCELED)) {
                settings.Add(HIDE_CANCELED, false);
                settings.Save();
            }

            Loaded += new RoutedEventHandler(MainPage_Loaded);

            loadDayTimetable(targetDay);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e) {
            if (this.datePicker == null) {
                this.datePicker = new DatePickerCustom();
                this.datePicker.IsTabStop = false;
                this.datePicker.MaxHeight = 0;

                this.datePicker.ValueChanged += new EventHandler<DateTimeValueChangedEventArgs>(datePicker_ValueChanged);

                LayoutRoot.Children.Add(this.datePicker);
            }
        }

        private void datePicker_ValueChanged(object sender, DateTimeValueChangedEventArgs e) {
            targetDay = (DateTime)e.NewDateTime;
            updateDateLabel(targetDay);
            loadDayTimetable(targetDay);
        }

        private void clickPrevDay(object sender, System.EventArgs e)
        {
            targetDay = targetDay.AddDays(-1);
            updateDateLabel(targetDay);
            loadDayTimetable(targetDay);
        }

        private void clickChooseDate(object sender, System.EventArgs e)
        {
            this.datePicker.ClickButton();
        }

        private void clickNextDay(object sender, System.EventArgs e)
        {
            targetDay = targetDay.AddDays(1);
            updateDateLabel(targetDay);
            loadDayTimetable(targetDay);
        }

        private void onRefreshButton(object sender, System.EventArgs e) {
            updateDateLabel(targetDay);
            loadDayTimetable(targetDay);
        }

        private void updateDateLabel(DateTime date)
        {
            dayTab.Header = date.ToString("D");
        }

        private String parseDate(DateTime date) {
            int day, month;
            day = date.Day;
            month = date.Month;
            String dateString = "";

            if (day < 10) {
                dateString += "0";
            }
            dateString += day;

            if (month < 10) {
                dateString += "0";
            }
            dateString += month;

            return dateString;
        }
        
        private void loadDayTimetable(DateTime date)
        {
            indicator.IsIndeterminate = true;
            String getDate = parseDate(date);
            String url = "http://vsu-it.ru/api/timetable?day=" + getDate + "&group=" + settings[GROUP].ToString();
            System.Diagnostics.Debug.WriteLine(url);

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClientFinished);
            Uri.EscapeUriString(url);
            client.DownloadStringAsync(new Uri(url));
        }

        private void webClientFinished(object sender, DownloadStringCompletedEventArgs e) {
            if (e.Error == null) {
                DayTimetableList.Items.Clear();

                string jsonArrayAsString = e.Result;
                JArray jsonArray = JArray.Parse(jsonArrayAsString);
                JToken jsonArray_Item = jsonArray.First;
                int i = 0;

                while (jsonArray_Item != null) {                    
                    LessonItem item = JsonConvert.DeserializeObject<LessonItem>(jsonArray_Item.ToString());
                    switch (item.type_css) {
                        case "lection":
                            item.color = "#DFEF75";
                            break;
                        case "practice":
                            item.color = "#85C0EC";
                            break;
                        case "lab":
                            item.color = "#ED9595";
                            break;
                    }

                    /* Если пара отменена, то показываем соответствующую надпись
                     * Если в настройках указано, что пара скрывается, то присваиваем параметру "is_hiding" соответствующее значение 
                     * */
                    if (item.is_canceled)
                        item.canceled_visible = "Visible";
                    else
                        item.canceled_visible = "Collapsed";

                    /* Показываем домашние задания */
                    if (item.homework != null)
                        item.homework_visible = "Visible";                    
                    else
                        item.homework_visible = "Collapsed";

                    /* Показываем контрольные работы */
                    if (item.control != null)
                        item.control_visible = "Visible";
                    else
                        item.control_visible = "Collapsed";

                    if (!((bool)settings[HIDE_CANCELED] && item.is_canceled))
                        DayTimetableList.Items.Add(item);

                    jsonArray_Item = jsonArray_Item.Next;
                    i++;
                }

                /* Если число пар равно нулю, то значит это выходной день */
                if (i > 0)
                    holiday.Visibility = System.Windows.Visibility.Collapsed;
                else
                    holiday.Visibility = System.Windows.Visibility.Visible;
            }
            else {
                MessageBox.Show(e.Error.Message);
            }

            indicator.IsIndeterminate = false;
        }

        private void showSettings(object sender, System.EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void openWebsite(object sender, System.EventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "http://www.vsu-it.ru";
            task.Show();
        }

        private void clickHolidayNextDay(object sender, System.Windows.RoutedEventArgs e)
        {
            targetDay = targetDay.AddDays(1);
            updateDateLabel(targetDay);
            loadDayTimetable(targetDay);
        }

        private void addHomeworkClick(object sender, RoutedEventArgs e) {            
            var current = (MenuItem) sender;
            int time = getLessonTime(current.Tag.ToString());
            if (time == 0) {
                MessageBox.Show("Возникла ошибка");
                return;
            }
            NavigationService.Navigate(new Uri("/AddHomework.xaml?time=" + time.ToString() + "&date=" + targetDay.ToString("dd.MM.yyyy"), UriKind.Relative));
        }

        private int getLessonTime(string time) {
            switch (time) {
                case "8:20":
                    return 1;
                    break;
                case "10:00":
                    return 2;
                    break;
                case "11:45":
                    return 3;
                    break;
                case "14:00":
                    return 4;
                    break;
                case "15:45":
                    return 5;
                    break;
                case "17:20":
                    return 6;
                    break;
                case "18:55":
                    return 7;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        private void addControlClick(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/AddControl.xaml", UriKind.Relative));
        }

        private void changePlaceClick(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/ChangePlace.xaml", UriKind.Relative));
        }

        private void transferLessonClick(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new Uri("/TransferLesson.xaml", UriKind.Relative));
        }

        private void canceledLessonClick(object sender, RoutedEventArgs e) {
            //f
        }

        
    }
}