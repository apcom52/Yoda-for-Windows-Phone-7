﻿#pragma checksum "C:\Users\apcom\documents\visual studio 2012\Projects\Yoda\Yoda\Settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BE660AA31E894159D4796D90EAB43E53"
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
    
    
    public partial class Settings : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.ListPicker settingsGroup;
        
        internal System.Windows.Controls.CheckBox settingsHide;
        
        internal System.Windows.Controls.HyperlinkButton showSources;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Yoda;component/Settings.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.settingsGroup = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("settingsGroup")));
            this.settingsHide = ((System.Windows.Controls.CheckBox)(this.FindName("settingsHide")));
            this.showSources = ((System.Windows.Controls.HyperlinkButton)(this.FindName("showSources")));
        }
    }
}

