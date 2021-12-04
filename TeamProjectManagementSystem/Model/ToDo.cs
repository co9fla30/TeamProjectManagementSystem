using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectManagementSystem.Model
{
    public class ToDo : ObservableCollection<ToDoInfo>
    {
        public ToDo()
        {
            this.Add(new ToDoInfo() { Id = 1, TeamId = 1, UserId = "팀원1", Text = "공부하기", Check = "False" });
            this.Add(new ToDoInfo() { Id = 1, TeamId = 1, UserId = "팀원1", Text = "운동하기", Check = "True" });
            this.Add(new ToDoInfo() { Id = 2, TeamId = 2, UserId = "팀원2", Text = "밥 먹기", Check = "False" });
            this.Add(new ToDoInfo() { Id = 3, TeamId = 3, UserId = "팀원3", Text = "게임하기", Check = "False" });
            this.Add(new ToDoInfo() { Id = 4, TeamId = 4, UserId = "팀원4", Text = "책읽기", Check = "False" });
        }       
    }
    public class ToDoInfo
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }

        public string Check { get; set; }
    }
}
