using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SBS_Plus.Classes
{
    public class Organization
    {
        [Key]
        [StringLength(50)]
        public string INN { get; set; }
   
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Director { get; set; }

        [StringLength(200)]
        public string Directors { get; set; }

        [StringLength(1000)]
        public string LegalAddress { get; set; }

        [StringLength(50)]
        public string KPP { get; set; }

        [StringLength(50)]
        public string RS { get; set; }

        [StringLength(50)]
        public string KS { get; set; }

        [StringLength(1000)]
        public string Bank { get; set; }

        [StringLength(50)]
        public string BIC { get; set; }

        [StringLength(50)]
        public string OKPO { get; set; }

        [StringLength(50)]
        public string OGRN { get; set; }

        [StringLength(30)]
        public string Type { get; set; }
        public Organization() { }
        public void EditOrg(string Name, string Director,  string Directors,  string LegalAddress, string KPP, string RS, string KS, string Bank, string BIC, string OKPO , string OGRN, string Type)
        {
            this.Name = Name;
            this.Director = Director; 
            this.Directors = Directors;
            this.LegalAddress = LegalAddress;
            this.KPP = KPP;
            this.RS = RS;
            this.KS = KS;
            this.Bank = Bank;
            this.OKPO = OKPO;
            this.Type = Type;
            this.BIC = BIC;
            this.OGRN = OGRN;
          
                       
        }
        public Organization(string INN, string Name, string Director, string Directors, string LegalAddress, string KPP, string RS, string KS, string Bank, string BIC, string OKPO, string OGRN, string Type)
        {
            this.Name = Name;
            this.Director = Director;
            this.Directors = Directors;
            this.LegalAddress = LegalAddress;
            this.KPP = KPP;
            this.RS = RS;
            this.KS = KS;
            this.Bank = Bank;
            this.OKPO = OKPO;
            this.Type = Type;
            this.BIC = BIC;
            this.OGRN = OGRN;
            this.INN = INN;
        }

    }
}
