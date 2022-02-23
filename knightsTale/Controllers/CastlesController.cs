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
    [Route("api/Controller")]
    public class CastlesController : ControllerBase
    {
        private readonly CastlesService _cs;
        public CastlesController(CastlesService cs)
        {
            _cs = cs;
        }

        // ANCHOR GET ALL
        [HttpGet]
        public ActionResult<List<Castle>> getAll()
        {
            try
            {
                List<Castle> castles = _cs.getAll();
                return Ok(castles);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Castle> getById(int id)
        {
            try
            {
                Castle castle = _cs.getById(id);
                return Ok(castle);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR CREATE 
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Castle>> create([FromBody] Castle castle)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                castle.CreatorId = userInfo.Id;
                Castle newCastle = _cs.create(castle);
                return Created($"/api/castles/{newCastle.Id}", newCastle);
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
                _cs.remove(id, userInfo.Id);
                return Ok("Castle Gone");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ANCHOR GET KNIGHTS BY CASTLE
        //     [HttpGet("{castleId}/knights")]
        //     public ActionResult<List<KnightCastleViewModel>> getKnights(int castleId)
        //     {
        //         try
        //         {
        //             List<KnightCastleViewModel> sirs = _cs
        //         }
        //         catch (Exception e)
        //   {
        //     return BadRequest(e.Message);
        //   }
        //     }
    }
}