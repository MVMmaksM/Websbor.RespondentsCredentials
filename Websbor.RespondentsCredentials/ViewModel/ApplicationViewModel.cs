using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.RespondentsCredentials.ViewModel
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
            Credentials = new List<Credentials>
            {
                new Credentials {Okpo="123123"}
            };
        }
        public List<Credentials> Credentials { get; set; }
        public List<CatalogWebsborAsgs> Catalog { get; set; }
    }
}
