using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedManagementSystem_Simran.Models
{
    public class CropVariety
    {
        public int ID { get; set; }
        public int CropID { get; set; }
        public string VarietyName { get; set; }


        public Crop Crop { get; set; }
        public List<CropRate> CropRates { get; set; }
        public List<Store> Stores { get; set; }
        public List<SeedSelling> SeedSellings { get; set; }
    }
}