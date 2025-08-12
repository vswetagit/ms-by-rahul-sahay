using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CatalogController : ApiBaseController
    {
        private readonly IMediator _mediator;
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // more than one response return type IActionResult(404 and 200 etc) and ActionResult if specific data needs to be returned 
        [HttpGet]
        [Route("[action]/{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {
            var query = new GetProductByIdQuery(id);
            var output = await _mediator.Send(query);
            if (output != null)
            {
                return Ok(output);
            }
            else { return NotFound(); }
        }

        [HttpGet]
        [Route("[action]/{productName}", Name = "GetProductByProductName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByProductName(string productName)
        {
            var query = new GetProductByNameQuery(productName);
            var output = await _mediator.Send(query);
            if (output != null)
            {
                return Ok(output);
            }
            else { return NotFound(); }
        }

        [HttpGet]
        [Route("[action]", Name = "GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
        {
            var query = new GetAllProductQuery();
            var output = await _mediator.Send(query);
            if (output != null)
            {
                return Ok(output);
            }
            else { return NotFound(); }
        }

        [HttpGet]
        [Route("[action]", Name = "GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
        {
            var query = new GetAllBrandsQuery();
            var output = await _mediator.Send(query);
            if (output != null)
            {
                return Ok(output);
            }
            else { return NotFound(); }
        }

        [HttpGet]
        [Route("[action]", Name = "GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypesResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<TypesResponse>>> GetAllTypes()
        {
            var query = new GetAllTypesQuery();
            var output = await _mediator.Send(query);
            if (output != null)
            {
                return Ok(output);
            }
            else { return NotFound(); }
        }

        [HttpGet]
        [Route("[action]/{brandName}", Name = "GetProductByBrandName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByBrandName(string brandName)
        {
            var query = new GetProductByBrandQuery(brandName);
            var output = await _mediator.Send(query);
            if (output != null)
            {
                return Ok(output);
            }
            else { return NotFound(); }
        }

        [HttpPost]
        [Route("[action]", Name = "CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand product)
        {
            var output = await _mediator.Send(product);
            return Ok(output);
        }

        [HttpPut]
        [Route("[action]", Name = "UpdateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> UpdateProduct([FromBody] UpdateProductCommand product)
        {
            var output = await _mediator.Send(product);
            return Ok(output);
        }

        [HttpDelete]
        [Route("[action]/{productId}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteProduct(string productId)
        {
            var command = new DeleteProductCommand(productId);
            var output = await _mediator.Send(command);
            return Ok(output);
        }
    }
}
