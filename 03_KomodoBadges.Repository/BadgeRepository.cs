using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KomodoBadges.Repository
{
    public class BadgeIDRepository
    {
        private Dictionary<int, Badges> _badgeList = new Dictionary<int, Badges>();
        private int _count;
        // Create
        public bool AddBadgeToList (Badges badge)
        {
            if (badge is null)
            {
                return false;
            }
            else
            {
                _count++;
                badge.BadgeID = _count;
                _badgeList.Add(badge.BadgeID, badge);

                return true;
            }
        }

        // Read
        public Dictionary<int, Badges> GetBadgeList()
        {
            return _badgeList;
        }


        // Helper Method
        public Badges GetBadgeByKey(int key)
        {
            foreach (var badge in _badgeList)
            {
                if (badge.Key==key)
                {
                    return badge.Value;
                }
            }
            return null;
        }

        // Update
        public bool AddDoor(int key, string doorName)
        {
            var badge = GetBadgeByKey(key);
            if (badge != null)
            {
                badge.DoorNames.Add(doorName);
                return true;
            }
            return false;
        }
        public bool RemoveDoor(int key, string doorName)
        {
            var badge = GetBadgeByKey(key);
            if (badge != null)
            {
                foreach (var door in badge.DoorNames)
                {
                    if (door==doorName)
                    {
                        badge.DoorNames.Remove(door);
                        return true;
                    }

                }
            }
            return false;
        }

    }
}

       
            
    
    
    
       
        
