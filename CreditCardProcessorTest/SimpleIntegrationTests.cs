using System;
using CreditPaymentProject;
using CreditPaymentProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCardProcessorTest
{
    [TestClass]
    public class CardProcessorTests
    {
        /// <summary>
        /// Account must be deleted before this will be successful
        /// </summary>
        [TestMethod]
        public void CreatePaymentProfileTest_Success()
        {
            CreditCardProcessor creditCardProcessor = new CreditCardProcessor();

            CreditCardInformation creditCardInformation = new CreditCardInformation
            {
                CardNumber = "4111111111111111",
                City = "Pensacola",
                CompanyName = "American Express",
                Address = "123 Golden Brick Way",
                StateProvince = "FL",
                Zip = "32506",
                CustomerFirstName = "Matthew",
                CustomerLastName = "Kranak",
                CustomerNumber = "0001",
                ExpDate = "0120",
                CardType = "CreditCard",
                Email = "matthew.kranak@gmail.com"
            };

            var result = creditCardProcessor.CreatePaymentProfile(creditCardInformation);

            Assert.IsNotNull(result, "Unexpected: result is null.");
            Assert.AreEqual(true, result.Success, "Unexpected: Status is false.");
        }

        /// <summary>
        /// Need to get the result from CreatePaymentProfileTest_Success() which can be used to run this test
        /// </summary>
        [TestMethod]
        public void UpdateProfileTest_Success()
        {
            CreditCardProcessor creditCardProcessor = new CreditCardProcessor();

            PaymentProfile paymentProfile = new PaymentProfile
            {
                CustomerProfileToken = "ec39dca0-478c-4365-b0fa-be673f09874c",
                ModifiedOn = DateTime.Now
            };

            var result = creditCardProcessor.UpdateProfile(paymentProfile);

            Assert.IsNotNull(result, "Unexpected: result is null.");
            Assert.AreEqual(true, result.Success, "Unexpected: Status is false.");
        }

        /// <summary>
        /// Combines both tests above to so I don;t have to run one and then the other (Just make sure there is no account in the system first)
        /// </summary>
        [TestMethod]
        public void CreateAndUpdateTest_Success()
        {
            CreditCardProcessor creditCardProcessor = new CreditCardProcessor();

            // Create Part
            CreditCardInformation creditCardInformation = new CreditCardInformation
            {
                CardNumber = "4111111111111111",
                City = "Pensacola",
                CompanyName = "American Express",
                Address = "123 Golden Brick Way",
                StateProvince = "FL",
                Zip = "32506",
                CustomerFirstName = "Matthew",
                CustomerLastName = "Kranak",
                CustomerNumber = "0001",
                ExpDate = "0120",
                CardType = "CreditCard",
                Email = "matthew.kranak@gmail.com"
            };

            var createResult = creditCardProcessor.CreatePaymentProfile(creditCardInformation);

            Assert.IsNotNull(createResult, "Unexpected: createResult is null.");
            Assert.AreEqual(true, createResult.Success, "Unexpected: Status is false.");

            // UpdatePart
            PaymentProfile paymentProfile = new PaymentProfile
            {
                CustomerProfileToken = createResult.Token,
                ModifiedOn = DateTime.Now
            };

            var updateResult = creditCardProcessor.UpdateProfile(paymentProfile);

            Assert.IsNotNull(updateResult, "Unexpected: updateResult is null.");
            Assert.AreEqual(true, updateResult.Success, "Unexpected: Status is false.");


        }
    }
}
