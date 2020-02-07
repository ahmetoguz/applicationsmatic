using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Smatic.MicroService.RabbitMQInviteMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Started Invite Microservice");

                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                   
                };

                using (IConnection connection = factory.CreateConnection())
                using (IModel channel = connection.CreateModel())
                {
                    
                    channel.QueueDeclare(queue: "SmaticInviteChannel",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var emailModel = JsonConvert.DeserializeObject<EmailModel>(message);


                        Console.WriteLine("messs");
                        //Console.WriteLine();

                        if (emailModel != null)
                        {
                            IniviteMailSend(emailModel);
                            Console.WriteLine("email dolu.");
                        }
                        else
                        {
                            Console.WriteLine("email boş");
                        }
                    };

                    channel.BasicConsume(queue: "SmaticInviteChannel", autoAck: true, consumer: consumer);

                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static bool IniviteMailSend(EmailModel model)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;


            sc.Credentials = new NetworkCredential("testogz21@gmail.com", "cnmo0*8Anb");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(model.From, model.Name);

            mail.To.Add("ahmetoguz.net@mail.com");
            mail.To.Add("testogz21@gmail.com");



            mail.Subject = model.Subject;
            mail.IsBodyHtml = true;
            mail.Body = model.Body;
             


            sc.Send(mail);

            //default true olarak gönderdim.
            return true;
        }
    }
}
