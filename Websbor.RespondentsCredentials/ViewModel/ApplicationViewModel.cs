using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;
using Websbor.RespondentsCredentials.Model.ExecutedSqlModel;
using Websbor.RespondentsCredentials.Model.SearchModel;

namespace Websbor.RespondentsCredentials.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private BindingList<Credentials>? _credentials;
        private BindingList<CatalogWebsborAsgs>? _catalog;
        private Credentials? _selectedCredential;
        private CatalogWebsborAsgs? _selectedCatalog;
        private ExecutedSql _executedSql;

        public ExecutedSql ExecutedSql
        {
            get { return _executedSql; }
            set
            {
                _executedSql = value;
                OnPropertyChanged("ExecutedSql");
            }
        }
        public ApplicationViewModel()
        {
            SearchCredential = new SearchModel();
            SearchCatalog = new SearchModel();
            ExecutedSql = new ExecutedSql();
        }
        public SearchModel? SearchCredential { get; set; }
        public SearchModel? SearchCatalog { get; set; }
        public CatalogWebsborAsgs SelectedCatalog
        {
            get { return _selectedCatalog; }
            set
            {
                _selectedCatalog = value;
                OnPropertyChanged("SelectedCatalog");
            }
        }

        public Credentials SelectedCredential
        {
            get { return _selectedCredential; }
            set
            {
                _selectedCredential = value;
                OnPropertyChanged("SelectedCredential");
            }
        }

        public BindingList<Credentials> Credentials
        {
            get { return _credentials; }
            set
            {
                _credentials = value;
                OnPropertyChanged("Credentials");
            }
        }

        public BindingList<CatalogWebsborAsgs> Catalog
        {
            get { return _catalog; }
            set
            {
                _catalog = value;
                OnPropertyChanged("Catalog");
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
