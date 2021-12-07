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

namespace TeamProjectManagementSystem.View
{
    /// <summary>
    /// TeamBoardView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TeamBoardView : Page
    {
        public TeamBoardView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/TeamBoardAddView.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/TeamBoardDetailView.xaml", UriKind.Relative));
        }

    }
}
