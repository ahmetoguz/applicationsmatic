using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;


namespace Smatic.InviteUI.Models
{
    public class EventModel
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string CreatedBy { get; set; }

        public string Partipicants { get; set; }

        public int EventRoomId { get; set; }

        public List<SelectListItem> RoomList { get; set; }
    }
}