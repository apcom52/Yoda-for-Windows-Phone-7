﻿#pragma checksum "C:\Users\apcom\documents\visual studio 2012\Projects\Yoda\Yoda\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "137CDE76E6DFC0750176C811FE574331"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Yoda {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ProgressIndicator indicator;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton prevDate;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton chooseDate;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton refreshButton;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton nextDay;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem openSettings;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.PivotItem dayTab;
        
        internal System.Windows.Controls.StackPanel holiday;
        
        internal System.Windows.Controls.ItemsControl DayTimetableList;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Yoda;component/MainPage.xaml", System.UriKind.Relative));
            this.indicator = ((Microsoft.Phone.Shell.ProgressIndicator)(this.FindName("indicator")));
            this.prevDate = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("prevDate")));
            this.chooseDate = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("chooseDate")));
            this.refreshButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("refreshButton")));
            this.nextDay = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("nextDay")));
            this.openSettings = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("openSettings")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.dayTab = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("dayTab")));
            this.holiday = ((System.Windows.Controls.StackPanel)(this.FindName("holiday")));
            this.DayTimetableList = ((System.Windows.Controls.ItemsControl)(this.FindName("DayTimetableList")));
        }
    }
}

