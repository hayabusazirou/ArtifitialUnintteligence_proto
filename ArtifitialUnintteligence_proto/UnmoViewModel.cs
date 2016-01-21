using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Diagnostics;

namespace ArtifitialUnintteligence_proto
{
    public class UnmoViewModel : INotifyPropertyChanged
    {
        public UnmoViewModel()
        {
            noby = new Unmo("noby");

            //debug
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
           
            Resp_opt = false;
            Noby.PropertyChanged += (sender, e) =>
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(e.PropertyName));
                }
            };
        }

        private Unmo noby;
        public Unmo Noby
        {
            //set
            //{
            //    noby = value;
            //    NotifyPropertyChanged("Noby");
            //}
            get { return noby; }
        }

        private string auiTalk = "";
        public string AUiTalk
        {
            set
            {
                auiTalk = value;
                NotifyPropertyChanged("AUiTalk");
            }
            get
            {
                return auiTalk;
            }
        }

        private bool resp_opt;
        public bool Resp_opt
        {
            set
            {
                resp_opt = value;
                NotifyPropertyChanged("Resp_opt");
            }
            get { return resp_opt; }
        }

        private string logue;
        public string Logure
        {
            set
            {
                logue = value;
                NotifyPropertyChanged("Logure");
            }
            get { return logue; }
        }

        private string input = "";
        public string Input
        {
            set
            {
                input = value;
                NotifyPropertyChanged("Input");
            }
            get { return input; }
        } 

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ICommand talk;
        public ICommand Talk
        {
            get { return talk ?? (talk = new TalkCommand(this)); }
        }

        private class TalkCommand : ICommand
        {
            private UnmoViewModel unmoViewModel;

            public TalkCommand(UnmoViewModel viewModel)
            {
                unmoViewModel = viewModel;

                unmoViewModel.PropertyChanged += (sender, e) =>
                {
                    if (CanExecuteChanged != null) CanExecuteChanged(sender, e);
                };
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                if (unmoViewModel.Input != "") return true;
                else return false;
            }

            public void Execute(object parameter)
            {
                string response = unmoViewModel.Noby.Dialogue(unmoViewModel.Input);
                //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                //Debug.WriteLine("Noby.Dialogue::" + response);

                unmoViewModel.Logure += "> " + unmoViewModel.Input + "\n";

                if (unmoViewModel.Resp_opt)
                {
                    unmoViewModel.AUiTalk = unmoViewModel.Noby.Name + ":" + unmoViewModel.Noby.Responder_Name + "> ";
                }
                else
                {
                    unmoViewModel.AUiTalk = unmoViewModel.Noby.Name + "> ";
                }
                unmoViewModel.AUiTalk += response;

                unmoViewModel.Logure += unmoViewModel.AUiTalk + "\n";

                unmoViewModel.Input = "";
            }
        }
    }
}
