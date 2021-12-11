using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Developer_POCO;
using Developer_Repository;
using DevTeam_POCO;
using DevTeam_Repository;

namespace KomodoInsurance_UI
{
    class Program_UI
    {
        private readonly Developer_Repo _developerRepo = new Developer_Repo();
        private readonly DevTeam_Repo _devTeamRepo = new DevTeam_Repo();

        public void Run()
        {
            //Seed();
            RunApplication();
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Komodo Insurance Developer Team Management Application\n\n" + 
                "1. Create Developer\n" + 
                "2. Create Developer Team\n" + 
                "3. View All Developers\n" + 
                "4. View All Developer Teams\n" + 
                "5. View Single Developer\n" + 
                "6. View Single Team\n" + 
                "7. Update Developer\n" + 
                "8. Update Developer Team\n" + 
                "9. Delete Developer\n" +
                "10. Delete Developer Team\n" +
                "11. Exit"
                );
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                SeedContentList();
                Menu();
                string UserInput = Console.ReadLine();
                switch (UserInput)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        CreateDevTeam();
                        break;
                    case "3":
                        ViewAllDevelopers();
                        break;
                    case "4":
                        ViewAllDevTeams();
                        break;
                    case "5":
                        ViewDeveloper();
                        break;
                    case "6":
                        ViewDevTeam();
                        break;
                    case "7":
                        UpdateDeveloper();
                        break;
                    case "8":
                        UpdateDevTeam();
                        break;
                    case "9":
                        DeleteDeveloper();
                        break;
                    case "10":
                        DeleteDevTeam();
                        break;
                    case "11":
                        isRunning = false;
                        break;
                    default:
                        break;

                    

                }
            }
        }


        private void CreateDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();
            //First Name
            Console.WriteLine("Please eneter the Developer's First Name");
            newDeveloper.FirstName = Console.ReadLine();
            //Last Name
            Console.WriteLine("Please enter the Developer's Last Name");
            newDeveloper.LastName = Console.ReadLine();
            //PluralSight
            Console.WriteLine("Please enter yes if the Developer has access to PluralSight or no if they do not have access");
            newDeveloper.PluralSight = Console.ReadLine();
            //Team ID
            Console.WriteLine("Please enter the Team ID the new Developer will be on");
            string teamIDasString = Console.ReadLine();
            newDeveloper.TeamID = int.Parse(teamIDasString);

            _developerRepo.CreateDeveloper(newDeveloper);


            bool isSuccessful = _developerRepo.CreateDeveloper(newDeveloper);
            if (isSuccessful)
            {
                Console.WriteLine($"{newDeveloper.FirstName} {newDeveloper.LastName} was successfully added to the database");
            }
            else
            {
              
                Console.WriteLine($"{newDeveloper.FirstName} {newDeveloper.LastName} was not added to the database");
            }

        } //Done


        private void CreateDevTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();
            //Get Team Name
            Console.WriteLine("Please enter the new team's name");
            newDevTeam.TeamName = Console.ReadLine();

            _devTeamRepo.CreateDevTeam(newDevTeam);
            bool isSuccessful = _devTeamRepo.CreateDevTeam(newDevTeam);
            if (isSuccessful)
            {
                Console.WriteLine($"{newDevTeam.TeamName} was successfully added to the database");
            }
            else
            {
                Console.WriteLine($"{newDevTeam.TeamName} was not added to the database");
            }
        } //Done

        private void DisplayDeveloperInfo(Developer developer) 
        {
            Console.WriteLine($"Developer ID: {developer.ID}\n" +
                $"Developer's First Name: {developer.FirstName}\n" +
                $"Developer's Last Name: {developer.LastName}\n" +
                $"PluralSight Access: {developer.PluralSight}\n" +
                $"Developer's Team ID: {developer.TeamID}");
            Console.WriteLine("*********************************");

        } //Done

        private void DisplayDevTeamInfo(DevTeam devTeam)
        {
            Console.WriteLine($"Team ID: {devTeam.TeamID}\n" +
                $"Team Name: {devTeam.TeamID}\n");
        } //Done
        
        
        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> ListOfAllDevelopers = _developerRepo.GetDevelopers();
            foreach(var developer in ListOfAllDevelopers)
            {
                DisplayDeveloperInfo(developer);
               // Console.ReadKey();
            }
        } //Done

        private void ViewAllDevTeams()
        {
            Console.Clear();
            List<DevTeam> ListOfAllDevTeams = _devTeamRepo.GetDevTeams();
            List<Developer> ListofAllDevelopers = _developerRepo.GetDevelopers();
            foreach(var devTeam in ListOfAllDevTeams)
            {
                DisplayDevTeamInfo(devTeam);
            }
        } //Needs work

        private void ViewDeveloper()
        {
            Console.Clear();
            Console.WriteLine("What Developer would you like to view? Please enter their ID.");
            int userInputViewDeveloperID = int.Parse(Console.ReadLine());
            Developer developer = _developerRepo.GetDeveloperByID(userInputViewDeveloperID);
            DisplayDeveloperInfo(developer);
            Console.ReadKey();

        } //Done

        private void ViewDevTeam()
        {
            Console.Clear();
            Console.WriteLine("What Developer Team would you like to view? Please enter their ID.");
            int userInputViewTeamID = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetDevTeamByID(userInputViewTeamID);
            DisplayDevTeamInfo(devTeam);
            Console.ReadKey();
        } //Done

        private void UpdateDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Plese enter the Developer's ID you would like to update");
            int userInputDevUpdate = int.Parse(Console.ReadLine());
            Developer developer = _developerRepo.GetDeveloperByID(userInputDevUpdate);
            Developer newDeveloper = new Developer();
            //First Name
            Console.WriteLine("Please eneter the Developer's First Name");
            newDeveloper.FirstName = Console.ReadLine();
            //Last Name
            Console.WriteLine("Please enter the Developer's Last Name");
            newDeveloper.LastName = Console.ReadLine();
            //PluralSight
            Console.WriteLine("Please enter yes if the Developer has access to PluralSight or no if they do not have access");
            newDeveloper.PluralSight = Console.ReadLine();
            //Team ID
            Console.WriteLine("Please enter the Team ID the new Developer will be on");
            string teamIDasString = Console.ReadLine();
            newDeveloper.TeamID = int.Parse(teamIDasString);

            _developerRepo.UpdateDeveloper(userInputDevUpdate, newDeveloper);



        } //Done

        private void UpdateDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Team's ID you would like to update");
            int userInputTeamIDUpdate = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetDevTeamByID(userInputTeamIDUpdate);
            DevTeam newDevTeam = new DevTeam();
            Console.WriteLine("Please enter the new team's name");
            newDevTeam.TeamName = Console.ReadLine();

            _devTeamRepo.UpdateDevTeam(userInputTeamIDUpdate, newDevTeam);
        } //Done
        private void DeleteDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please enter ID");
            int userinput = int.Parse(Console.ReadLine());
            Developer developer = _developerRepo.GetDeveloperByID(userinput);
            DisplayDeveloperInfo(developer);
            Console.WriteLine("Is this the developer you want to delete? (y/n)");
            string userConfirm = Console.ReadLine().ToLower() ;
            if (userConfirm == "y")
            {
                bool wasDeleted = _developerRepo.DeleteDeveloper(userinput);
                if (wasDeleted)
                {
                    Console.WriteLine($"{userinput} was successfully deleted");
                }
                else
                {
                    Console.WriteLine($"{userinput} was not deleted");
                }
            }
            else
            {
                Console.WriteLine("Please enter the ID for the Develope you would like to Delete");
                userinput = int.Parse(Console.ReadLine());
            }
            
        } //Done

        private void DeleteDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Team's ID you would like to delete");
            int userInput = int.Parse(Console.ReadLine());
            DevTeam devTeam = _devTeamRepo.GetDevTeamByID(userInput);
            DisplayDevTeamInfo(devTeam);
            Console.WriteLine("Is this developer you would like to remove? Y/N");
            string userConfirm = Console.ReadLine().ToUpper();
            if(userConfirm == "Y")
            {
               bool wasDeleted =  _devTeamRepo.DeleteDevTeam(userInput);
                if (wasDeleted)
                {
                    Console.WriteLine($"{wasDeleted} was successfully deleted");
                }
                else
                {
                    Console.WriteLine($"{wasDeleted} was not deleted");
                }
            }
            else
            {
                Console.WriteLine("Please enter the Team's ID you would like to remove.");
                userInput = int.Parse(Console.ReadLine());
            }

        } //Done


        //Seed
        private void SeedContentList()
        {
            Developer dev1 = new Developer("Hal", "Jordan", "Yes", 1);
            Developer dev2 = new Developer("Clark", "Kent", "Yes", 1);
            Developer dev3 = new Developer("Bruce", "Wayne", "No", 1);

            Developer dev4 = new Developer("Peter", "Parker", "No", 2);
            Developer dev5 = new Developer("Tony", "Stark", "Yes", 2);
            Developer dev6 = new Developer("Bruce", "Banner", "No", 2);

            _developerRepo.CreateDeveloper(dev1);
            _developerRepo.CreateDeveloper(dev2);
            _developerRepo.CreateDeveloper(dev3);
            _developerRepo.CreateDeveloper(dev4);
            _developerRepo.CreateDeveloper(dev5);
            _developerRepo.CreateDeveloper(dev6);

            DevTeam devTeam1 = new DevTeam("DC");
            DevTeam devTeam2 = new DevTeam("Marvel");

            _devTeamRepo.CreateDevTeam(devTeam1);
            _devTeamRepo.CreateDevTeam(devTeam2);

        } //Done

    }
}
