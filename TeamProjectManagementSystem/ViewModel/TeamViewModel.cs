using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;
using TeamProjectManagementSystem.View;

namespace TeamProjectManagementSystem.ViewModel
{
    class TeamViewModel : Notifier
    {
        private string intro;

        public string Intro
        {
            get { return intro; }
            set { intro = value;
                OnPropertyChanged("Intro");
            }
        }

        private ObservableCollection<MemoOrSchedule> memos;

        public ObservableCollection<MemoOrSchedule> Memos
        {
            get { return memos; }
            set
            {
                memos = value;
                OnPropertyChanged("Memos");
            }
        }

        private ObservableCollection<MemoOrSchedule> schedules;

        public ObservableCollection<MemoOrSchedule> Schedules
        {
            get { return schedules; }
            set
            {
                schedules = value;
                OnPropertyChanged("Schedules");
            }
        }

        private ObservableCollection<Progress> progresses;

        public ObservableCollection<Progress> Progresses
        {
            get { return progresses; }
            set { 
                progresses = value;
                OnPropertyChanged("Progresses");
            }
        }

        private string newMemo;

        public string NewMemo
        {
            get { return newMemo; }
            set { 
                newMemo = value;
                OnPropertyChanged("NewMemo");
            }
        }

        private string newSchedule;

        public string NewSchedule
        {
            get { return newSchedule; }
            set { 
                newSchedule = value;
                OnPropertyChanged("NewSchedule");
            }
        }

        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { 
                selectedDate = value;
                OnPropertyChanged("NewSchedule");
            }   
        }

        private MemoOrSchedule selectedNo;

        public MemoOrSchedule SelectedNo
        {
            get { return selectedNo; }
            set { 
                selectedNo = value;
                OnPropertyChanged("SelectedNo");
            }
        }


        public RelayCommand AddMemoCommand { get; set; }

        public RelayCommand AddScheduleCommand { get; set; }

        public RelayCommand DeleteMemoCommand { get; set; }

        public RelayCommand DeleteScheduleCommand { get; set; }

        public TeamViewModel()
        {
            Intro = new MySQL().GetIntro();
            Memos = new MySQL().GetMemo();
            Schedules = new MySQL().GetSchedule();
            Progresses = new MySQL().GetProgress();
            AddMemoCommand = new RelayCommand(AddMemo);
            AddScheduleCommand = new RelayCommand(AddSchedule);
            DeleteMemoCommand = new RelayCommand(DeleteMemo);
            DeleteScheduleCommand = new RelayCommand(DeleteSchedule);
            SelectedDate = DateTime.Now;
        }

        public void AddMemo(object obj)
        {            
            new MySQL().InsertMemoOrSchedule("memo", NewMemo, DateTime.Now.ToString().Substring(0, 10));
            Memos = new MySQL().GetMemo();
        }

        public void AddSchedule(object obj)
        {
            new MySQL().InsertMemoOrSchedule("schedule", NewSchedule, SelectedDate.ToString().Substring(0, 10));
            Schedules = new MySQL().GetSchedule();
        }

        public void DeleteMemo(object obj)
        {
            new MySQL().DeleteMemoOrSchedule((int)obj);
            Memos = new MySQL().GetMemo();
        }

        public void DeleteSchedule(object obj)
        {
            new MySQL().DeleteMemoOrSchedule((int)obj);
            Schedules = new MySQL().GetSchedule();
        }
    }
}
