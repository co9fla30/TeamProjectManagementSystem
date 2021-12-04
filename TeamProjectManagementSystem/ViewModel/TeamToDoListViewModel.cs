using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class TeamToDoListViewModel
    {
        TeamMember teamMember;
        ToDo toDo;

        public TeamToDoListViewModel()
        {
            teamMember = new TeamMember();
            toDo = new ToDo();
        }

        public TeamMember TeamMember
        {
            get { return this.teamMember; }
        }

        public ToDo ToDo
        {
            get { return this.toDo; }
        } 
    }
}
