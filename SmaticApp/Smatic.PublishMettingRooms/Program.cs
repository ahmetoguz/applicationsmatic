using RabbitMQ.Client;
using Smatic.Core.RabbitMQService;
using System;

namespace Smatic.PublishMettingRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMQService = new RabbitMQService();

            using(var connection = rabbitMQService.GetRabbitMQConnection())
            {

                using(var channel = connection.CreateModel())
                {

                    channel.ExchangeDeclare("roompublish.exchange", ExchangeType.Fanout, true, false, null);

                    channel.QueueDeclare("roompublish.", true, false, false, null);
                }
            }          
        }
    }

  
}


//var rabbitMQService = new RabbitMQService();

//            //rabbitmq connection'ı oluşturduk
//            using (var connection = rabbitMQService.GetRabbitMqConnection())
//            {
//                //connection üzerinde channel tanımladık.
//                using(var channel = connection.CreateModel())
//                {
//                    //Channel üzerinde yeni bir exchange tanımlıyoruz.
//                    //Tanımlamış olduğumuz bu exchange ile channel'in "foo.exchange" isminde ve Fanout 
//                    //tipinde olacağını belirtiyoruz.
//                    channel.ExchangeDeclare("foo.exchange", ExchangeType.Fanout, true, false, null);
                    
//                    //foo.billing ve foo.shipping isminde iki adet queue tanımlıyor ve bu queue'ları "foo.exchange" üzerine
//                    //bind ediyoruz.
//                    channel.QueueDeclare("foo.billing", true, false, false, null);
//                    channel.QueueDeclare("foo.shipping", true, false, false, null);
//                    channel.QueueBind("foo.billing", "foo.exchange", "");
//                    channel.QueueBind("foo.shipping", "foo.exchange", "");

//                    //publicationAdress class'ı ile de message'ın publish yapılacağı adresi ve exchange type'ını tanımlıyoruz.
//                    var publicationAdress = new PublicationAddress(ExchangeType.Fanout, "foo.exchange", "");

////Yukarıda belirtilen adres ile publish ediyoruz.
//channel.BasicPublish(publicationAdress, null, Encoding.UTF8.GetBytes("12345 numaralı sipariş geldi."));
                    
                   
                    
//                }
//            }