using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Yoda
{
    public partial class Settings : PhoneApplicationPage
    {
        IsolatedStorageSettings settings;
        const string GROUP = "GROUP";
        const string HIDE_CANCELED = "HIDE_CANCELED";

        public Settings()
        {
            settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains(GROUP)) {
                settings.Add(GROUP, 1);
                settings.Save();
            }
            if (!settings.Contains(HIDE_CANCELED)) {
                settings.Add(HIDE_CANCELED, false);
                settings.Save();
            }

            InitializeComponent(); 
            settingsGroup.SelectedIndex = (int)settings[GROUP] - 1;
            settingsHide.IsChecked = (bool)settings[HIDE_CANCELED];
        }

        private void onChangeGroup(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        	
        }

        private void settingsGroup_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	var picker = sender as ListPicker;
            settings[GROUP] = picker.SelectedIndex + 1;
            settings.Save();
        }

        private void onShowSources(object sender, System.Windows.RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://github.com/apcom52/Yoda-for-Windows-Phone-7";
            task.Show();
        }

        private void hideLessonsClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            settings[HIDE_CANCELED] = checkbox.IsChecked;
            settings.Save();
        }
    }
}