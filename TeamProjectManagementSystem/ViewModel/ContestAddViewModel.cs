using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class ContestAddViewModel
    {
        public Contest ContestInfo { get; set; }

        public RelayCommand ContestAddCommand { get; set; }

        public ContestAddViewModel()
        {
            ContestAddCommand = new RelayCommand(ContestAdd);
        }

        public void ContestAdd(object obj)
        {
            new MySQL2().AddContest(ContestInfo);
        }
    }
}
