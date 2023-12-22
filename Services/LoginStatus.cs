using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;

namespace MicaApps.Upw.Mail.Services
{
    internal class LoginStatus
    {
        public Models.UserData userData { get; set; }

        public bool IsLogin { get=>this.userData != null && this.userData.IsLogin;}






    }
}
