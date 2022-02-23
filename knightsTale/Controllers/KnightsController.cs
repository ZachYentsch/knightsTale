using System;
using System.Collections.Generic;
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
    public class KnightsController : ControllerBase
    {
        private readonly KnightsService _ks;
        public KnightsController(KnightsService ks)
        {
            _ks = ks;
        }

        // ANCHOR GET ALL
        [HttpGet]
        public ActionResult<List<Knight>> getAll()
        {
            try
            {
                List<Knight> knights = _ks.getAll();
                return Ok(knights);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Knight> getById(int id)
        {
            try
            {
                Knight knight = _ks.getById(id);
                return Ok(knight);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR CREATE
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Knight>> create([FromBody] Knight knight)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                knight.CreatorId = userInfo.Id;
                Knight newKnight = _ks.create(knight);
                return Created($"/api/knights/{newKnight.Id}", newKnight);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR DELETE
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> remove(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _ks.remove(id, userInfo.Id);
                return Ok("Knight Deleted")
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}