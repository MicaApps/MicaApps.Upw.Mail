using MicaApps.Upw.Mail.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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

namespace MicaApps.Upw.Mail.Pages.Login
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class LoginByImapPage : Page
    {
        private readonly Services.StaticValues staticValues = App.Services.GetService<Services.StaticValues>();
        private readonly Services.LoginStatus loginStatus = App.Services.GetService<Services.LoginStatus>();

        public LoginByImapPage()
        {
            this.InitializeComponent();
        }

        private void combox_mailhost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grid grid = new Grid();
            var m = grid.Margin;
        }


        private string username { get => this.textbox_username.Text + '@' + this.combox_mailhost.Text; }
        private string password { get => this.textbox_password.Text; }
        private string host { get=>this.textbox_host.Text; }
        private int port { get => Convert.ToInt32(this.textbox_port.Text); }


        private async void Button_Login_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                this.loginStatus.userData = new UserDataByImap(
                    this.username,
                    this.password,
                    new ImapInfo(this.host, this.port)
                    );

                await this.loginStatus.userData.LoginIn();

                this.Frame.Navigate(typeof(HomePagel));


            }
            catch (Exception ex)
            {
                // 创建 ContentDialog
                ContentDialog dialog = new ContentDialog
                {
                    Title = "登录失败",
                    Content = ex.Message,
                    CloseButtonText = "关闭"
                };

                // 显示提示框并等待用户响应
                ContentDialogResult result = await dialog.ShowAsync();
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
}
