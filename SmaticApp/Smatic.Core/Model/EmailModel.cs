﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Smatic.Core.Model
{
    public class EmailModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }

        //Toplantı sahibi
        public string From { get; set; }
        public string Name { get; set; }

    }
}
