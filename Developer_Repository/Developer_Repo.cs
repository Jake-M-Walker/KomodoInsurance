using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer_POCO;
using DevTeam_POCO;

namespace Developer_Repository
{
    public class Developer_Repo
    {

        private readonly List<Developer> _developers = new List<Developer>();
        private int _count = 0;


        //Create
        public bool CreateDeveloper(Developer developer)
        {
            if (developer == null)
            {
                return false;
            }
            _count++;
            developer.ID = _count;
            _developers.Add(developer);
            return true;
        }

        //Read
        public List<Developer> GetDevelopers()
        {
            return _developers;
        }

        public Developer GetDeveloperByID(int id)
        {
            foreach(var developer in _developers)
            {
                if (id == developer.ID)
                    return developer;
            }
            return null;
        }

        //Update
        public bool UpdateDeveloper(int id, Developer newDeveloperData)
        {
            Developer oldDeveloperData = GetDeveloperByID(id);
            if(oldDeveloperData != null)
            {
                oldDeveloperData.ID = newDeveloperData.ID;
                oldDeveloperData.FirstName = newDeveloperData.FirstName;
                oldDeveloperData.LastName = newDeveloperData.LastName;
                oldDeveloperData.PluralSight = newDeveloperData.PluralSight;
                oldDeveloperData.TeamID = newDeveloperData.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteDeveloper (int id)
        {
            Developer developerToBeDeleted = GetDeveloperByID(id);
            if (developerToBeDeleted == null)
            {
                return false;
            }
            else
            {
                _developers.Remove(developerToBeDeleted);
                return true;
            }
        }


    }
}
