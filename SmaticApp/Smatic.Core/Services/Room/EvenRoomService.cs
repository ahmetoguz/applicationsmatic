using Smatic.Core.Data;
using Smatic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smatic.Core.Services.Room
{
    public class EventRoomService : IEventRoomService
    {
        IRepository<EventRoom> _eventRoomRepository;
       

        public EventRoomService(IRepository<EventRoom> eventRoomRepository)
        {
            this._eventRoomRepository = eventRoomRepository;
        }

        public IList<EventRoom> GetRooms()
        {
            return _eventRoomRepository.Table.ToList();
        }

        public void InsertRoom(EventRoom item)
        {
            _eventRoomRepository.Insert(item);
          
        }
    }
}
