using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevTeam_POCO;

namespace Developer_POCO
{
    public class Developer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PluralSight { get; set; }
        public int TeamID { get; set; }

        public Developer() {}
        public Developer(string firstName, string lastName, string pluralSight, int teamID)
        {
            FirstName = firstName;
            LastName = lastName;
            PluralSight = pluralSight;
            TeamID = teamID;
        }
    }
}
