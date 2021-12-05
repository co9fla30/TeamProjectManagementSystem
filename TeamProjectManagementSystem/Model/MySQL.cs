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
    class MySQL
    {
        MySqlConnection connection =
        new MySqlConnection("Server=localhost;Database=tpms;Uid=root;Pwd=1234;");

        public MySQL()
        {
            connection.Open();
        }

        ~MySQL()
        {
            connection.Close();
        }

        public string Login(string id, string pwd)
        {
            try
            {
                string query = "select id from user where(id = '" + id + "' and pwd = '" + pwd + "');";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                string rId = reader[0].ToString();

                reader.Close();
                return rId;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public void Register(string id, string pwd, string name)
        {
            string query = "insert into user(id,pwd,name) values('" + id + "','" + pwd + "', '" + name + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public ObservableCollection<GroupListInfo> LoadGroupList()
        {
            ObservableCollection<GroupListInfo> groupList = new ObservableCollection<GroupListInfo>();

            string query = "select team_name from team_member where(user_id = '" + Page1.loginID + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupListInfo groupListInfo = new GroupListInfo();
                groupListInfo.team_Name = reader[0].ToString();
                groupList.Add(groupListInfo);
            }
            reader.Close();
            return groupList;
        }

        public string FindUser(string userId)
        {
            try
            {
                string query = "select name from user where(id = '" + userId + "');";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                string name = reader[0].ToString();
                reader.Close();

                return name;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void MakeTeam(Team team, ObservableCollection<string> userIds)
        {
            // team 데이터 생성
            string query = "insert into team(name, intro) values('" + team.name + "','" + team.intro + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();

            // team_member 데이터 생성
            foreach (string userId in userIds)
            {
                string query2 = "insert into team_member(user_id, team_name) values('" + userId + "','" + team.name + "');";
                MySqlCommand command2 = new MySqlCommand(query2, connection);
                command2.ExecuteNonQuery();
            }
        }

        public string GetIntro()
        {
            string query = "select intro from team where(name = '" + TeamListViewModel.selectedTeam + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string intro = reader[0].ToString();
            reader.Close();
            return intro;
        }

        public ObservableCollection<MemoOrSchedule> GetMemo()
        {
            ObservableCollection<MemoOrSchedule> memos = new ObservableCollection<MemoOrSchedule>();

            string query = "select no, user_id,date,text from " +
                "memo_schedule where(team_name = '" + TeamListViewModel.selectedTeam + "' and " +
                "type = 'memo') order by no desc;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MemoOrSchedule memo = new MemoOrSchedule();
                memo.no = (int)reader[0];
                memo.user_NameAndId = reader[1].ToString();
                memo.date = reader[2].ToString();
                memo.text = reader[3].ToString();
                memos.Add(memo);
            }
            reader.Close();

            // id + Name
            int i = 0;
            foreach (string id in memos.Select(x => x.user_NameAndId))
            {
                memos[i].user_NameAndId = GetUserNameByUserId(id) + " (" + id + ")";
                i++;
            }
            return memos;
        }

        public ObservableCollection<MemoOrSchedule> GetSchedule()
        {
            ObservableCollection<MemoOrSchedule> schedules = new ObservableCollection<MemoOrSchedule>();

            string query = "select no, user_id,date,text from " +
                "memo_schedule where(team_name = '" + TeamListViewModel.selectedTeam + "' and " +
                "type = 'schedule') order by date desc;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MemoOrSchedule schedule = new MemoOrSchedule();
                schedule.no = (int)reader[0];
                schedule.user_NameAndId = reader[1].ToString();
                schedule.date = reader[2].ToString();
                schedule.text = reader[3].ToString();
                schedules.Add(schedule);
            }
            reader.Close();
            return schedules;
        }

        public string GetUserNameByUserId(string id)
        {
            string query = "select name from user where(id = '" + id + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string name = reader[0].ToString();
            reader.Close();
            return name;
        }

        public ObservableCollection<Progress> GetProgress()
        {
            ObservableCollection<Progress> progresses = new ObservableCollection<Progress>();

            string query = "select user_id,percentage from " +
                "team_member where(team_name = '" + TeamListViewModel.selectedTeam + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Progress progress = new Progress();
                progress.user_Id = reader[0].ToString();
                progress.user_NameAndId = reader[0].ToString();
                progress.percentage = (int)reader[1];
                progresses.Add(progress);
            }
            reader.Close();

            // 할 일 목록 가져오기
            int i = 0;
            foreach (string id in progresses.Select(x => x.user_NameAndId))
            {
                string query2 = "select no,text,done from " +
                "todo where(team_name = '" + TeamListViewModel.selectedTeam + "' and " +
                "user_id = '" + id + "') order by no desc;";
                MySqlCommand command2 = new MySqlCommand(query2, connection);
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    ToDoList toDoList = new ToDoList
                    {
                        no = (int)reader2[0],
                        text = reader2[1].ToString(),
                        done = (bool)reader2[2]
                    };
                    progresses[i].toDoLists.Add(toDoList);
                    // 할 일 한줄로도 만들어줌
                    progresses[i].toDoListOneline += reader2[1].ToString() + ", ";
                }
                if (progresses[i].toDoListOneline != null)
                    progresses[i].toDoListOneline = progresses[i].toDoListOneline.Substring(0, progresses[i].toDoListOneline.Length - 2);
                reader2.Close();
                // 유저 이름 + 아이디 합치기
                progresses[i].user_NameAndId = GetUserNameByUserId(id) + " (" + id + ")";
                i++;
            }
            return progresses;
        }

        public void InsertMemoOrSchedule(string type, string memo, string date)
        {
            string query = "insert into memo_schedule(type, team_name, user_id, date, text)" +
                " values('" + type + "','" + TeamListViewModel.selectedTeam + "','" + Page1.loginID + "','" +
                date + "','" + memo + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void DeleteMemoOrSchedule(int no)
        {
            string query = "delete from memo_schedule where no = '" + no + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void TeamBoardAdd(string title, string content)
        {
            string query = "insert into teamboard(team_name, user_id, title, writer, content) " +
                "values('" + TeamListViewModel.selectedTeam + "', '" + Page1.loginID + "', '"
                + title + "', '" + Page1.loginUserName + "', '" + content + "' );";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public ObservableCollection<Board> GetTeamBoardList()
        {
            ObservableCollection<Board> BoardList = new ObservableCollection<Board>();
            string query = "select no, title, date, writer from teamboard user where "
               + "(team_name = '" + TeamListViewModel.selectedTeam + "') order by date desc;";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Board b = new Board
                {
                    no = (int)reader[0],
                    title = reader[1].ToString(),
                    date = reader[2].ToString(),
                    writer = reader[3].ToString(),
                };
                BoardList.Add(b);
            }
            connection.Close();
            return BoardList;
        }

        public Board ShowBoard()
        {
            string query = "select title, date, writer, content from teamboard where no="
                + TeamBoardViewModel.selectedBoardNo + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            Board b = new Board
            {
                no = TeamBoardViewModel.selectedBoardNo,
                title = reader[0].ToString(),
                date = reader[1].ToString(),
                writer = reader[2].ToString(),
                content = reader[3].ToString()
            };
            reader.Close();
            return b;
        }

        public void UpdateDoneCheck(int no, bool check)
        {
            string query = "update todo set done=" + check + " where no='" + no + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void AddToDo(string userId, string text)
        {
            string query = "insert into todo(team_name, user_id, text) values('" + TeamListViewModel.selectedTeam + "', '" + userId + "', '"
                + text + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void DeleteToDo(int no)
        {
            string query = "delete from todo where no='" + no + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public void UpdatePercentage(int percentage, string user_id)
        {
            string query = "update team_member set percentage=" + percentage +
                " where team_name='" + TeamListViewModel.selectedTeam + "' and user_id = '" + user_id + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        public bool GetDoneState(int no)
        {
            string query = "select done from todo where no="
                + no + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool b = (bool)reader[0];
            reader.Close();
            return b;
        }
    }
}
