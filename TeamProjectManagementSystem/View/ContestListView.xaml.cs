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
    /// ContestListView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContestListView : UserControl
    {
        public ContestListView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("./View/ContestDetailView.xaml", UriKind.Relative));
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("./View/ContestAddView.xaml", UriKind.Relative));
        }
    }
}
