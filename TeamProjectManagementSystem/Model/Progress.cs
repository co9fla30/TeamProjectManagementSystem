using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectManagementSystem.Model
{
    class Progress 
    {
        public string user_Id { get; set; }
        public string user_NameAndId { get; set; }
        public string toDoListOneline { get; set; }
        public int percentage { get; set; }
        public ObservableCollection<ToDoList> toDoLists { get; set; }

        public Progress()
        {
            toDoLists = new ObservableCollection<ToDoList>();
        }
    }

    public class ToDoList
    {
        public int no { get; set; }
        public string text { get; set; }
        public bool done { get; set; }
    }
}
