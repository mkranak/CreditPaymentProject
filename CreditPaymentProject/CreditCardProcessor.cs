using CreditPaymentProject.Models;
using CreditPaymentProject.DAL.Repository;

namespace CreditPaymentProject
{
    public class CreditCardProcessor : ICreditCardProcessor
    {
        public TransactionResponse CreatePaymentProfile(CreditCardInformation creditCardInformation)
        {
            var repo = new WalletRepository();
            return repo.CreatePaymentProfile(creditCardInformation);
        }

        public TransactionResponse UpdateProfile(PaymentProfile profileToUpdate)
        {
            var repo = new WalletRepository();
            return repo.UpdateProfile(profileToUpdate);
        }
    }
}
