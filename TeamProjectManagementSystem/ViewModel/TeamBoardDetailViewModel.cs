using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    
    class TeamBoardDetailViewModel
    {
        private Board board;

        public Board Board
        {
            get { return board; }
            set { board = value; }
        }


        public TeamBoardDetailViewModel()
        {
            Board = new MySQL().ShowBoard();
        }        
    }
}
