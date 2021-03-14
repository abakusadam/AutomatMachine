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
    public class FakeProductRepository : IProductRepository
    {

        public Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            throw new NotImplementedException();

        }

        public Task DeleteAsync(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductEntity>> GetAllAsync()
        {
            ProductEntity productEntity = new ProductEntity();
            productEntity.Id = 1;
            productEntity.IsAvailable = true;
            productEntity.IsRequiredSugarSelection = false;
            productEntity.ProductName = "gofret";
            productEntity.Slot = 1;
            productEntity.NumberOfProducts = 5;
            productEntity.PriceOfProduct = 5;
            productEntity.ProductTypeId = 1;

            List<ProductEntity> productEntityList = new List<ProductEntity>();
            productEntityList.Add(productEntity);

            return productEntityList.AsReadOnly();
        }

        public Task<IReadOnlyList<ProductEntity>> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductEntity>> GetAsync(Expression<Func<ProductEntity, bool>> predicate = null, Func<IQueryable<ProductEntity>, IOrderedQueryable<ProductEntity>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            ProductEntity productEntity = new ProductEntity();
            productEntity.Id = 1;
            productEntity.IsAvailable = true;
            productEntity.IsRequiredSugarSelection = false;
            productEntity.ProductName = "gofret";
            productEntity.Slot = 1;
            productEntity.NumberOfProducts = 5;
            productEntity.PriceOfProduct = 5;
            productEntity.ProductTypeId = 1;

            List<ProductEntity> productEntityList = new List<ProductEntity>();
            productEntityList.Add(productEntity);

            return productEntityList.AsReadOnly();
        }

        public async Task<ProductEntity> GetByIdAsync()
        {
            ProductEntity productEntity = new ProductEntity();
            productEntity.Id = 1;
            productEntity.IsAvailable = true;
            productEntity.IsRequiredSugarSelection = false;
            productEntity.ProductName = "gofret";
            productEntity.Slot = 1;
            productEntity.NumberOfProducts = 5;
            productEntity.PriceOfProduct = 5;
            productEntity.ProductTypeId = 1;

            return productEntity;
        }

        public Task<IReadOnlyList<ProductEntity>> GetAsync(Expression<Func<ProductEntity, bool>> predicate = null, Func<IQueryable<ProductEntity>, IOrderedQueryable<ProductEntity>> orderBy = null, List<Expression<Func<ProductEntity, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            ProductEntity productEntity = new ProductEntity();
            productEntity.Id = 1;
            productEntity.IsAvailable = true;
            productEntity.IsRequiredSugarSelection = false;
            productEntity.ProductName = "gofret";
            productEntity.Slot = 1;
            productEntity.NumberOfProducts = 5;
            productEntity.PriceOfProduct = 5;
            productEntity.ProductTypeId = 1;

            return productEntity;
        }

        public async Task UpdateAsync(ProductEntity entity)
        {
            ProductEntity productEntity = new ProductEntity();
            productEntity.Id = entity.Id;
            productEntity.IsAvailable = entity.IsAvailable;
            productEntity.IsRequiredSugarSelection = entity.IsRequiredSugarSelection;
            productEntity.ProductName = entity.ProductName;
            productEntity.Slot = entity.Slot;
            productEntity.NumberOfProducts = entity.NumberOfProducts;
            productEntity.PriceOfProduct = entity.PriceOfProduct;
            productEntity.ProductTypeId = entity.ProductTypeId;

        }

        public async Task<ProductEntity> UpdateProduct(ProductEntity product)
        {
            ProductEntity productEntity = new ProductEntity();
            productEntity.Id = product.Id;
            productEntity.IsAvailable = product.IsAvailable;
            productEntity.IsRequiredSugarSelection = product.IsRequiredSugarSelection;
            productEntity.ProductName = product.ProductName;
            productEntity.Slot = product.Slot;
            productEntity.NumberOfProducts = product.NumberOfProducts;
            productEntity.PriceOfProduct = product.PriceOfProduct;
            productEntity.ProductTypeId = product.ProductTypeId;

            return productEntity;
        }
    }
}
