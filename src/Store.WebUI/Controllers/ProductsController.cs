using Microsoft.AspNetCore.Mvc;
using Store.Application.Products.Queries.GetAllProducts;
using Store.Application.Products.Queries.GetProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductQuery { Id = id }));
        }

        [HttpGet("search")]
        public async Task<ActionResult<ProductViewModel>> Search(string contains)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery() { DescriptionContains = contains }));
        }
    }
}
