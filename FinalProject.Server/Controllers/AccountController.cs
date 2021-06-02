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
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly KeepService _ks;
    private readonly ProfileService _ps;
    public AccountController(KeepService keepService, ProfileService profileService)
    {
      _ks = keepService;
      _ps = profileService;
    }
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo.Id, userInfo));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("keeps")]
    public async Task<ActionResult<IEnumerable<Profile>>> GetKeepsByProfileIdAsync()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        IEnumerable<Keep> keeps = _ks.getKeepsByAccountId(userInfo.Id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

