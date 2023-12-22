using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Windows.UI.Xaml;

namespace MicaApps.Upw.Mail.Models
{
    /// <summary>
    /// 通过Imap来获取信息
    /// </summary>
    internal class UserDataByImap : UserData
    {
        public ImapInfo imapInfo { get; set; }

        /// <summary>
        /// 授权码
        /// </summary>
        public string authorizationCode { get; set; }

        public UserDataByImap(string username,string authorizationCode,ImapInfo imapInfo)
        {
            this.username = username;
            this.authorizationCode = authorizationCode;
            this.imapInfo = imapInfo;
        }


        public override async Task LoginIn()
        {
            await this.imapInfo.ConnectAsync(this.username,this.authorizationCode);
        }

    }
}
