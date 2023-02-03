using Example.MondayCom.Webhooks.App.DbContexts;
using kr.bbon.AspNetCore;
using kr.bbon.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Example.MondayCom.Webhooks.App.Controllers;

[ApiController]
[ApiVersion(DefaultValues.ApiVersion)]
[Area(DefaultValues.AreaName)]
[Route(DefaultValues.RouteTemplate)]
public class TestsController : ApiControllerBase
{
    private readonly AppDbContext appDbContext;
    private readonly ILogger logger;

    public TestsController(AppDbContext appDbContext, ILogger<TestsController> logger)
    {
        this.appDbContext = appDbContext;
        this.logger = logger;
    }

    [HttpPost("itemCreated")]
    public async Task<IActionResult> ItemCreated()
    {
        return Ok();
    }
}