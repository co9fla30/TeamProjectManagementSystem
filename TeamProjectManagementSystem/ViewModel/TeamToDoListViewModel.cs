using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class TeamToDoListViewModel : Notifier
    {
        private ObservableCollection<Progress> progresses;

        public ObservableCollection<Progress> Progresses
        {
            get { return progresses; }
            set { 
                progresses = value;
                OnPropertyChanged("Progresses");
            }
        }

        private string newToDo;

        public string NewToDo
        {
            get { return newToDo; }
            set { 
                newToDo = value;
                OnPropertyChanged("NewToDo");
            }
        }

        private int percent;

        public int Percent
        {
            get { return percent; }
            set { percent = value; }
        }



        public RelayCommand DoneCheckCommand { get; set; }

        public RelayCommand AddToDoCommand { get; set; }

        public RelayCommand DeleteToDoCommand { get; set; }

        public RelayCommand UpdatePercentageCommand { get; set; }

        public TeamToDoListViewModel()
        {
            //Progresses = new ObservableCollection<Progress>();
            //Progresses.Add(new Progress());

            Progresses = new MySQL().GetProgress();

            DoneCheckCommand = new RelayCommand(DoneCheck);
            AddToDoCommand = new RelayCommand(AddToDo);
            DeleteToDoCommand = new RelayCommand(DeleteToDo);
            UpdatePercentageCommand = new RelayCommand(UpdatePercentage);
        }

        public void DoneCheck(object obj)
        {
            bool b = new MySQL().GetDoneState((int)obj);
            new MySQL().UpdateDoneCheck((int)obj, !b);
        }

        public void AddToDo(object obj)
        {
            new MySQL().AddToDo((string)obj, NewToDo);
            Progresses = new MySQL().GetProgress();
        }

        public void DeleteToDo(object obj)
        {
            new MySQL().DeleteToDo((int)obj);
            Progresses = new MySQL().GetProgress();
        }

        public void UpdatePercentage(object obj)
        {
            new MySQL().UpdatePercentage(Percent ,(string)obj);
            Progresses = new MySQL().GetProgress();
            Percent = 0;
        }
    }
}
