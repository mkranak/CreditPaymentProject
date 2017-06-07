using CreditPaymentProject.Utils;

namespace CreditPaymentProject.Service
{
    public class WalletService : IWalletService
    {
        public string CreatePaymentProfile(string jsonRequest)
        {
            return new WebRequestHelper("create").Post(jsonRequest);
        }

        public string UpdateProfile(string jsonRequest)
        {
            return new WebRequestHelper("update").Post(jsonRequest);
        }
    }
}
