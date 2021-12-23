using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutings.Repository
{
    public enum EventType
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }

    // POCO
    public class Outings
    {
        public EventType TypeOfEvent { get; set; }
        public int Attendance { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson 
        {
                get { return TotalEventCost / Attendance; }
        }
        public  decimal TotalEventCost { get; set; }
        public Outings() { }

        public Outings(EventType typeOfEvent, int attendance, DateTime dateOfEvent, decimal totalEventCost)
        {
            TypeOfEvent = typeOfEvent;
            Attendance = attendance;
            DateOfEvent = dateOfEvent;
            TotalEventCost = totalEventCost;
        }

    }

}
        


