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
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Yoda
{
    public partial class MainPage : PhoneApplicationPage
    {
        DateTime targetDay = DateTime.Now;
        List<LessonItem> dayTimetable;

        // Конструктор
        public MainPage()
        {
            System.Diagnostics.Debug.WriteLine("Yay!");
            InitializeComponent();
            updateDateLabel(targetDay);
        }

        private void clickPrevDay(object sender, System.EventArgs e)
        {
        	// TODO: Add event handler implementation here.
            //dayViewLabel.Text = "Previous";
            targetDay = targetDay.AddDays(-1);
            updateDateLabel(targetDay);
        }

        private void clickChooseDate(object sender, System.EventArgs e)
        {
        	//pass
        }

        private void clickNextDay(object sender, System.EventArgs e)
        {
        	// TODO: Add event handler implementation here.
			//dayViewLabel.Text = "Next";
            targetDay = targetDay.AddDays(1);
            updateDateLabel(targetDay);
            Console.Write(targetDay);
            System.Diagnostics.Debug.WriteLine(targetDay);
            loadDayTimetable(targetDay);
        }

        private void updateDateLabel(DateTime date)
        {
            dayTab.Header = date.ToString("D");
            //dayViewLabel.Text = date.ToString("D");
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
            String getDate = parseDate(date);
            String url = "http://vsu-it.ru/api/timetable?day=" + getDate + "&group=2";
            System.Diagnostics.Debug.WriteLine(url);

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClientFinished);
            Uri.EscapeUriString(url);
            client.DownloadStringAsync(new Uri(url));

            /*List<LessonItem> lessons;
            string jsonArrayAsString = json;
            JArray jsonArray = JArray.Parse(jsonArrayAsString);
            JToken jsonArray_Item = jsonArray.First;
            while (jsonArray_Item != null) {
                LessonItem current = new LessonItem();
                current.title = jsonArray_Item.Value<string>("title");
                current.time = jsonArray_Item.Value<string>("time");

                lessons.Add(current);
                jsonArray_Item = jsonArray_Item.Next;
            }*/
        }

        private void webClientFinished(object sender, DownloadStringCompletedEventArgs e) {
            if (e.Error == null) {
                List<LessonItem> lessons = new List<LessonItem>();
                DayTimetableList.Items.Clear();

                string jsonArrayAsString = e.Result;
                JArray jsonArray = JArray.Parse(jsonArrayAsString);
                JToken jsonArray_Item = jsonArray.First;

                while (jsonArray_Item != null) {                    
                    LessonItem item = JsonConvert.DeserializeObject<LessonItem>(jsonArray_Item.ToString());
                    System.Diagnostics.Debug.WriteLine(item.title);
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
                    DayTimetableList.Items.Add(item);

                    jsonArray_Item = jsonArray_Item.Next;                    
                }

                //DayTimetableList.ItemsSource = lessons;
                /*while (jsonArray_Item != null) {
                    LessonItem current = new LessonItem();
                    current.title = jsonArray_Item.Value<string>("title");
                    current.time = jsonArray_Item.Value<string>("time");
                    current.place = jsonArray_Item.Value<string>("place");

                    dayTimetable.Add(current);
                    jsonArray_Item = jsonArray_Item.Next;
                }*/

               // DayTimetableList.ItemsSource = dayTimetable;
            }
            else {
                MessageBox.Show(e.Error.Message);
            }
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
    }
}