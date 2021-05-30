using System;
using FinalProject.Server.Models;
using FinalProject.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfileController : ControllerBase
  {
    private readonly AccountService _accountService;

    public ProfileController(AccountService accountService)
    {
      _accountService = accountService;
    }
    [HttpGet("{id}")]
    // [Authorize]
    public ActionResult<Profile> GetProfile(string id)
    {
      try
      {
        Profile a = _accountService.GetProfileById(id);
        return Ok(a);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

      //Get Profiles Vaults- Get Vaults by Profile Id
      //Get Profiles Keeps- Get Keeps by ProfileId

    }
  }
}