using Automat.Application.Model;
using Automat.Application.Port.Outgoing;
using Automat.Application.Port.Outgoing.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Automat.Application.Port
{
    public class AutomatFacade : IAutomatFacade
    {
        private readonly IProductRepository _productRepository;
        private readonly ICampaingRepository _campaingRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AutomatFacade(IProductRepository productRepository, ICampaingRepository campaingRepository, ITransactionRepository transactionRepository)
        {
            _productRepository = productRepository;
            _campaingRepository = campaingRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<IReadOnlyList<CampaingEntity>> CampaingGetAll()
        {
            try
            {
                var campaings = await _campaingRepository.GetAllAsync();

                return campaings;
            }
            catch (Exception)
            {
                //logging
                return null;
            }
        }

        public async Task<TransactionResult> PaymentByCash(PaymentByCashEntity paymentEntity)
        {
            TransactionResult transactionResult = new TransactionResult();

            try
            {
                if (paymentEntity == null)
                {
                    transactionResult.Code = 1;
                    transactionResult.Message = "null parameter";
                    return transactionResult;
                }

                if (paymentEntity.CashAmount == 0 )
                {
                    transactionResult.Code = 1;
                    transactionResult.Message = "Lütfen para giriniz!";
                    return transactionResult;
                }

                var transaction = await _transactionRepository.GetByIdAsync(paymentEntity.TransactionId);

                if (transaction == null)
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Code = 1;
                    transactionResult.Message = $"TransactionId: {paymentEntity.TransactionId} Message: TransactionId değeri bulunamadı!";

                    return transactionResult;
                }


                var product = await _productRepository.GetByIdAsync(transaction.Slot);

                if (product == null)
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Slot = transaction.Slot;
                    transactionResult.Code = 1;
                    transactionResult.Message = $"Slot: {transaction.Slot} Message: Slot bulunamadı!";

                    return transactionResult;
                }

                if (transaction.IsPaid)
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Code = 1;
                    transactionResult.Message = $"Bu işlem Gerçekleşmiştir! Transaction id {paymentEntity.TransactionId}";
                    return transactionResult;
                }

                if (paymentEntity.CashAmount < transaction.TransactionAmount)
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Code = 1;
                    transactionResult.Message = "Lütfen yeterli para giriniz!";
                    return transactionResult;
                }

                var reversedAmount = paymentEntity.CashAmount - transaction.TransactionAmount;

                transactionResult.TransactionId = paymentEntity.TransactionId;
                transactionResult.Code = 0;
                transactionResult.Message = "Başarılı işlem";
                transactionResult.PaymentMethod = "NAKIT";
                transactionResult.ReversedAmount = reversedAmount;
                transactionResult.Slot = transaction.Slot;


                product.NumberOfProducts -= transaction.SelectedPieces;
                product.IsAvailable = product.NumberOfProducts <= 0 ? false : true;
                await  _productRepository.UpdateAsync(product);

                transaction.IsPaid = true;
                await _transactionRepository.UpdateAsync(transaction);

                return transactionResult;

            }
            catch (Exception)
            {
                //logging 
                transactionResult.TransactionId = paymentEntity.TransactionId;
                transactionResult.Code = 1;
                transactionResult.Message = "Hata oluştu!";
            }

            return transactionResult;
        }

        public async Task<TransactionResult> PaymentByCreditCard(PaymentByCreditCardEntity paymentEntity)
        {
            TransactionResult transactionResult = new TransactionResult();

            try
            {
                if (paymentEntity == null)
                {
                    transactionResult.Code = 1;
                    transactionResult.Message = "null parameter";
                    return transactionResult;
                }

                //In this line can be used luhn check algorithm for the credit card info!!!!
                if (string.IsNullOrEmpty(paymentEntity.Pan) || paymentEntity.Year == 0 || 
                    paymentEntity.Month == 0 || string.IsNullOrEmpty(paymentEntity.Cvc))
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Code = 1;
                    transactionResult.Message = $"CardInfo: {paymentEntity.TransactionId} Message: Kredi kartı bilgileri bulunamadı!";
                    return transactionResult;
                }

                var transaction = await _transactionRepository.GetByIdAsync(paymentEntity.TransactionId);

                if (transaction == null)
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Code = 1;
                    transactionResult.Message = $"TransactionId: {paymentEntity.TransactionId} Message: TransactionId değeri bulunamadı!";

                    return transactionResult;
                }

                var product = await _productRepository.GetByIdAsync(transaction.Slot);

                if (product == null)
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Slot = transaction.Slot;
                    transactionResult.Code = 1;
                    transactionResult.Message = $"Slot: {transaction.Slot} Message: Slot bulunamadı!";

                    return transactionResult;
                }

                if (transaction.IsPaid)
                {
                    transactionResult.TransactionId = paymentEntity.TransactionId;
                    transactionResult.Code = 1;
                    transactionResult.Message = $"Bu işlem Gerçekleşmiştir! Transaction id {paymentEntity.TransactionId}";
                    return transactionResult;
                }

                //charge from the credit card in this line  
                //if this process success 

                transactionResult.TransactionId = paymentEntity.TransactionId;
                transactionResult.Code = 0;
                transactionResult.Message = "Başarılı işlem";
                transactionResult.PaymentMethod = "KREDI KART";
                transactionResult.ReversedAmount = 0;
                transactionResult.Slot = transaction.Slot;

                product.NumberOfProducts -= transaction.SelectedPieces;
                product.IsAvailable = product.NumberOfProducts <= 0 ? false : true;

                await _productRepository.UpdateAsync(product);

                transaction.IsPaid = true;
                await _transactionRepository.UpdateAsync(transaction);

                return transactionResult;
            }
            catch (Exception)
            {
                //logging 
                transactionResult.TransactionId = paymentEntity.TransactionId;
                transactionResult.Code = 1;
                transactionResult.Message = "Hata oluştu!";
            }

            return transactionResult;
        }

        public async Task<IReadOnlyList<ProductEntity>> ProductGetAll()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();

                return products;
            }
            catch (Exception ex)
            {
                //logging
                return null;
            }
           

        }

        public async Task<ProductSelectionResult> Selection(ProductSelection productSelection)
        {
            ProductSelectionResult productSelectionResult = new ProductSelectionResult();

            try
            {
                 if (productSelection == null)
                 {
                    productSelectionResult.Code = 1;
                    productSelectionResult.Message = "null parameter";
                    return  productSelectionResult;
                  }

                var product = await _productRepository.GetByIdAsync(productSelection.Slot);

                if(product == null)
                {
                    productSelectionResult.Slot = productSelection.Slot;
                    productSelectionResult.Code = 1;
                    productSelectionResult.Message = $"Slot: {productSelection.Slot} Message: Slot bulunamadı!";

                    return productSelectionResult;                   
                }

                if (!product.IsAvailable)
                {
                    productSelectionResult.Slot = productSelection.Slot;
                    productSelectionResult.Code = 1;
                    productSelectionResult.Message = "Ürün Bitti!";
                    return productSelectionResult;
                }

                if (product.NumberOfProducts < productSelection.SelectedPieces)
                {
                    productSelectionResult.Slot = productSelection.Slot;
                    productSelectionResult.Code = 1;
                    productSelectionResult.Message = $"NumberOfProducts: {product.NumberOfProducts} SelectedPieces: {productSelection.SelectedPieces}";
                    return productSelectionResult;
                }

                var totalAmount = productSelection.SelectedPieces * product.PriceOfProduct;

                var campaings = await _campaingRepository.GetAllAsync();

                if( campaings != null && campaings.Count > 0)
                {
                    var campaing = campaings.Where(a => a.Slot == productSelection.Slot).FirstOrDefault();
                    if(campaing != null)
                    {
                        totalAmount += totalAmount * (decimal) campaing.DiscountRatio;
                    }
                }

                TransactionEntity transactionEntity = new TransactionEntity();
                transactionEntity.Slot = productSelection.Slot;
                transactionEntity.SelectedPieces = productSelection.SelectedPieces;
                transactionEntity.TransactionAmount = totalAmount;

                transactionEntity = await _transactionRepository.AddAsync(transactionEntity);

                productSelectionResult.Slot = productSelection.Slot;
                productSelectionResult.TransactionId = transactionEntity.Id;
                productSelectionResult.TotalAmount = totalAmount;
                productSelectionResult.Code = 0;
                productSelectionResult.Message = "Başarılı işlem";

            }
            catch (Exception ex)
            {
                //logging 
                productSelectionResult.Slot = productSelection.Slot;
                productSelectionResult.Code = 1;
                productSelectionResult.Message = "Hata oluştu!";
            }

            return productSelectionResult;
        }
    }
}
