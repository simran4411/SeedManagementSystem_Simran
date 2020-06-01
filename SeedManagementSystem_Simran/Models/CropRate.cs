using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedManagementSystem_Simran.Models
{
    public class CropRate
    {
        public int ID { get; set; }
        public int CropVarietyID { get; set; }
        public string Rate { get; set; }
        public decimal Quantity { get; set; }

        public CropVariety CropVariety { get; set; }
    }
}