using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Cart.Commands.AddProduct;
using Store.Application.Cart.Commands.AdjustQuantity;
using Store.Application.Cart.Commands.RemoveProduct;
using Store.Application.Cart.Queries.GetCartByUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.WebUI.Controllers
{
    public class CartController : BaseController
    {
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CartViewModel>> Get()
        {
            return Ok(await Mediator.Send(new GetCartQuery() {  UserId = UserId }));
        }

        [Authorize]
        [HttpPost("Add/{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Add(int productId)
        {
            await Mediator.Send(new AddProductCommand() { UserId = UserId,  ProcuctId = productId });

            return NoContent();
        }

        [Authorize]
        [HttpPut("AdjustQuantity/{productId}/{quantity}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AdjustQuantity(int productId , short quantity)
        {            
            await Mediator.Send( new AdjustQuantityCommand() { UserId = UserId, ProcuctId = productId , Quantity = quantity } );

            return NoContent();
        }

        [Authorize]
        [HttpDelete("Remove/{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Remove(int productId)
        {
            await Mediator.Send(new RemoveProductCommand { UserId = UserId, ProcuctId = productId });

            return NoContent();
        }
    }
}
