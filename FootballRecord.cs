using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessData
{
    public class FootballRecord
    {
        public string Team { get; set; }
        public int For { get; set; }
        public int Against { get; set; }

        public FootballRecord() { } 
        public FootballRecord(string str)
        {
            Team = str.Substring(6,13).Trim();
            For = Convert.ToInt32(str.Substring(43, 2));
            Against = Convert.ToInt32(str.Substring(50, 2));
          

        }
    }
}
