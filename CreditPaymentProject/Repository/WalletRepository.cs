using System;
using System.Net;
using CreditPaymentProject.Models;
using CreditPaymentProject.Service;
using CreditPaymentProject.Repository;

namespace CreditPaymentProject.DAL.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private IWalletService _walletService;
        private IWalletMapper _walletMapper;
        
        public WalletRepository()
        {
            _walletService = new WalletService();
            _walletMapper = new WalletMapper();
        }

        public TransactionResponse CreatePaymentProfile(CreditCardInformation creditCardInformation)
        {
            TransactionResponse transactionResponse = null;

            try
            {
                string jsonRequest = _walletMapper.MapCreatePaymentProfileRequest(creditCardInformation);
                var jsonResponse = _walletService.CreatePaymentProfile(jsonRequest);
                transactionResponse = _walletMapper.MapCreatePaymentProfileResponse(jsonResponse);
            }
            catch (WebException e)
            {
                throw new WebException(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return transactionResponse;
        }

        public TransactionResponse UpdateProfile(PaymentProfile paymentProfile)
        {
            TransactionResponse transactionResponse = null;

            try
            {
                string jsonRequest = _walletMapper.MapUpdateProfileRequest(paymentProfile);
                var jsonResponse = _walletService.UpdateProfile(jsonRequest);
                transactionResponse = _walletMapper.MapUpdateProfileResponse(jsonResponse);
            }
            catch (WebException e)
            {
                throw new WebException(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return transactionResponse;
        }
    }
}
