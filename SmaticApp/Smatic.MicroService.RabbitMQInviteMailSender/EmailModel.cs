﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.MicroService.RabbitMQInviteMailSender
{
    class EmailModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }

        public string From { get; set; }

        public string Name { get; set; }

    }
}