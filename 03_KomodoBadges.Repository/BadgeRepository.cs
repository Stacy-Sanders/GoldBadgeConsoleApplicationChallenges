using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class BadgeIDRepository
    {
        private List<Badges> _badgeList = new List<Badges>();
        public void BadgeAccessList()
        {
            var badges = new Dictionary<int, string>()
            {
            { 12345, "A2, A7, B4"},
            { 22345, "A2, A3, C8"},
            { 32345, "B3, B4"}
            };
        }

        // Create
        public void AddBadgeToList (Badges badge)
        {
            _badgeList.Add(badge);
        }

        // Read
        public List<Badges> GetBadgeList()
        {
            return _badgeList;
        }


        // Helper Method
        

        // Update
        public bool UpdateDoorAccess(string orignalAccess, Badges newAccess)
        {
            // Find the Access

            //Update the Access
            if(IDictionary.ContainsKey(originalAccess))
        }

        // Delete
    
    
    }
}
    
    
       
        
