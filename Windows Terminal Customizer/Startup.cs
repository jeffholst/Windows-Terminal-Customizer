using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Terminal_Customizer
{
    public class Startup
    {
        int _messageCounter;
        StartupForm _startupForm;
        List<string> _messages;

        public Startup()
        {
            _messageCounter = 0;
            LoadMessages();
            _startupForm = new StartupForm();
        }

        private void LoadMessages()
        {
            _messages = new List<string>();

            _messages.Add("Determining launch readiness");
            _messages.Add("Thumbs up to proceed");
            _messages.Add("Retracting orbital arm");
            _messages.Add("Starting auxillary power");
            _messages.Add("Pressurizing hydraulic systems");
            _messages.Add("Closing protective visors");
            _messages.Add("Auto sequence start");
            _messages.Add("Enabling sound suppression");
            _messages.Add("Starting main engines");
            _messages.Add("Igniting rocket boosters");
            _messages.Add("Blasting off!!");
        }

        public void Start()
        {
            Next();
            _startupForm.Show();
        }

        public void Next()
        {
            string message;

            if (_messageCounter < _messages.Count())
            {
                message = _messages[_messageCounter];
            }
            else
            {
                message = _messages[_messages.Count - 1];
            }

            _startupForm.UpdateMessage(message);

            _messageCounter++;
        }

        public void Stop()
        {
            _startupForm.Hide();
        }
    }
}
