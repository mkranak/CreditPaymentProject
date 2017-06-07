namespace CreditPaymentProject.Models
{
    public class TransactionResponse
    {
        public string AuthCode { get; set; }
        public string CardType { get; set; }
        /// <summary>
        /// JSON value containing the complete response from the Credit Card Processor
        /// </summary>
        public string CompleteTransactionResponse { get; set; }
        public string CustomerToken { get; set; }
        public string ReferenceNo { get; set; }
        public string Response { get; set; }
        public string Status { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionLogID { get; set; }
    }
}
