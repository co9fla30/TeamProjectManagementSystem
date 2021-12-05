using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class TeamBoardViewModel : Notifier
    {
        public static int selectedBoardNo;

        private ObservableCollection<Board> board;

        public ObservableCollection<Board> Board
        {
            get { return board; }
            set { 
                board = value;
                OnPropertyChanged("Board");
            }
        }

        private ObservableCollection<SearchWay> searchWays;

        public ObservableCollection<SearchWay> SearchWays
        {
            get { return searchWays; }
            set {
                searchWays = value;
                OnPropertyChanged("SearchWays");
            }
        }

        private SearchWay selectedWay;

        public SearchWay SelectedWay
        {
            get { return selectedWay; }
            set
            {
                selectedWay = value;
                OnPropertyChanged("SelectedWay");
            }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { 
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public RelayCommand IntoBoardCommand { get; set; }

        public RelayCommand SearchBoardCommand { get; set; }

        public TeamBoardViewModel()
        {
            Board = new MySQL().GetTeamBoardList();

            SearchWays = new ObservableCollection<SearchWay>
            {
                new SearchWay("제목"),
                new SearchWay("작성자")
            };

            IntoBoardCommand = new RelayCommand(IntoBoard);

            SearchBoardCommand = new RelayCommand(SearchBoard);

            SearchText = "검색어를 입력해주세요.";
        }

        public void IntoBoard(object obj)
        {
            selectedBoardNo = (int)obj;
        }

        public void SearchBoard(object obj)
        {
            if(SelectedWay != null)
            {
                Board = new MySQL().SearchBoard(SelectedWay.way, SearchText);
            } 
        }
    }
}
