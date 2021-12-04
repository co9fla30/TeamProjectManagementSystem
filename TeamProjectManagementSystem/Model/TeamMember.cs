using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectManagementSystem.Model
{
    class TeamMember : ObservableCollection<TeamMemberInfo>
    {
        public TeamMember()
        {
            this.Add(new TeamMemberInfo() { TeamId = 1, UserId = "팀원1", Percentage = 55 });
            this.Add(new TeamMemberInfo() { TeamId = 2, UserId = "팀원2", Percentage = 75 });
            this.Add(new TeamMemberInfo() { TeamId = 3, UserId = "팀원3", Percentage = 65 });
            this.Add(new TeamMemberInfo() { TeamId = 4, UserId = "팀원4", Percentage = 87 });
        }
    }

    public class TeamMemberInfo
    {
        public int TeamId { get; set; }

        public string UserId { get; set; }

        public int Percentage { get; set; }
    }
}
