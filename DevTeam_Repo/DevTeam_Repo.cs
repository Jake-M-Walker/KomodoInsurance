using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer_POCO;
using Developer_Repository;
using DevTeam_POCO;


namespace DevTeam_Repository
{
    public class DevTeam_Repo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();
        private int _count = 0;

        //Create
        public bool CreateDevTeam(DevTeam devTeam)
        {
            if(devTeam == null)
            {
                return false;
            }
            _count++;
            devTeam.TeamID = _count;
            _devTeams.Add(devTeam);
            return true;
        }

        //Read
        public List<DevTeam> GetDevTeams()
        {
            return _devTeams;
        }

        public DevTeam GetDevTeamByID(int teamID)
        {
            foreach(var devTeam in _devTeams)
            {
                if (teamID == devTeam.TeamID)
                    return devTeam;
            }
            return null;
        }


        //Update
        public bool UpdateDevTeam(int teamID, DevTeam newDevTeamData)
        {
            DevTeam oldDevTeamData = GetDevTeamByID(teamID);
            if(oldDevTeamData != null)
            {
                oldDevTeamData.TeamID = newDevTeamData.TeamID;
                oldDevTeamData.TeamName = newDevTeamData.TeamName;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteDevTeam(int teamID)
        {
            DevTeam devTeamToBeDeleted = GetDevTeamByID(teamID);
            if (devTeamToBeDeleted == null)
            {
                return false;
            }
            else
            {
                _devTeams.Remove(devTeamToBeDeleted);
                return true;
            }
        }



    }
}
