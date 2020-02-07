using System;
using System.Collections.Generic;

namespace Smatic.Core.Entities
{
    public class Event : BaseEntity
    {
        public Event()
        {
            //Participants = new HashSet<Participant>();
        }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }


        public int EventRoomId { get; set; }

        public virtual EventRoom EventRoom { get; set; }

        //public virtual ICollection<Participant> Participants{ get; set; }
    }
}
