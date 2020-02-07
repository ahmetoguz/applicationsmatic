using Smatic.Core.Data;
using Smatic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smatic.Core.Services.Events
{
    public class EventService : IEventService
    {
        IRepository<Event> _eventRepository;

        IRepository<Participant> _partipicantRepository;

        IRepository<Event_Partipicant> _eventParticipantRepository;

        public EventService(IRepository<Event> eventRepository, IRepository<Participant> partipicantRepository, IRepository<Event_Partipicant> eventParticipantRepository)
        {
            _eventRepository = eventRepository;
            _partipicantRepository = partipicantRepository;
            _eventParticipantRepository = eventParticipantRepository;
        }

        public IList<Participant> GetParticipantList()
        {
            return _partipicantRepository.Table.ToList();
        }

        public void InsertEvent(Event item)
        {
            _eventRepository.Insert(item);
        }

        public void InsertEvent_Partipicant(Event_Partipicant item)
        {
            _eventParticipantRepository.Insert(item);
        }



        public void InsertParticipant(Participant item)
        {
            _partipicantRepository.Insert(item);
        }


    }
}
