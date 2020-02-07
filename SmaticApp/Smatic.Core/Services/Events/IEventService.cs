using Smatic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.Core.Services.Events
{
    public interface IEventService
    {
        void InsertEvent(Event item);

        void InsertParticipant(Participant item);
        IList<Participant> GetParticipantList();

        void InsertEvent_Partipicant(Event_Partipicant item);
       

    }
}
