using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Yoda {
    public class LessonItem {
        public LessonItem(string _title, string _time, string _place) {
            this.title = _title;
            this.time = _time;
            this.place = _place;
        }

        public string title { get; set; }
        public string time { get; set; }
        public string place { get; set; }
        public string teacher { get; set; }
        public string type { get; set; }
        public string type_css { get; set; }
        public bool is_ended { get; set; }
        public object homework { get; set; }
        public object control { get; set; }
        public bool is_canceled { get; set; }
        public string color { get; set; }
        public string canceled_visible { get; set; }
        public string homework_visible { get; set; }
        public string control_visible { get; set; }
        public string is_hiding { get; set; }
    }
}