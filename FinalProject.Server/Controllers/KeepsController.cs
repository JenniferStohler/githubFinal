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
  public class KeepsController : ControllerBase
  {
    private readonly KeepService _ks;
    private readonly VaultService _vs;

    public KeepsController(KeepService ks, VaultService vs)
    {
      _ks = ks;
      _vs = vs;
    }
    [HttpGet]

    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {

        return Ok(_ks.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> GetById(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();

        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<KeepService>> Create([FromBody] Keep newKeep)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newKeep.CreatorId = userInfo.Id;
        Keep created = _ks.Create(newKeep);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Keep>> Update(int id, [FromBody] Keep k)
    {
      Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
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
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
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