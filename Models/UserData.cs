using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaApps.Upw.Mail.Models
{
    internal abstract class UserData
    {
        public string username { get; set; } = string.Empty;
        

        public ObservableCollection<Letter> letters { get; set; } = new ObservableCollection<Letter>();


        public bool isEmpty { get => string.IsNullOrEmpty(username); }



        public abstract Task CollectLetter(ObservableCollection<Letter> letters,Enums.MailType mailType);
        public abstract Task LoginIn();


        public abstract bool IsLogin { get; }


    }
}
