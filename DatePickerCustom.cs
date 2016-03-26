using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Yoda
{
	public class DatePickerCustom : DatePicker
	{
		public DatePickerCustom()
		{
			// Insert code required on object creation below this point.
		}

        public void ClickButton() {
            Button btn = (GetTemplateChild("DateTimeButton") as Button);
            ButtonAutomationPeer peer = new ButtonAutomationPeer(btn);
            IInvokeProvider provider = (peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider);

            provider.Invoke();
        }
	}
}