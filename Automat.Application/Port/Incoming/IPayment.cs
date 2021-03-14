using Automat.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Application.Port.Incoming
{
    public interface IPayment
    {
        Task<TransactionResult> PaymentByCash(PaymentByCashEntity paymentEntity);
        Task<TransactionResult> PaymentByCreditCard(PaymentByCreditCardEntity paymentEntity);
    }
}

