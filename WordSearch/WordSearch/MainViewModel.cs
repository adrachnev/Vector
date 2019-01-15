using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WordsGenerator;

namespace WordSearch
{
    public class MainViewModel:INotifyPropertyChanged
    {
        ObservableCollection<Word> _words;
        private ICommand _command;

        public ObservableCollection<Word> Words
        {
            get { return _words; }
            set
            {
                _words = value;
                NotifyPropertyChanged();
            }
        }
        

        public ICommand GenerateWordsCommand
        {
            get
            {
                return _command ?? (_command = new CommandHandler(() => 
                {
                    if (Words == null)
                        Words = new ObservableCollection<Word>(Generator.GetWords());
                }, 
                true));
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
    }
    

}
