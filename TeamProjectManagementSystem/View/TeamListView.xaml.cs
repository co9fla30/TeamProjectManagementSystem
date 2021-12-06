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
    /// TeamListView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TeamListView : Page
    {
        
        public TeamListView()
        {
            InitializeComponent();
        }

        private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e) // 팀 추가
        {
            NavigationService.Navigate(new Uri("./View/TeamAddView.xaml", UriKind.Relative));
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/TeamView.xaml", UriKind.Relative));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/MyToDoListView.xaml", UriKind.Relative));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/ContestListView.xaml", UriKind.Relative));
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/LogInView.xaml", UriKind.Relative));
        }
    }
}
