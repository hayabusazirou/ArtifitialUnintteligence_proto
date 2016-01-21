using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace ArtifitialUnintteligence_proto
{
    public class Unmo : INotifyPropertyChanged
    {
        private WhatResponder resp_what = new WhatResponder("What");
        private RandomResponder resp_random = new RandomResponder("Random");
        //private Responder responder;

        public Unmo(string name)
        {
            Name = name;
            NowResponder = resp_random;
            Responder_Name = NowResponder.Name;
        }

        public string Dialogue(string input)
        {
  
            Random rand = new Random();
            if(rand.Next(2) == 0)
            {
                NowResponder = resp_what;
            }
            else
            {
                NowResponder = resp_random;
            }
            Responder_Name = NowResponder.Name;
            return NowResponder.Response(input);
        }

        private Responder nowResponder;
        public Responder NowResponder
        {
            set
            {
                nowResponder = value;
            }
            get { return nowResponder; }
        }

        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string responder_name;
        public string Responder_Name
        {
            set
            {
                responder_name = NowResponder.Name;
            }
            get { return responder_name; }
        }

        //プロパティ変更後に発生するイベントハンドラ
        public event PropertyChangedEventHandler PropertyChanged;
        //プロパティ変更を通知する
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
