using _04_KomodoOutings.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutings.UI
{
    public class ProgramUI
    {
        private OutingsRepository _outingsRepo = new OutingsRepository();

        // Method that runs/starts the application
        public void Run()
        {
            SeedContentList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display our options to the accountants
                Console.WriteLine("Select a menu option:\n" +
                    "1. Display All Outings\n" +
                    "2. Create New Outing\n" +
                    "3. View Total Cost of Outings\n" +
                    "4. View Cost By Outing Type\n" +
                    "5. Exit");

                // Get accountant's input
                string input = Console.ReadLine();

                // Evaluate accountant's input and proceed as directed
                switch (input)
                {
                    case "1":
                        // View All Outings
                        DisplayAllOutings();
                        break;
                    case "2":
                        // Create New Outing
                        CreateNewOuting();
                        break;
                    case "3":
                        // View Total Cost of Outings
                        //DisplayTotalCostOfOutings();
                        break;
                    case "4":
                        // View Cost By Outing Type
                        DisplayCostByOutingType();
                        break;
                    case "5":
                        // Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Display All Outings
        private void DisplayAllOutings()
        {
            Console.Clear();

            List<Outings> outingsContent = _outingsRepo.GetOutingsList();

            foreach (Outings content in outingsContent)
            {
                Console.WriteLine($"Outing Type:  {content.TypeOfEvent}\n" +
                    $"Attendance: {content.Attendance}\n" +
                    $"Date: {content.DateOfEvent}");
            }
        }

        // Create An Outing
        private void CreateNewOuting()
        {
            Console.Clear();
            Outings newOuting = new Outings();

            // Type of Event
            Console.WriteLine("Enter the event type number:\n" +
               "1. Golf\n" +
               "2. Bowling\n" +
               "3. Amusement Park\n" +
               "4. Concert");

            string typeofEventAsString = Console.ReadLine();
            int typeOfEventAsInt = int.Parse(typeofEventAsString);
            newOuting.TypeOfEvent = (EventType)typeOfEventAsInt;

            // Attendance
            Console.WriteLine("Enter the outing's attendance:");
            string attendanceAsString = Console.ReadLine();
            newOuting.Attendance = int.Parse(attendanceAsString);

            // Date of Event
            Console.WriteLine("Enter the date of the outing:");
            string dateOfEventAsString = Console.ReadLine();
            newOuting.DateOfEvent = DateTime.Parse(dateOfEventAsString);

            // Total Event Cost
            Console.WriteLine("Enter the total event cost:");
            string totalEventCostAsString = Console.ReadLine();
            newOuting.TotalEventCost = decimal.Parse(totalEventCostAsString);

            _outingsRepo.AddOutingToList(newOuting);
        }

        // View Total Cost of Outings
        /*private void DisplayTotalCostOfOutings()
        {
            Console.Clear();
            List<Outings> outingsContent = _outingsRepo.GetTotalEventCosts();

            foreach (var item in collection)
            {

            }
        }*/

        // View Cost By Outing Type
        private void DisplayCostByOutingType()
        {
            // Ask for the event type to view total cost
            Console.WriteLine("Enter the event type for which you would like to see total cost:\n" +
                "1. Golfing\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");

            // Get the accountant's input
            string typeOfEventAsString = Console.ReadLine();
            int typeOfEventAsInt = int.Parse(typeOfEventAsString);
            var typeOfEvent = (EventType)typeOfEventAsInt;

            _outingsRepo.GetContentByOuting(typeOfEvent);

            foreach (Outings initialValue in outings)
            {

            }
            {
                Console.WriteLine($"Total cost: {initialValue.TypeOfEvent}");
            }

            /*var outing = _outingsRepo.GetContentByOuting(typeOfEvent);
            object initialValue = null;
            Console.WriteLine($"Event Cost: {TotalEventCost}");*/
            
        }
            
            



        // Seed method - testing
        private void SeedContentList()
        {
            Outings golfScramble1 = new Outings(EventType.Golf, 132, new DateTime(2019, 05, 14), 9900m);
            Outings concert1 = new Outings(EventType.Concert, 300, new DateTime(2019, 11, 25), 5000m);
            Outings amusementPark1 = new Outings(EventType.AmusementPark, 100, new DateTime(2019, 07, 04), 1000m);
            Outings bowling1 = new Outings(EventType.Bowling, 25, new DateTime(2019, 10, 31), 1000m);

            _outingsRepo.AddOutingToList(golfScramble1);
            _outingsRepo.AddOutingToList(concert1);
            _outingsRepo.AddOutingToList(amusementPark1);
            _outingsRepo.AddOutingToList(bowling1);
        }

    }
}
                        
