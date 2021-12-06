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

namespace TeamProjectManagementSystem.View
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : Page
    {
        public static string loginID;
        public static string loginUserName;

        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (enteredId.Text == new MySQL().Login(enteredId.Text, enteredPwd.Password))
            {
                loginID = enteredId.Text;
                loginUserName = new MySQL().FindUser(loginID);
                NavigationService.Navigate(new Uri("./View/TeamListView.xaml", UriKind.Relative));
            }
            else
                MessageBox.Show("아이디/비밀번호를 다시 확인해주세요.");           
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Uri("./View/JoinView.xaml", UriKind.Relative));
        }
    }
}
