using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedManagementSystem_Simran.Models
{
    public class Crop
    {
        public int ID { get; set; }
        public string CropName { get; set; }
        public List<CropVariety> CropVarieties { get; set; }
    }
}