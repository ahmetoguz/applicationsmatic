using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.Core.Entities
{
    public class EventRoom : BaseEntity
    {
        public EventRoom()
        {
            Events = new HashSet<Event>();
        }
       

        public string Name { get; set; }

        public int Capacity { get; set; }

        public DateTime? OpenDate { get; set; }

        public DateTime? CloseDate { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
