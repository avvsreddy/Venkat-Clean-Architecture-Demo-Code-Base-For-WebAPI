/*
 * Author: Venkat Shiva Reddy
 * Date: 24/06/2021
 * Email: venkat@pratian.com
 */


using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Example.Domain.Manager;
using Example.Domain.ApiModels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Chinook.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IExampleManager _exampleManager;
        private readonly ILogger<AlbumController> _logger;

        public AlbumController(IExampleManager exampleManager, ILogger<AlbumController> logger)
        {
            _exampleManager = exampleManager;
            _logger = logger;
        }

        
        // GET api/values
        /// <summary>
        /// Get Album Value
        /// </summary>
        /// <remarks>This API will get the values.</remarks>
        [HttpGet]
        [Produces(typeof(List<AlbumApiModel>))]
        public async Task<ActionResult<List<AlbumApiModel>>> GetAsync()
        {
            try
            {
                return new ObjectResult(await _exampleManager.GetAllAlbumAsync());
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(AlbumApiModel))]
        public async Task<ActionResult<AlbumApiModel>> GetAsync(int id)
        {
            try
            {
                var album = await _exampleManager.GetAlbumByIdAsync(id);
                if (album == null)
                {
                    return NotFound();
                }

                return Ok(album);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return StatusCode(500, ex);
            }
        }

        [HttpGet("artist/{id}")]
        [Produces(typeof(List<AlbumApiModel>))]
        public async Task<ActionResult<List<AlbumApiModel>>> GetByArtistIdAsync(int id)
        {
            try
            {
               
                return Ok(await _exampleManager.GetAlbumByArtistIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AlbumApiModel>> PostAsync([FromBody] AlbumApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();

                return StatusCode(201, await _exampleManager.AddAlbumAsync(input));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlbumApiModel>> PutAsync(int id, [FromBody] AlbumApiModel input)
        {
            try
            {
                if (input == null)
                    return BadRequest();
                if (await _exampleManager.GetAlbumByIdAsync(id) == null)
                {
                    return NotFound();
                }

                // var errors = JsonConvert.SerializeObject(ModelState.Values
                //     .SelectMany(state => state.Errors)
                //     .Select(error => error.ErrorMessage));
                // Debug.WriteLine(errors);

                if (await _exampleManager.UpdateAlbumAsync(input))
                {
                    return Ok(input);
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                if (await _exampleManager.GetAlbumByIdAsync(id) == null)
                {
                    return NotFound();
                }

                if (await _exampleManager.DeleteAlbumAsync(id))
                {
                    return Ok();
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                return StatusCode(500, ex);
            }
        }
    }
}