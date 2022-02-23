using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using knightsTale.Models;
using knightsTale.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace knightsTale.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ManorsController : ControllerBase
    {
        private readonly ManorsService _ms;
        public ManorsController(ManorsService ms)
        {
            _ms = ms;
        }

        // [Authorize]
        [HttpPost]
        public async Task<ActionResult<Manor>> create([FromBody] Manor manor)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // manor.KnightId = userInfo.Id
                Manor newManor = _ms.create(manor);
                return Created($"/api/manors/{newManor.Id}", newManor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> remove(int id)
        {
            try
            {
                _ms.remove(id);
                return Ok("Manor Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}