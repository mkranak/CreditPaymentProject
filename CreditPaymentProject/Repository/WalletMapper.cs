using System;
using CreditPaymentProject.Utils;
using CreditPaymentProject.Models;
using CreditPaymentProject.DataContracts;

namespace CreditPaymentProject.Repository
{
    public class WalletMapper : IWalletMapper
    {
        public string MapCreatePaymentProfileRequest(CreditCardInformation creditCardInformation)
        {
            var walletRequest = new WalletRequest
            {
                Account = creditCardInformation.CardNumber,
                Billto = new AddressInformation
                {
                    City = creditCardInformation.City,
                    Email = creditCardInformation.Email,
                    Country = "USA", // The service required this
                    Line1 = creditCardInformation.Address,
                    Line2 = creditCardInformation.Address2,
                    State = creditCardInformation.StateProvince,
                    Zip = creditCardInformation.Zip
                },
                CardHolder = new CustomerInformation
                {
                    FirstName = creditCardInformation.CustomerFirstName,
                    LastName = creditCardInformation.CustomerLastName
                },
                CardName = creditCardInformation.CompanyName,
                Customer = creditCardInformation.CustomerNumber,
                IsDefaultCard = "false", // The service required this
                ExpDate = creditCardInformation.ExpDate,
                Tender = creditCardInformation.CardType 
            };

            var jsonResponse = JsonHelper.JsonSerializer(walletRequest);

            return jsonResponse;
        }

        public TransactionResponse MapCreatePaymentProfileResponse(string jsonRequest)
        {
            var response = JsonHelper.JsonDeserialize<WalletCreateResponse>(jsonRequest);

            var transactionResponse = new TransactionResponse
            {
                CompleteTransactionResponse = jsonRequest,
                Token = response.Result,
                Success = true
            };

            return transactionResponse;
        }

        public string MapUpdateProfileRequest(PaymentProfile paymentProfile)
        {
            var updateRequest = new UpdateRequest
            {
                ID = paymentProfile.CustomerProfileToken,
                ModifiedOn = paymentProfile.ModifiedOn.ToString()
            };

            var jsonResponse = JsonHelper.JsonSerializer(updateRequest);

            return jsonResponse;
        }

        public TransactionResponse MapUpdateProfileResponse(string jsonRequest)
        {
            var updateResult = JsonHelper.JsonDeserialize<UpdateResponse>(jsonRequest);

            var transactionResponse = new TransactionResponse
            {
                CompleteTransactionResponse = jsonRequest,
                Success = string.Equals(updateResult.Result, "True", StringComparison.OrdinalIgnoreCase) ? true : false
            };

            return transactionResponse;
        }
    }
}
