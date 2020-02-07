using Smatic.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.Core.Services.RabbitQueue
{
    public interface IRabbitMQService
    {
        bool SendEmailToRabbitMQ(EmailModel emailModel);
    }
}
