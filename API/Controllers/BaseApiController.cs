using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers

{

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator => _mediator??= HttpContext.RequestServices.GetService<IMediator>()      // ?? means if null then execute whatever is after =
    ?? throw new InvalidOperationException("IMediator service is unavailable");


}
    
}