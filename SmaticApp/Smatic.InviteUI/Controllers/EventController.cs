using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smatic.Core.Entities;
using Smatic.Core.Model;
using Smatic.Core.Services.Events;
using Smatic.Core.Services.RabbitQueue;
using Smatic.Core.Services.Room;
using Smatic.InviteUI.Models;

namespace Smatic.InviteUI.Controllers
{
    public class EventController : Controller
    {
        IEventRoomService _roomService;
        IEventService _eventService;
        IRabbitMQService _rabbitMQService;

        public EventController(IEventRoomService roomService, IEventService eventService, IRabbitMQService rabbitMQService)
        {
            _roomService = roomService;
            _eventService = eventService;
            _rabbitMQService = rabbitMQService;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(EventModel model)
        {
            //Oda bilgilerini her zaman getiriyoruz... Dropdownda yeniden doldurmak için.
            var roomlist = _roomService.GetRooms();
            List<SelectListItem> roomList = (from k in roomlist
                                             select new SelectListItem
                                             {
                                                 Text = k.Name,
                                                 Value = k.Id.ToString()
                                             }).ToList();


            //Başlangıç ve bitiş tarihlerini default olarak atadım.
            model.StartDate = DateTime.Now;
            model.EndDate = DateTime.Now.AddHours(1);

            //Toplantı sahibi oluşturucusu olarak default olarak bir test mail adresi atadım.
            model.CreatedBy = "testogz21@gmail.com";


            //davet ettiğim kullanıcıları burada sabit girdiğimi düşünün.
            model.Partipicants = "testogz21@gmail.com;emirhanoguz.net@gmail.com;ahmetoguz.net@gmail.com";

            var participantinvitedEmailList = model.Partipicants.Split(";");

            //girilen her mail adresine ait katılımcı Toplantı-Katılımcı ara tablosuna yazılacak mail gönderilecek davetli listesi.
            List<Participant> invitedList = new List<Participant>();

            //Burada tüm domain kullanıcılarının listesini aldım. Uygulama büyük olsaydı almazdım.
            var domainUserList = _eventService.GetParticipantList();

            //Davet edilecek kullanıcıları db'den belirlemiş olduk...
            participantinvitedEmailList.ToList().ForEach(emailitem =>
            {
                var participantuser = domainUserList.Where(i => i.Email == emailitem).FirstOrDefault();
                invitedList.Add(participantuser);
            });


            model.RoomList = roomList;
            Event eventItem = new Event();
            eventItem.StartDate = model.StartDate;
            eventItem.EndDate = model.EndDate;
            eventItem.Name = model.Name;
            eventItem.EventRoomId = model.EventRoomId;


            //1- Toplantı(Event) Bilgisini Kaydettim.
            _eventService.InsertEvent(eventItem);
           
            //2- Toplantı ve Katlımcı Ara tablosuna Davet edilecek veya edilen katılımcıların listesini yazıyoruz.
            invitedList.ForEach(item =>
            {
                Event_Partipicant ep = new Event_Partipicant();
                ep.EventId = eventItem.Id; //Yukarıda oluşturduğum
                ep.PartipicantId = item.Id; // KatılımcıId;

                //Toplantıyı oluşturan kişinin katılım durumu(status) 0 set edilir.
                if (model.CreatedBy == item.Email)
                {
                    ep.IsOwner = true;
                    ep.Status = true; //Toplantıyı düzenlediği için doğal olarak toplanyıa katılacak onun için status-true
                }
                else
                {
                    ep.IsOwner = false;
                    ep.Status = false; //Henüz kullanıcılara davet maili gitmedi. Varsayılan katılım durumu false olarak işaretliyoruz.
                }

                _eventService.InsertEvent_Partipicant(ep);
            });

            var ownerParticipant = invitedList.Where(ow => ow.Email == model.CreatedBy).FirstOrDefault();
            EmailModel emailModel = new EmailModel();

            //Şirket kullanıcılarına email daveti gönder...
            invitedList.ForEach(item =>
            {
                EmailModel mailModel = new EmailModel();
                mailModel.Body = $"<h2>Merhaba {item.Name + " " + item.SurName}, {ownerParticipant.Name + " " + ownerParticipant.SurName} size bir toplantı daveti gönderdi.</h2>  Katılıyor musunuz? <br> <a href=''>Katılıyorum.</a><br>" +
                "<a href='{callbackUrl}'>Katılmıyorum.</a>";
               
                mailModel.To = item.Email;
                mailModel.Subject = eventItem.Name; // Toplantı adı veya konusu
                mailModel.From = ownerParticipant.Email;
                mailModel.Name = ownerParticipant.Name + " " + ownerParticipant.SurName;

                //Her kullanıcı için publisher'a burada bir davet olduğunu bildiriyorum. Bir list olarakta verilebilir.
                _rabbitMQService.SendEmailToRabbitMQ(mailModel);

            });

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            EventModel model = new EventModel();
            var roomlist = _roomService.GetRooms();

            List<SelectListItem> roomList = (from k in roomlist
                                             select new SelectListItem
                                             {
                                                 Text = k.Name,
                                                 Value = k.Id.ToString()
                                             }).ToList();

            model.RoomList = roomList;

            return View(model);
        }

        /// <summary>
        /// Bu view çağrılarak toplantı odası oluşturulur.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateRoom()
        {
            _roomService.InsertRoom(new EventRoom() { Name = "A ROOM", Capacity = 20, OpenDate = DateTime.Now, CloseDate = DateTime.Now.AddHours(1) });


            return View();
        }


        /// <summary>
        /// Şirket içindeki domain kullanıcıları gibi düşündüm.
        /// Bu view ile şirket içi kullanıcıları oluşturuyoruz.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreatePartipicant()
        {
            Participant p1 = new Participant();
            p1.Email = "ahmetoguz.net@gmail.com";
            p1.Name = "ahmet";
            p1.SurName = "oğuz";

            Participant p2 = new Participant();
            p2.Email = "emirhanoguz.net@gmail.com";
            p2.Name = "emirhan";
            p2.SurName = "oğuz";

            Participant p3 = new Participant();
            p3.Email = "testogz21@gmail.com";
            p3.Name = "Toplantı Sahibi";
            p3.SurName = "-";

            _eventService.InsertParticipant(p1);
            _eventService.InsertParticipant(p2);
            _eventService.InsertParticipant(p3);

            return View();

        }
    }
}