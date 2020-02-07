using Smatic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smatic.Core.Services.Room
{
    public interface IEventRoomService
    {
       IList<EventRoom> GetRooms();

        void InsertRoom(EventRoom item);


    }
}
