﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        
        public Badges() { }

        public Badges(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
    }
}

        

   
        


       
        
