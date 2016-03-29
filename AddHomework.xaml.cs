using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyToolkit.Networking;

namespace Yoda
{
    public partial class Page1 : PhoneApplicationPage
    {
        string targetDay;
        string time;
        string text;


        public Page1()
        {
            InitializeComponent();
        }

        private async void sendHomework(object sender, RoutedEventArgs e) {
            try {
                text = HomeworkContent.Text;

                if (text.Length >= 3) {
                    var request = new HttpGetRequest("http://vsu-it.ru/api/change_timetable");
                    request.Query.Add("method", "homework");
                    request.Query.Add("login", "apcom52");
                    request.Query.Add("date", targetDay);
                    request.Query.Add("time", time);
                    request.Query.Add("homework", text);
                    var response = await Http.GetAsync(request);
                    var html = response.Response;
                    MessageBox.Show("Домашнее задание добавлено");

                    if (NavigationService.CanGoBack) {
                        NavigationService.GoBack();
                    }  
                }
                else {
                    MessageBox.Show("Длина сообщения должна быть не менее 3-х символов");
                }                
            }
            catch (Exception error) {
                MessageBox.Show("Возникла ошибка при отправке данных" + error.ToString());
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            NavigationContext.QueryString.TryGetValue("time", out time);
            NavigationContext.QueryString.TryGetValue("date", out targetDay);
        }
    }
}