namespace CreditPaymentProject.Service
{
    public interface IWalletService
    {
        string CreatePaymentProfile(string jsonRequest);
        string UpdateProfile(string jsonRequest);
    }
}