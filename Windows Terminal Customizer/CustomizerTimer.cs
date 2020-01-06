using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Windows_Terminal_Customizer
{
    public class CustomizerTimer
    {
        Form1 _parent;
        UserControlProfile _uProfile;
        private Timer myTimer;

        public CustomizerTimer(Form1 parent, UserControlProfile uProfile)
        {
            _parent = parent;
            _uProfile = uProfile;

            myTimer = new Timer();
            myTimer.Interval = 60000;
            myTimer.Elapsed += OnTimedEvent;
            myTimer.AutoReset = true;
            myTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string newImage;

            _parent.CheckRotations(out newImage);

            if ( !string.IsNullOrEmpty(newImage))
            {
                _uProfile.UpdateImageTextbox(newImage);
            }
        }
    }
}
