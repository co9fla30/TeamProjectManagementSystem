using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class TeamBoardViewModel
    {
        public static int selectedBoardNo;

        private ObservableCollection<Board> board;

        public ObservableCollection<Board> Board
        {
            get { return board; }
            set { board = value; }
        }

        public RelayCommand IntoBoardCommand { get; set; }

        public TeamBoardViewModel()
        {
            Board = new MySQL().GetTeamBoardList();
            IntoBoardCommand = new RelayCommand(IntoBoard);
        }

        public void IntoBoard(object obj)
        {
            selectedBoardNo = (int)obj;
        }
    }
}
