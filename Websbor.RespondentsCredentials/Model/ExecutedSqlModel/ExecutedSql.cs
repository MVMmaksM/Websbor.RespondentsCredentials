using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.RespondentsCredentials.Model.ExecutedSqlModel
{
    public class ExecutedSql : INotifyPropertyChanged
    {
        private string _sqlExpression = string.Empty;
        private SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            TrustServerCertificate = true,
            IntegratedSecurity = true
        };

        public string Server
        {
            set
            {
                _sqlConnectionStringBuilder.DataSource = value;
                OnPropertyChanged("Server");
            }
        }
        public string Database
        {
            set
            {
                _sqlConnectionStringBuilder.InitialCatalog = value;
                OnPropertyChanged("Database");
            }
        }
        public string ConnectionString
        {
            get => _sqlConnectionStringBuilder.ConnectionString;
        }
        public string SqlExpression
        {
            get { return _sqlExpression; }
            set
            {
                _sqlExpression = value;
                OnPropertyChanged("SqlExpression");
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
