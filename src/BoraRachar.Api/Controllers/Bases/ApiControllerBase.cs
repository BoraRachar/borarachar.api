using System.Net.Http.Headers;
using BoraRachar.Domain.Entity.Users;
using Microsoft.AspNetCore.Mvc;

namespace BoraRachar.Api.Controllers.Bases;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class ApiControllerBase : ApiResultController
{
   
}