using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_POCO
{
    public class DevTeam
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }

        public DevTeam () {}

        public DevTeam (string teamName)
        {
            TeamName = teamName;
        }


    }
}
