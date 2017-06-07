using System;

namespace CreditPaymentProject.Models
{
    public class PaymentProfile
    {
        private string objectNumber;
        private const string MODIFIED_BY = "Payments-Service";

        public string CardMasked { get; set; }
        public string CardName { get; set; }
        public string CustomerProfileToken { get; set; }
        public int ManufacturerId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ObjectNumber
        {
            get
            {
                return objectNumber;
            }
            set
            {
                ModifiedOn = DateTime.Now;
                ModifiedBy = MODIFIED_BY;
                objectNumber = value;
            }
        }
        public string ObjectType { get; set; }
        public string PaymentProfileToken { get; set; }
        public int PaymentTokenId { get; set; }      
    }
}
