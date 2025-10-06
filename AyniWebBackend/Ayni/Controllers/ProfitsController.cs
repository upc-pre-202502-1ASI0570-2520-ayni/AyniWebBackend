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
[SwaggerTag("Profits Management Endpoints")]
[Route("/api/v1/[controller]")]
public class ProfitsController : ControllerBase
{
    private readonly IProfitService _profitService;
    private readonly IMapper _mapper;

    public ProfitsController(IProfitService profitService, IMapper mapper)
    {
        _profitService = profitService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProfitResource>), 200)]
    public async Task<IEnumerable<ProfitResource>> GetAllAsync()
    {
        var profits = await _profitService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Profit>, 
            IEnumerable<ProfitResource>>(profits);
        return resources;

    }
    
    [HttpPost]
    [ProducesResponseType(typeof(ProfitResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveProfitResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var profit = _mapper.Map<SaveProfitResource, 
            Profit>(resource);
        var result = await _profitService.SaveAsync(profit);
        if (!result.Success)
            return BadRequest(result.Message);
        var profitResource = _mapper.Map<Profit, 
            ProfitResource>(result.Resource);
        return Created(nameof(PostAsync), profitResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveProfitResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var profit = _mapper.Map<SaveProfitResource, 
            Profit>(resource);
        var result = await _profitService.UpdateAsync(id, profit);
        if (!result.Success)
            return BadRequest(result.Message);
        var profitResource = _mapper.Map<Profit, 
            ProfitResource>(result.Resource);
        return Ok(profitResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _profitService.DeleteAsync(id);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var profitResource = _mapper.Map<Profit, 
            ProfitResource>(result.Resource);
        return Ok(profitResource);
    }
}