using System.Net.Mime;
using AutoMapper;
using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Resources;
using AyniWebBackend.Shared.Extensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AyniWebBackend.Ayni.Controllers;

[EnableCors("ReglasCors")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Costs Management Endpoints")]
[Route("/api/v1/[controller]")]
public class CostsController : ControllerBase
{
    private readonly ICostService _costService;
    private readonly IMapper _mapper;

    public CostsController(ICostService costService, IMapper mapper)
    {
        _costService = costService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CostResource>), 200)]
    public async Task<IEnumerable<CostResource>> GetAllAsync()
    {
        var costs = await _costService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Cost>, IEnumerable<CostResource>>(costs);
        return resources;

    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CostResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveCostResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var cost = _mapper.Map<SaveCostResource, 
            Cost>(resource);
        var result = await _costService.SaveAsync(cost);
        if (!result.Success)
            return BadRequest(result.Message);
        var costResource = _mapper.Map<Cost, CostResource>(result.Resource);
        return Created(nameof(PostAsync), costResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveCostResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var cost = _mapper.Map<SaveCostResource, 
            Cost>(resource);
        var result = await _costService.UpdateAsync(id, cost);
        if (!result.Success)
            return BadRequest(result.Message);
        var costResource = _mapper.Map<Cost, 
            CostResource>(result.Resource);
        return Ok(costResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _costService.DeleteAsync(id);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var costResource = _mapper.Map<Cost, 
            CostResource>(result.Resource);
        return Ok(costResource);
    }
}
