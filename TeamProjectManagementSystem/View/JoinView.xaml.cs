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
    /// Joinpage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Joinpage : Page
    {
        public Joinpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new MySQL().Register(newId.Text, newPwd.Text, newName.Text);
                NavigationService.Navigate(new Uri("./View/LoginView.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                MessageBox.Show("동일 id가 존재합니다.");
            }
        }
    }
}
