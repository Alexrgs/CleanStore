using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Store.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        public string UserId
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    return User.FindFirst(ClaimTypes.NameIdentifier).Value;
                };

                return string.Empty;
            }
        }


        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}