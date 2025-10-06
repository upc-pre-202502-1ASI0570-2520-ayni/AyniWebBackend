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
[SwaggerTag("Crops Management Endpoints")]
[Route("/api/v1/[controller]")]
public class CropsController : ControllerBase
{
    
    private readonly ICropService _cropService;
    private readonly IMapper _mapper;

    public CropsController(ICropService cropService, IMapper mapper)
    {
        _cropService = cropService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CropResource>), 200)]
    public async Task<IEnumerable<CropResource>> GetAllAsync()
    {
        var crops = await _cropService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Crop>, 
            IEnumerable<CropResource>>(crops);
        return resources;

    }
    
    [HttpPost]
    [ProducesResponseType(typeof(CropResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveCropResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var crop = _mapper.Map<SaveCropResource, 
            Crop>(resource);
        var result = await _cropService.SaveAsync(crop);
        if (!result.Success)
            return BadRequest(result.Message);
        var cropResource = _mapper.Map<Crop, 
            CropResource>(result.Resource);
        return Created(nameof(PostAsync), cropResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] 
        SaveCropResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var crop = _mapper.Map<SaveCropResource, 
            Crop>(resource);
        var result = await _cropService.UpdateAsync(id, crop);
        if (!result.Success)
            return BadRequest(result.Message);
        var cropResource = _mapper.Map<Crop, 
            CropResource>(result.Resource);
        return Ok(cropResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _cropService.DeleteAsync(id);
 
        if (!result.Success)
            return BadRequest(result.Message);
        var cropResource = _mapper.Map<Crop, 
            CropResource>(result.Resource);
        return Ok(cropResource);
    }



}
