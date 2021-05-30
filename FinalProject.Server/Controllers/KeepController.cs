using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using FinalProject.Server.Models;
using FinalProject.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepController : ControllerBase
  {
    private readonly KeepService _ks;

    public KeepController(KeepService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      try
      {

        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("keeps")]
    [Authorize]
    public async Task<ActionResult<Keep>> GetUserKeeps([FromBody] Keep k)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        k.CreatorId = userInfo.Id;
        Keep newK = _ks.GetUserKeeps(k);
        newK.Creator = userInfo;
        return Ok(newK);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost("{id}")]
    public async Task<ActionResult<KeepService>> Create([FromBody] Keep k)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        k.CreatorId = userInfo.Id;
        Keep newK = _ks.Create(k);
        newK.Creator = userInfo;
        return Ok(newK);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}/keeps")]
    public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep k)
    {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      k.Id = id;
      Keep newK = _ks.Update(k, userInfo.Id);
      newK.Creator = userInfo;
      return Ok(newK);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _ks.Remove(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}