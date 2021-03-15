using Automat.Application;
using Automat.Application.Model;
using Automat.Application.Port.Outgoing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Automat.API
{
    [Route("[controller]")]
    [ApiController]
    public class AutomatController : ControllerBase
    {
        private IAutomatFacade _automatFacade;

        public AutomatController(IAutomatFacade automatFacade)
        {
            _automatFacade = automatFacade;
        }
            

        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProducts()
        {
            var products = await _automatFacade.ProductGetAll();
            return Ok(products);
        }

        [HttpGet("GetCampaings")]
        [ProducesResponseType(typeof(IEnumerable<CampaingEntity>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CampaingEntity>>> GetCampaings()
        {
            var campaings = await _automatFacade.CampaingGetAll();
            return Ok(campaings);
        }

        [HttpPost("ProductSelection")]
        [ProducesResponseType(typeof(IEnumerable<ProductSelection>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductSelection>>> ProductSelection([FromBody] ProductSelection productSelection)
        {
            var result = await _automatFacade.Selection(productSelection);
            return Ok(result);
        }


        [HttpPost("PaymentByCash")]
        [ProducesResponseType(typeof(IEnumerable<TransactionResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionResult>>> PaymentByCash([FromBody] PaymentByCashEntity paymentByCashCardEntity)
        {

            var result = await _automatFacade.PaymentByCash(paymentByCashCardEntity);
            return Ok(result);
        }


        [HttpPost("PaymentByCreditCard")]
        [ProducesResponseType(typeof(IEnumerable<TransactionResult>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TransactionResult>>> PaymentByCreditCard([FromBody] PaymentByCreditCardEntity paymentByCreditCardEntity)
        {
            var result = await _automatFacade.PaymentByCreditCard(paymentByCreditCardEntity);
            return Ok(result);
        }

    }
}
