using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Windows.UI.Xaml;
using MailKit;
using MailKit.Search;
using System.Collections.ObjectModel;
using Windows.Media.Protection.PlayReady;

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

        public override async Task CollectLetter(ObservableCollection<Letter> letters,Enums.MailType mailType)
        {
            var inbox = this.imapInfo.Inbox;
            



            IList<UniqueId> ids = null;
            switch (mailType)
            {
                case Enums.MailType.Receive:
                    await inbox.OpenAsync(FolderAccess.ReadOnly);
                    ids = await inbox.SearchAsync(SearchQuery.All);
                    break;
                case Enums.MailType.Send:
                    inbox = this.imapInfo.GetFolder(SpecialFolder.Sent);
                    await inbox.OpenAsync(FolderAccess.ReadOnly);
                    ids = await inbox.SearchAsync(SearchQuery.All);
                    break;
                case Enums.MailType.Deleted:
                    await inbox.OpenAsync(FolderAccess.ReadOnly);
                    ids = await inbox.SearchAsync(SearchQuery.Deleted);
                    break;
            }

            

            letters.Clear();

            if(ids != null)
            {
                foreach (var id in ids)
                {
                    var message = await inbox.GetMessageAsync(id);
                    letters.Add(new Letter(message));
                }
            }
            
        }


        public override bool IsLogin { get => this.imapInfo.IsConnected; }

    }
}
