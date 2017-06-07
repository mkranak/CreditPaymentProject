using CreditPaymentProject.Models;


namespace CreditPaymentProject.Repository
{
    public interface IWalletMapper
    {
        string MapCreatePaymentProfileRequest(CreditCardInformation creditCardInformation);
        TransactionResponse MapCreatePaymentProfileResponse(string jsonRequest);
        string MapUpdateProfileRequest(PaymentProfile paymentProfile);
        TransactionResponse MapUpdateProfileResponse(string jsonRequest);

    }
}
