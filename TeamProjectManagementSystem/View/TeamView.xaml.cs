using System;
using System.Collections.Generic;
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
using TeamProjectManagementSystem.ViewModel;

namespace TeamProjectManagementSystem.View
{
    /// <summary>
    /// TeamView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TeamView : Page
    {
        public TeamView()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/TeamBoardView.xaml", UriKind.Relative));
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/TeamToDoListView.xaml", UriKind.Relative));
        }
    }
}
