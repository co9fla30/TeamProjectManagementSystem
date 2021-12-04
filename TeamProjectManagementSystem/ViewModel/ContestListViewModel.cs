using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class ContestListViewModel:Notifier
    {
        public static int selectedNo;

        private ObservableCollection<Contest> contestList;

        public ObservableCollection<Contest> ContestList
        {
            get { return contestList; }
            set
            {
                contestList = value;
                OnPropertyChanged("ContestList");
            }
        }

        private Contest selectedContest;

        public Contest SelectedContest
        {
            get { return selectedContest; }
            set
            {
                selectedContest = value;
                OnPropertyChanged("SelectContest");
                selectedNo = SelectedContest.No;
            }
        }

        public ContestListViewModel()
        {
            contestList = new MySQL2().LoadContestList();
        }
    }
}
