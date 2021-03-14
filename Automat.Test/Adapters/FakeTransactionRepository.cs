using Automat.Application.Model;
using Automat.Application.Port.Outgoing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Test.Adapters
{
    public class FakeTransactionRepository : ITransactionRepository
    {
        public async Task<TransactionEntity> AddAsync(TransactionEntity entity)
        {
            TransactionEntity transactionEntity = new TransactionEntity();
            transactionEntity.Id = 1;
            transactionEntity.IsPaid = entity.IsPaid;
            transactionEntity.SelectedPieces = entity.SelectedPieces;
            transactionEntity.Slot = entity.Slot;
            transactionEntity.TransactionAmount = entity.TransactionAmount;

            return transactionEntity;

        }

        public Task DeleteAsync(TransactionEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TransactionEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TransactionEntity>> GetAsync(Expression<Func<TransactionEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TransactionEntity>> GetAsync(Expression<Func<TransactionEntity, bool>> predicate = null, Func<IQueryable<TransactionEntity>, IOrderedQueryable<TransactionEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TransactionEntity>> GetAsync(Expression<Func<TransactionEntity, bool>> predicate = null, Func<IQueryable<TransactionEntity>, IOrderedQueryable<TransactionEntity>> orderBy = null, List<Expression<Func<TransactionEntity, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<TransactionEntity> GetByIdAsync(int id)
        {
            TransactionEntity transactionEntity = new TransactionEntity();
            transactionEntity.Id = id;
            transactionEntity.IsPaid = false;
            transactionEntity.SelectedPieces = 5;
            transactionEntity.Slot = 1;
            transactionEntity.TransactionAmount = 100;

            return transactionEntity;
        }

        public Task UpdateAsync(TransactionEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
