using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Orders.Commands.SubmitOrder;

namespace Store.WebUI.Controllers
{
   
    public class OrdersController : BaseController
    {
        [Authorize]
        [HttpPost("Submit")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Submit()
        {
            await Mediator.Send(new SubmitOrderCommand() { UserId = UserId});

            return NoContent();
        }

    }
}