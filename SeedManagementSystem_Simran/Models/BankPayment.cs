using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeedManagementSystem_Simran.Models
{
    public class BankPayment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionNumber { get; set; }
        public decimal AmountReceived { get; set; }
    }
}