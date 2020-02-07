using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.Core.Entities
{
    public class Event_Partipicant : BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int PartipicantId { get; set; }
        public Participant Partipicant { get; set; }

        public bool Status { get; set; }

        /// <summary>
        /// Toplantıyı oluşturan kişimi.
        /// </summary>
        public bool IsOwner { get; set; }
    }
}
