using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.View;
using TeamProjectManagementSystem.ViewModel;

namespace TeamProjectManagementSystem.Model
{
    class MySQL2
    {
        MySqlConnection connection =
        new MySqlConnection("Server=localhost;Database=tpms;Uid=root;Pwd=1234;");

        public MySQL2()
        {
            connection.Open();
        }

        ~MySQL2()
        {
            connection.Close();
        }

        public void AddContest(Contest c)
        {
            string query = "insert into contest(title, s_date, e_date, entry, theme, host, site, image) values('"
                + c.Title + "', '" + c.StartDate + "', '" + c.EndDate + "', '" + c.Entry + "', '" + c.Theme + "', '"
                + c.Host + "', '" + c.Site + "', '" + c.Image + "'); ";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public ObservableCollection<Contest> LoadContestList()
        {
            ObservableCollection<Contest> contestList = new ObservableCollection<Contest>();

            string query = "select no, title, image from contest;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Contest c = new Contest
                {
                    No = (int)reader[0],
                    Title = reader[1].ToString(),
                    Image = (byte[])reader[2]
                };
                contestList.Add(c);
            }
            reader.Close();
            return contestList;
        }

        public Contest SelectedContestInfo()
        {
            string query = "select * from contest where no=" + ContestListViewModel.selectedNo + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Contest contestInfo = new Contest
            {
                No = (int)reader[0],
                Title = reader[1].ToString(),
                StartDate = reader[2].ToString(),
                EndDate = reader[3].ToString(),
                Entry = reader[4].ToString(),
                Theme = reader[5].ToString(),
                Host = reader[6].ToString(),
                Site = reader[7].ToString(),
                Image = (byte[])reader[8]
            };
            reader.Close();
            return contestInfo;
        }

        public void ContestTeamPostAdd(string title, string content)
        {
            string query = "insert into post(contest_no, writer_id, writer_name, title, content) " +
                "values('" + ContestListViewModel.selectedNo + "', '" + Page1.loginID + "', '"
                + Page1.loginUserName + "', '" + title + "', '" + content + "' );";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public ObservableCollection<Board> SelectedContestPost()
        {
            ObservableCollection<Board> TeamPost = new ObservableCollection<Board>();
            string query = "select * from post where contest_no=" + ContestListViewModel.selectedNo + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Board b = new Board
                {
                    no = (int)reader[0],
                    writer = reader[3].ToString(),
                    title = reader[4].ToString(),
                    content = reader[5].ToString(),
                    date = reader[6].ToString()
                };
                TeamPost.Add(b);
            }
            reader.Close();
            return TeamPost;
        }

        public void DeleteContestPost(int no)
        {
            string query = "delete from post where no='" + no + "'and writer_id='" + Page1.loginID + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
