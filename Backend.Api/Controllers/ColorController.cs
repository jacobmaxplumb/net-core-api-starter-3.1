using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Api.Resources;
using Backend.Api.Validations;
using Backend.Core.Models;
using Backend.Core.Services;

namespace Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        
        public ColorController(IColorService colorService, IMapper mapper)
        {
            this._mapper = mapper;
            this._colorService = colorService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ColorResource>>> GetAllColors()
        {
            var colors = await _colorService.GetAllColors();
            var colorResources = _mapper.Map<IEnumerable<Color>, IEnumerable<ColorResource>>(colors);

            return Ok(colorResources);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Test")]
        public async Task<ActionResult<ColorResource>> GetColorById(int id)
        {
            var color = await _colorService.GetColorById(id);
            var colorResource = _mapper.Map<Color, ColorResource>(color);

            return Ok(colorResource);
        }

        [HttpPost("")]
        [Authorize("OnlyTest")]
        public async Task<ActionResult<ColorResource>> CreateColor([FromBody] SaveColorResource saveColorResource)
        {
            var validator = new SaveColorResourceValidator();
            var validationResult = await validator.ValidateAsync(saveColorResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var colorToCreate = _mapper.Map<SaveColorResource, Color>(saveColorResource);

            var newColor = await _colorService.CreateColor(colorToCreate);

            var color = await _colorService.GetColorById(newColor.Id);

            var colorResource = _mapper.Map<Color, ColorResource>(color);

            return Ok(colorResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColorResource>> UpdateColor(int id, [FromBody] SaveColorResource saveColorResource)
        {
            var validator = new SaveColorResourceValidator();
            var validationResult = await validator.ValidateAsync(saveColorResource);
            
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var colorToBeUpdated = await _colorService.GetColorById(id);

            if (colorToBeUpdated == null)
                return NotFound();

            var color = _mapper.Map<SaveColorResource, Color>(saveColorResource);

            await _colorService.UpdateColor(colorToBeUpdated, color);

            var updatedColor = await _colorService.GetColorById(id);

            var updatedColorResource = _mapper.Map<Color, ColorResource>(updatedColor);

            return Ok(updatedColorResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var color = await _colorService.GetColorById(id);

            await _colorService.DeleteColor(color);
            
            return NoContent();
        }
    }
}