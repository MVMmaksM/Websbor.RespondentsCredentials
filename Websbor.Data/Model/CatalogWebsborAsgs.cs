using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Data.Model
{
    public class CatalogWebsborAsgs
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string ShortName { get; set; }
        public string FullName { get; set; }

        [Required]
        [MaxLength(24)]
        public string Okpo { get; set; }
        [MaxLength(24)]
        public string OkpoUl { get; set; }
        public int? Inn { get; set; }
        public string Address { get; set; }
        [MaxLength(24)]
        public string Okved2Fact { get; set; }
        public string? Telephone { get; set; }
        public string? DopTelephone { get; set; }
        public string? Email { get; set; }
        public long? OkatoFact { get; set; }
        public long? OktmoFact { get; set; }
        public int? Okogu { get; set; }
        public short? Okfs { get; set; }
        public int? Okopf { get; set; }
        public List<Credentials>? Credentials { get; set; }
    }
}
