using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectManagementSystem.Model
{
    class MemoOrSchedule // 간단 메모, 일정
    {
        public int no { get; set; }
        public string user_NameAndId { get; set; }
        public string date { get; set; }
        public string text { get; set; }
    }
}
