using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectManagementSystem.ViewModel;

namespace TeamProjectManagementSystem.Model
{
    class MySQL2
    {
        MySqlConnection connection =
        new MySqlConnection("Server=localhost;Database=tpms;Uid=root;Pwd=a025763;");

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
    }
}
