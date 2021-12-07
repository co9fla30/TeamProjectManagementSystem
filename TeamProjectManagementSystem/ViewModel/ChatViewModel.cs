using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectManagementSystem.ViewModel
{
    class ChatViewModel
    {
        private string myMessage;

        public string MyMessage
        {
            get { return myMessage; }
            set { myMessage = value; }
        }

        public RelayCommand SendMessageCommand { get; set; }

        public ChatViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        public void SendMessage(object obj)
        {

        }
    }
}
