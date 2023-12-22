using MicaApps.Upw.Mail.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
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
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// 页面加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            if (sender is LoginButton button)
            {
                object tagValue = button.Tag;

                if (tagValue != null)
                {
                    // 在这里使用按钮的 Tag 属性值
                    string tagString = tagValue.ToString();
                    // 其他处理逻辑...
                    switch (tagString)
                    {
                        case @"other":
                            this.Frame.Navigate(typeof(Login.LoginByImapPage));
                            break;
                    }
                }
            }
        }


        private void Button_Test_Click(object sender, RoutedEventArgs e)
        {
#if DEBUG
            this.Frame.Navigate(typeof(HomePagel));
#endif
        }




        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            
        }
    }
}
