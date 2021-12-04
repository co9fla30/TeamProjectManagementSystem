using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class ContestDetailViewModel
    {
        public Contest ContestInfo { get; set; }

        public ContestDetailViewModel()
        {
            ContestInfo = new MySQL2().SelectedContestInfo();
        }
    }
}
