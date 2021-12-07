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

namespace TeamProjectManagementSystem
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //팀
        {
            this.frame.Navigate(new Uri("./View/TeamListView.xaml", UriKind.Relative));
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //할 일
        {
            this.frame.Navigate(new Uri("./View/MyToDoListView.xaml", UriKind.RelativeOrAbsolute));
        }
        
        private void MenuItem_Click_3(object sender, RoutedEventArgs e) //공모전
        {
            this.frame.Navigate(new Uri("./View/ContestListView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) //로그아웃
        {
            this.frame.Navigate(new Uri("./View/LogInView.xaml", UriKind.RelativeOrAbsolute));
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.frame.Navigate(new Uri("./View/TeamView.xaml", UriKind.Relative));
        }

        private void ListViewItem_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.frame.Navigate(new Uri("./View/TeamBoardView.xaml", UriKind.Relative));
        }

        private void ListViewItem_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            this.frame.Navigate(new Uri("./View/TeamToDoListView.xaml", UriKind.Relative));
        }
    }
}
