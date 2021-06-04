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

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultkeepService _vks;
    public VaultKeepsController(VaultkeepService vks)
    {
      _vks = vks;

    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vaultkeep>> Create([FromBody] Vaultkeep vk)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vk.CreatorId = userInfo.Id;
        Vaultkeep newVK = _vks.Create(vk);
        newVK.Creator = userInfo;
        return Ok(newVK);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }
    // [Authorize]
    [HttpGet("{id}")]
    public ActionResult<List<Vaultkeep>> GetById(int id)
    {
      try
      {
        return Ok(_vks.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> Remove(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vks.Remove(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }

  ///api/vaults/{{vaultId}}/keeps
  //POST, DELETE, GET
}
