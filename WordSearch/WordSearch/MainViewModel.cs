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
using WordsSeach;

namespace WordSearch
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private List<Word> _unfilterdList;
        private ObservableCollection<Word> _words;
        private ICommand _command;
        private string _searchPattern;
        private string _searchDuration = "Search duration in ms:";
        private readonly IGenerator _generator;
        private readonly ISearch _search;

        public MainViewModel(IGenerator generator, ISearch search)
        {
            _generator = generator;
            _search = search;
        }

        public string SearchDuration
        {
            get { return _searchDuration; }
            set
            {
                _searchDuration = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Word> Words
        {
            get { return _words; }
            set
            {
                _words = value;
                NotifyPropertyChanged();
            }
        }

        public string SearchPattern
        {
            get { return _searchPattern; }
            set
            {
                _searchPattern = value;
                if (Words == null)
                    return;
                TimeSpan duration;
                var result = _search.Excecute(_unfilterdList, _searchPattern, out duration);
                
                Words = new ObservableCollection<Word>(result);
                SearchDuration = string.Format("Search duration in ms: {0}", duration.TotalMilliseconds);

            }
        }

        public ICommand GenerateWordsCommand
        {
            get
            {
                return _command ?? (_command = new CommandHandler(() => 
                {
                    if (_unfilterdList == null)
                    {
                        _unfilterdList = _generator.GetWords();
                        Words = new ObservableCollection<Word>(_unfilterdList);
                    }
                        
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
