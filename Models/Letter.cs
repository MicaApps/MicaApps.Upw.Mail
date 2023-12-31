﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace MicaApps.Upw.Mail.Models
{
    /// <summary>
    /// 专门用于储存每封信件
    /// </summary>
    internal class Letter
    {
        public MimeMessage mimeMessage { get;private set; }
        public string title { get => this.mimeMessage.Subject; }


        public Letter(MimeMessage mimeMessage)
        {
            this.mimeMessage = mimeMessage;
        }

    }
}
