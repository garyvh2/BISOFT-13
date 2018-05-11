using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using CoreAPI.Integrations.Models;
using Exceptions;
using Entities.Entities;
using DataAccess.CRUD.TransactionComponents;

namespace CoreAPI.Integrations
{
    public class PaymentManager
    {
        // PaymentManager Instance
        private static PaymentManager Instance;
        // Token instance
        private static IBraintreeGateway GetAway;
        // Estados de transaccion
        private readonly List<TransactionStatus> SuccessStatuses = new List<TransactionStatus>()
        {
            TransactionStatus.AUTHORIZED,
            TransactionStatus.AUTHORIZING,
            TransactionStatus.SETTLED,
            TransactionStatus.SETTLING,
            TransactionStatus.SETTLEMENT_CONFIRMED,
            TransactionStatus.SETTLEMENT_PENDING,
            TransactionStatus.SUBMITTED_FOR_SETTLEMENT
        };

        // >> Singleton Return Instance
        public static PaymentManager GetInstance()
        {
            // If the instance is undefined then create it
            if (Instance == null)
            {
                // >> Email Manager Instantiation
                Instance = new PaymentManager();
            }
            // Otherwise return the instance
            return Instance;
        }

        public IBraintreeGateway GetToken()
        {
            // If the instance is undefined then create it
            if (GetAway == null)
            {
                var Environment = Braintree.Environment.SANDBOX;
                var MerchantId = System.Environment.GetEnvironmentVariable("BraintreeMerchantId") ?? ConfigurationManager.AppSettings["BraintreeMerchantId"];
                var PublicKey = System.Environment.GetEnvironmentVariable("BraintreePublicKey") ?? ConfigurationManager.AppSettings["BraintreePublicKey"];
                var PrivateKey = System.Environment.GetEnvironmentVariable("BraintreePrivateKey") ?? ConfigurationManager.AppSettings["BraintreePrivateKey"];


                // >> Email Manager Instantiation
                GetAway = new BraintreeGateway
                {
                    Environment = Environment,
                    MerchantId = MerchantId,
                    PublicKey = PublicKey,
                    PrivateKey = PrivateKey
                };
            }
            // Otherwise return the instance
            return GetAway;
        }

        public bool Pay(Payment payment)
        {
            try
            {
                // >> Payment Request
                var PaymentRequest = new TransactionRequest
                {
                    Amount = Convert.ToDecimal(payment.Monto),
                    PaymentMethodNonce = payment.Nonce,
                    Options = new TransactionOptionsRequest
                    {
                        SubmitForSettlement = true
                    }
                };

                // >> Se ejecuta la transaccion
                Result<Transaction> PaymentResult = GetToken().Transaction.Sale(PaymentRequest);

                // >> La transaccion es exitosa
                if (PaymentResult.IsSuccess())
                {
                    // >> Se busca la transaccion en el servidor
                    Transaction ServerTransaction = GetToken().Transaction.Find(PaymentResult.Target.Id);
                    // >> La transaccion fue completada de manera exitosa
                    if (SuccessStatuses.Contains(ServerTransaction.Status))
                    {
                        return true;
                    }
                    else
                    {
                        // >> La transaccion fallo
                        ExceptionManager.GetInstance().Process(new Exception(PaymentResult.Message), storeOnly: true);
                        throw new BussinessException(20);
                    }
                }
                else
                {
                    // >> La transaccion fallo
                    ExceptionManager.GetInstance().Process(new Exception(PaymentResult.Message), storeOnly: true);
                    throw new BussinessException(20);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
                return false;
            }
        }
        
    }
}
