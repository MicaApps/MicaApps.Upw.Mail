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
        private Models.UserData _userData;
        public Models.UserData userData
        {
            get => this._userData;
            set
            {
                Models.UserData userData = value;
                try
                {
                    userData.LoginIn();
                    this._userData = userData;
                }
                catch
                {
                    this._userData = null;
                }
            }
        }


        public bool isLogin { get => this._userData != null; }


    }
}
