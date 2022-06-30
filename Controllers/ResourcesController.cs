using Microsoft.AspNetCore.Mvc;

namespace MultitenantLab.Controllers;

[ApiController]
[Route("api/{tenantId}/[controller]")] // 在控制器的路由前面加上租户ID
public class ResourcesController : ControllerBase
{
    private readonly ITenantContext _tenantContext;

    public ResourcesController(ITenantContext tenantProvider)
    {
        _tenantContext = tenantProvider;
    }

    [HttpGet]
    public ActionResult Get() //不在方法屬性中綁定租户ID
    {
        return Ok(_tenantContext.GetTenantId()); // 從租户上下文中取得租户ID
    }
}
