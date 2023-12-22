using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace MicaApps.Upw.Mail.Controls
{
    public sealed partial class LoginButton : Button
    {
        public LoginButton()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 主标题
        /// </summary>
        public string title { set=>this.textblock_title.Text = value; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string subTitle { set => this.textblock_subTitle.Text = value; }
        


    }
}
