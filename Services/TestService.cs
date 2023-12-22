using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MailKit.Security;
using MailKit;
using MailKit.Net.Imap;
using Windows.UI.Xaml.Controls;



namespace KalevaAalto.Upw.Base.Services
{
    public class TestService
    {



        public void test(Action<string> AddString)
        {
            string username = @"kalevaaalto@163.com";
            string password = @"RDYOIOUMYSWGAPLK";

            using (var client = new ImapClient())
            {
                client.Connect(@"imap.163.com", 993, SecureSocketOptions.SslOnConnect);
                client.Authenticate(username, password);

                var clientImplementation = new ImapImplementation
                {
                    Name = "KalevaAalto.Upw",
                    Version = "2.0"
                };
                _ = client.Identify(clientImplementation);


                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                AddString(@"Total messages: " + inbox.Count);

                for (int i = 0; i < inbox.Count; i++)
                {
                    

                    var message = inbox.GetMessage(i);
                    var id = message.MessageId;
                    AddString(@"Subject: " + message.Subject);
                }

                client.Disconnect(true);
            }


        }



    }
}
