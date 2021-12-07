using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class ContestTeamPostAddViewModel
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

        public RelayCommand PostAddCommand { get; set; }

        public ContestTeamPostAddViewModel()
        {
            PostAddCommand = new RelayCommand(PostAdd);
        }

        public void PostAdd(object obj)
        {
            new MySQL2().ContestTeamPostAdd(Title, Content);
        }
    }
}
