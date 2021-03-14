using Automat.Application.Model;
using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Port.Outgoing
{
    public interface ITransactionRepository : IRepository<TransactionEntity>
    {
    }
}
