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
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkId { get; set; }

        [StringLength(2000)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        [StringLength(50)]
        public string UnitOfMeasurement { get; set; }

        [StringLength(50)]
        public string ContractNumber { get; set; }
        public int WorkNum { get; set; }
        public Work() { }

        public void EditWork(string name, decimal price, decimal quantity, string unitOfMeasure)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.UnitOfMeasurement = unitOfMeasure;
        }
        public Work(string contractNum, string name, decimal price, decimal quantity, string unitOfMeasure, int workNum)
        {
            ContractNumber = contractNum;
            Name = name;
            Price = price;
            Quantity = quantity;
            UnitOfMeasurement = unitOfMeasure;
            WorkNum = workNum;
        }
    }
}
