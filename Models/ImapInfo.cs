using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MailKit;
using MailKit.Net.Imap;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Windows.ApplicationModel.Resources;
using System.IO;
using System.Threading;
using Windows.Media.Protection.PlayReady;

namespace MicaApps.Upw.Mail.Models
{
    internal class ImapInfo : ImapClient
    {
        //private readonly ResourceLoader resourceLoader = ResourceLoader.GetStringForReference();
        public string host { get;private set; }
        public int port { get; private set; }
        public SecureSocketOptions secureSocketOptions { get; set; } = SecureSocketOptions.SslOnConnect;
        public ImapImplementation imapImplementation { get; set; }
        public ImapInfo(string host,int port)
        {
            this.host = host;
            this.port = port;
            this.imapImplementation = new ImapImplementation
            {
                Name = @"MicaApps.Mail.UWP",
                Version = @"1.0",
            };
        }

        public async Task ConnectAsync(string username,string authorizationCode)
        {

            try
            {
                // 连接到 IMAP 服务器
                await this.ConnectAsync(this.host, this.port, this.secureSocketOptions);
                // 添加客户端身份标识
                _ = await this.IdentifyAsync(this.imapImplementation);
                // 身份验证
                await this.AuthenticateAsync(username, authorizationCode);
            }
            catch (AuthenticationException ex)
            {
                throw new Exception(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





    }
}
