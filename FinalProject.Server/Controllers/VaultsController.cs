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
  public class VaultsController : ControllerBase
  {
    private readonly VaultService _vs;
    public VaultsController(VaultService vs)
    {
      _vs = vs;
    }
    [HttpGet]
    public ActionResult<List<Vault>> GetAll()
    {
      try
      {
        List<Vault> vaults = _vs.GetAll();
        return Ok(vaults);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        Vault vault = _vs.Get(id);
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/keeps")]
    public ActionResult<List<VaultKeepViewModel>> GetKeepsByVaultId(int id)
    {
      try
      {
        List<VaultKeepViewModel> keeps = _vs.GetKeepsByVaultId(id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault v)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        v.CreatorId = userInfo.Id;
        Vault newV = _vs.Create(v);
        newV.Creator = userInfo;
        return Ok(newV);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Vault>> Update(int id, [FromBody] Vault v)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        v.Id = id;
        Vault newV = _vs.Update(v, userInfo.Id);
        newV.Creator = userInfo;
        return Ok(newV);
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
        _vs.Remove(id, userInfo.Id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //Add Get Keep by Vault Id

  }
}