using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Contact_Final.Models
{
    public class PaymentInformation
    {
        [Key]
        public int PaymentInformationId { get; set; }
        public string BankName { get; set; }
        public string CardType { get; set; }
        public int Payer { get; set; }
        public double Money { get; set; }
        public bool Status { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public PaymentInformation() { }
    }
}