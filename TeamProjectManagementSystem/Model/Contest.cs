using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectManagementSystem.Model
{
    class Contest
    {
        public int No { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Entry { get; set; }
        public string Theme { get; set; }
        public string Host { get; set; }
        public string Site { get; set; }
        public byte[] Image { get; set; }
    }
}
