using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicaApps.Upw.Mail.Models
{
    internal abstract class UserData
    {
        public string username { get; set; } = string.Empty;
        

        public List<Letter> letters { get; set; } = new List<Letter>();


        public bool isEmpty { get => string.IsNullOrEmpty(username); }



        public abstract Task LoginIn();


    }
}
