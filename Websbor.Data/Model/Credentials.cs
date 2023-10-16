﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Data.Model
{
    public class Credentials
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Okpo { get; set; }
        public string Password { get; set; }
        public DateTime? DateCreate { get; set; }
        public string? UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string? UserUpdate { get; set; }
        public string? Comment { get; set; }
        public int? CatalogWebsborAsgsId { get; set; }
        public CatalogWebsborAsgs? CatalogWebsborAsgs { get; set; }
    }
}
