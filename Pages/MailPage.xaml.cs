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
        private readonly Services.LoginStatus loginStatus = App.services.GetService<Services.LoginStatus>();
        private Models.Enums.MailType tag;
        private DispatcherTimer timer;


        public MailPage()
        {
            this.InitializeComponent();
            


            // 初始化定时器
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1); // 设置定时器间隔为1秒
            this.timer.Tick += (sender, e) =>
            {
                
            };
        }



        private ObservableCollection<Models.Letter> letters = new ObservableCollection<Models.Letter>();


        /// <summary>
        /// 处理传递过来参数
        /// </summary>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                // 处理传递过来的参数
                this.tag = (Models.Enums.MailType)e.Parameter;
                // 在这里添加你的逻辑
                if (this.loginStatus.IsLogin)
                {
                    await this.loginStatus.userData.CollectLetter(this.letters,this.tag);
                }

            }

            timer.Start();
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            // 停止定时器，释放资源
            timer.Stop();
        }






        private void listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 获取点击的项的数据
            Models.Letter clickedItem = e.AddedItems.First() as Models.Letter;

            // 处理点击事件，例如显示一个消息框

            if (clickedItem != null && clickedItem.mimeMessage.HtmlBody !=null)
            {
                this.webview.NavigateToString(clickedItem.mimeMessage.HtmlBody);
            }
            else
            {
                this.webview.NavigateToString(@"Error");
            }
        }
    }
}
