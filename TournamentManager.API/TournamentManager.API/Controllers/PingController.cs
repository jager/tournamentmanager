using Microsoft.AspNetCore.Mvc;

namespace TournamentManager.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{


    public PingController()
    {
    }

    [HttpGet]
    public string Get()
    {
        return $"Alive: {Request.Host.Value}:{Request.Host.Port} " +
            $"- Content-Type: {Request.ContentType} " +
            $"- Query Params: {string.Join("||", Request.Query.Select(x => $"{x.Key}: {x.Value}").ToArray())}";
    }
}

