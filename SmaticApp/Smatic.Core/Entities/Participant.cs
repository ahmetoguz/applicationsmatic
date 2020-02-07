using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.Core.Entities
{
    public class Participant : BaseEntity
    {
        public Participant()
        {
            //Events = new HashSet<Event>();
        }
        
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        //ICollection<Event> Events { get; set; }
        
    }
}
