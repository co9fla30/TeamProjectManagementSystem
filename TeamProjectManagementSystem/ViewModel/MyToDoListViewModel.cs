using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class MyToDoListViewModel
    {
        private ObservableCollection<Progress> myProgresses;

        public ObservableCollection<Progress> MyProgresses
        {
            get { return myProgresses; }
            set { myProgresses = value; }
        }

        public MyToDoListViewModel()
        {
            //MyProgresses = new ObservableCollection<Progress>();
            //MyProgresses.Add(new Progress());

            MyProgresses = new MySQL().GetMyProgress();
        }
    }
}
