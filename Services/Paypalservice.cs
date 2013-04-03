using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using PayPal;
using PayPal.Api.Payments;

namespace WebApis.Services
{
    public class Paypalservice
    {
        readonly string SandBoxEndPoint = "https://api.sandbox.paypal.com";
        static readonly string APIKey = ConfigurationManager.AppSettings["PaypalClientId"];
        static readonly string APISecret = ConfigurationManager.AppSettings["PaypalSecret"];

        public static string AccessToken()
        {
            OAuthTokenCredential token = new OAuthTokenCredential(APIKey, APISecret);
            return token.GetAccessToken();
        }

        public void CreditCardPay(Address billingaddr, CreditCard cc, Amount amount)
        {
            Transaction transaction = new Transaction();
            transaction.amount = amount;
            transaction.description = "This is the payment transaction description.";

            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(transaction);

            FundingInstrument fundingInstrument = new FundingInstrument();
            fundingInstrument.credit_card = cc;

            List<FundingInstrument> fundingInstruments = new List<FundingInstrument>();
            fundingInstruments.Add(fundingInstrument);

            Payer payer = new Payer();
            payer.funding_instruments = fundingInstruments;
            payer.payment_method = "credit_card";

            Payment payment = new Payment();
            payment.intent = "sale";
            payment.payer  = payer;
            payment.transactions = transactions;

            Payment createdPayment = payment.Create(AccessToken());

        }



    }

}