using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamProjectManagementSystem.Model;

namespace TeamProjectManagementSystem.View
{
    /// <summary>
    /// TeamAddView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TeamAddView : Page
    {
        Team team;

        public ObservableCollection<string> userIds;

        public TeamAddView()
        {
            InitializeComponent();
            team = new Team();        
            userIds = new ObservableCollection<string>();
            userIds.Add(Page1.loginID);
            this.DataContext = userIds;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // 팀원 검색 및 추가
        {
            if (new MySQL().FindUser(userId.Text) != null && userIds.Contains(userId.Text) == false)
            {
                userIds.Add(userId.Text);
            }
            else
                MessageBox.Show("유저 ID를 다시 입력해주세요.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // 팀 추가
        {
            team.name = team_Name.Text;
            team.intro = intro.Text;
            new MySQL().MakeTeam(team, userIds);
            NavigationService.Navigate(new Uri("./View/TeamListView.xaml", UriKind.Relative));
        }
    }
}
