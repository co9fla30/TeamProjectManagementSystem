using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{ 
        class TeamBoardAddViewModel
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public RelayCommand TeamBoardAddCommand { get; set; }

        public TeamBoardAddViewModel()
        {
            TeamBoardAddCommand = new RelayCommand(TeamBoardAdd);
        }

        public void TeamBoardAdd(object obj)
        {
            new MySQL().TeamBoardAdd(Title, Content);
        }
    }
}