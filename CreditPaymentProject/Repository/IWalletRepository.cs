using CreditPaymentProject.Models;

namespace CreditPaymentProject.DAL.Repository
{
    public interface IWalletRepository
    {
        TransactionResponse CreatePaymentProfile(CreditCardInformation creditCardInformation);
        TransactionResponse UpdateProfile(PaymentProfile paymentProfile);
    }
}
