using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.RespondentsCredentials.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private List<Credentials> _credentials;
        private List<CatalogWebsborAsgs> _catalog;
        public List<Credentials> Credentials
        {
            get { return _credentials; }
            set
            {
                _credentials = value;
                OnPropertyChanged("Credentials");
            }
        }

        public List<CatalogWebsborAsgs> Catalog
        {
            get { return _catalog; }
            set
            {
                _catalog = value;
                OnPropertyChanged("_catalog");
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
