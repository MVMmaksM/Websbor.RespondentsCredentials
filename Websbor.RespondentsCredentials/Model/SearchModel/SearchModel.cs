using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Model.SearchModel
{
    public class SearchModel : INotifyPropertyChanged
    {
        private string? _searchByName;
        private string? _searchByOkpo;
        public string? SearchByName
        {
            get => _searchByName;
            set
            {
                _searchByName = value;
                OnPropertyChanged("SearchByName");
            }
        }

        public string? SearchByOkpo
        {
            get => _searchByOkpo;
            set
            {
                _searchByOkpo = value;
                OnPropertyChanged("SearchByOkpo");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
