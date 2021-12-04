﻿using Microsoft.Win32;
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
    /// ContestAddView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContestAddView : Page
    {
        Contest contest;
        public ContestAddView()
        {
            InitializeComponent();
            contest = new Contest();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contest.Title = contestName.Text;
            contest.StartDate = startDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            contest.EndDate = endDate.SelectedDate.Value.ToString("yyyy-MM-dd");
            contest.Entry = entry.Text;
            contest.Theme = theme.Text;
            contest.Host = host.Text;
            contest.Site = site.Text;
            //contest.Image
            new MySQL2().AddContest(contest);
            NavigationService.Navigate(new Uri("./View/ContestListView.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileDialog open = new OpenFileDialog();
            open.Filter = "image | *.jpg; *.png; *.jpeg";
            open.ShowDialog();
        }
    }
}