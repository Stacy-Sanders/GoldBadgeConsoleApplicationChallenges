using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_KomodoOutings.Repository
{
    public class OutingsRepository
    {
        private List<Outings> _outingsContent = new List<Outings>();

        // Create
        public void AddOutingToList(Outings content)
        {
            _outingsContent.Add(content);
        }

        // Read
        public List<Outings> GetOutingsList()
        {
            return _outingsContent;
        }

        // Read total cost
        public decimal GetTotalEventCosts()
        {
            decimal initialValue = 0;
            foreach (var outing in _outingsContent)
            {
                initialValue += outing.TotalEventCost;
            }
            return initialValue;
        }

        // Read cost by event
        public decimal GetContentByOuting(EventType typeOfEvent)
        {
            decimal initialValue = 0;
            foreach (var outing in _outingsContent)
            {
                if (outing.TypeOfEvent == typeOfEvent)
                {
                    initialValue += outing.TotalEventCost;
                }
            }
            return initialValue;
        }

    }

}



