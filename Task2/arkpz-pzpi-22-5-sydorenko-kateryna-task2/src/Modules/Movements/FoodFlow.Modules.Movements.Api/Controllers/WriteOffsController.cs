using FoodFlow.Common;
using FoodFlow.Modules.Movements.Shared.Requests.WriteOff;
using Microsoft.AspNetCore.Mvc;

namespace FoodFlow.Modules.Movements.Api.Controllers;

public class WriteOffsController : BaseController
{
    // create write off
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]List<CreateWriteOffRequest> writeOffRequest, CancellationToken ct)
    {
        //var dto = Mapper.Map<CreateWriteOffRequest, CreateWriteOffDto>(writeOffRequest);

        //return Ok(nameof(GetById))
        return Ok();
    }

    // get write offs
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        //return Ok(nameof(GetById))
        return Ok();
    }
}
