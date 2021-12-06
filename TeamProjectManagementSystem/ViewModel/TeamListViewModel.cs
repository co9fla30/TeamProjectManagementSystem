using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.View;
using TeamProjectManagementSystem.Model;
using System.Collections.ObjectModel;

namespace TeamProjectManagementSystem.ViewModel
{
    class TeamListViewModel : Notifier
    {
        public static string selectedTeam;

        private ObservableCollection<GroupListInfo> groupList;

        public ObservableCollection<GroupListInfo> GroupList
        {
            get { return groupList; }
            set { groupList = value;
                OnPropertyChanged("GroupList");
            }
        }

        private GroupListInfo selectedGroup;

        public GroupListInfo SelectedGroup
        {
            get { return selectedGroup; }
            set { 
                selectedGroup = value;
                OnPropertyChanged("SelectGroup");
                selectedTeam = SelectedGroup.team_Name;
            }
        }


        public TeamListViewModel()
        {
            //groupList = new ObservableCollection<GroupListInfo>();
            //groupList.Add(new GroupListInfo());
            groupList = new MySQL().LoadGroupList();
        }
    }
}
