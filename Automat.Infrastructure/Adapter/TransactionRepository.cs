using Automat.Application.Model;
using Automat.Application.Port.Outgoing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Infrastructure.Adapter
{
    public class TransactionRepository : Repository<TransactionEntity>, ITransactionRepository
    {
        public TransactionRepository(AutomatDbContext dbContext) : base(dbContext)
        {
        }
    }
}
