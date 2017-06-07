using CreditPaymentProject.Models;

namespace CreditPaymentProject
{
    public interface ICreditCardProcessor
    {
        TransactionResponse CreatePaymentProfile(CreditCardInformation creditCardInformation);
        TransactionResponse UpdateProfile(PaymentProfile profileToUpdate);
    }
}
