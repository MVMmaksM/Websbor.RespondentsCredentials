﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Data.Model
{
    public class Credentials : INotifyPropertyChanged
    {
        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(24)]
        public string Okpo { get; set; }
        [MaxLength(24)]
        public string Password { get; set; }
        public DateTime? DateCreate { get; set; }
        [MaxLength(24)]
        public string? UserCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        [MaxLength(24)]
        public string? UserUpdate { get; set; }
        public string? Comment { get; set; }
        public int? CatalogWebsborAsgsId { get; set; }

        private CatalogWebsborAsgs _catalogWebsborAsgs;

        public CatalogWebsborAsgs CatalogWebsborAsgs
        {
            get { return _catalogWebsborAsgs; }
            set 
            { 
                _catalogWebsborAsgs = value;
                OnPropertyChanged("CatalogWebsborAsgs");
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
