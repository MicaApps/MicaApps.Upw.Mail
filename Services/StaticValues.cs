using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MicaApps.Upw.Mail.Services
{
    internal class StaticValues
    {

        

        public Dictionary<string, Models.ImapInfo> imapInfos { get; } = new Dictionary<string, Models.ImapInfo>
        {
            { @"qq.com",new Models.ImapInfo(@"imap.qq.com",993) },
            { @"163.com",new Models.ImapInfo(@"imap.163.com",993) },
        };



    }
}
