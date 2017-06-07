namespace CreditPaymentProject.DataContracts
{
    public class WalletRequest
    {
        public string Account { get; set; }
        public AddressInformation Billto { get; set; }
        public CustomerInformation CardHolder { get; set; }
        public string CardName { get; set; }
        public string Customer { get; set; }
        public string ExpDate { get; set; }
        public string GPAddressCode { get; set; }
        public string GatewayToken { get; set; }
        public string Identifier { get; set; }
        public string IsDefaultCard { get; set; }
        public string IssueNumber { get; set; }
        public string Tender { get; set; }
        public string UserDefine1 { get; set; }
        public string UserDefine2 { get; set; }
        public string UserDefine3 { get; set; }
        public string UserDefine4 { get; set; }
    }

    public class AddressInformation
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    public class CustomerInformation
    {
        public string DriverLicense { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string SSN { get; set; }
    }


}
