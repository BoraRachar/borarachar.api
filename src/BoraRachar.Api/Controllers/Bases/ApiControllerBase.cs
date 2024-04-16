using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.Bases;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class ApiControllerBase : ApiResultController
{
}