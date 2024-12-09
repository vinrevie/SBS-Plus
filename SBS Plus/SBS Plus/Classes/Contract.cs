using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SBS_Plus.Classes
{
    public class Contract
    {

        [Key]
        [StringLength(50)]
        public string ContractNumber { get; set; }

        public DateTime Date { get; set; }

        [StringLength(50)]
        public string OrganizationINN { get; set; }
        public Organization Organization { get; set; }

        public string Address { get; set; }

        public DateTime? ClosingDate { get; set; }
        public Contract() {  }
        public void EditContract(DateTime date, string address, string INN, DateTime dateClose)
        {
            Date = date;
            Address = address;
            OrganizationINN = INN;
            ClosingDate = dateClose;
        }
        public Contract(string contractNum, DateTime date, string INN, string address, DateTime dateClose)
        {
            ContractNumber = contractNum;
            Date = date;
            Address = address;
            OrganizationINN = INN;
            ClosingDate = dateClose;
        }

    }
}
