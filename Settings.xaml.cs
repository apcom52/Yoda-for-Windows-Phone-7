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

namespace Yoda
{
    public partial class Settings : PhoneApplicationPage
    {
        IsolatedStorageSettings settings;
        const string GROUP = "GROUP";

        public Settings()
        {
            settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains(GROUP)) {
                settings.Add(GROUP, 1);
                settings.Save();
            }

            InitializeComponent(); 
            settingsGroup.SelectedIndex = (int)settings[GROUP] - 1;
        }

        private void onChangeGroup(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        	
        }

        private void settingsGroup_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	var picker = sender as ListPicker;
            settings[GROUP] = picker.SelectedIndex + 1;
            settings.Save();
            System.Diagnostics.Debug.WriteLine("Save: " + settings[GROUP].ToString());
        }
    }
}