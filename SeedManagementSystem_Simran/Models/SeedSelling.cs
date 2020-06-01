using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedManagementSystem_Simran.Models
{
    public class SeedSelling
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int CropVarietyID { get; set; }
        public string NoofBags { get; set; }
        public decimal Amount { get; set; }


        public Customer Customer { get; set; }
        public CropVariety CropVariety { get; set; }
    }
}