using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.ViewModel
{
    class ContestDetailViewModel:Notifier
    {
        public Contest ContestInfo { get; set; }

        private ObservableCollection<Board> postDetail;
        public ObservableCollection<Board> PostDetail
        {
            get { return postDetail; }
            set
            {
                postDetail = value;
                OnPropertyChanged("PostDetail");
            }
        }

        public RelayCommand PostDeleteCommand { get; set; }

        public ContestDetailViewModel()
        {
            ContestInfo = new MySQL2().SelectedContestInfo();
            PostDetail = new MySQL2().SelectedContestPost();
            PostDeleteCommand = new RelayCommand(PostDelete);
        }

        private void PostDelete(object obj)
        {
            new MySQL2().DeleteContestPost((int)obj);
            PostDetail = new MySQL2().SelectedContestPost();
        }
    }
}
