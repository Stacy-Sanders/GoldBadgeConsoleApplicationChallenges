using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public string DoorName { get; set; }
        
        public Badges() { }

        public Badges(int badgeID, string doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }
    }
}

        

   
        


       
        
