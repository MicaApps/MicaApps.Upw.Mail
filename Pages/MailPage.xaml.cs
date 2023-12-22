using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace MicaApps.Upw.Mail.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MailPage : Page
    {
        private readonly Services.LoginStatus loginStatus = App.Services.GetService<Services.LoginStatus>();
        private string tag;
        private DispatcherTimer timer;


        public MailPage()
        {
            this.InitializeComponent();
            


            // 初始化定时器
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1); // 设置定时器间隔为1秒
            this.timer.Tick += (sender, e) =>
            {
                this.textblock_status.Text = this.loginStatus.userData != null ? this.loginStatus.userData.letters.Count().ToString() : @"未连接";
            };
        }



        


        /// <summary>
        /// 处理传递过来参数
        /// </summary>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                // 处理传递过来的参数
                this.tag = (string)e.Parameter;
                // 在这里添加你的逻辑
            }
        }
    }
}
