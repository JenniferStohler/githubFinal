using System;
using System.Collections.Generic;
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
    private readonly ProfileService _profileService;
    private readonly KeepService _ks;

    public ProfileController(ProfileService profileService, KeepService ks)
    {
      _profileService = profileService;
      _ks = ks;
    }
    [HttpGet("{id}")]
    // [Authorize]
    public ActionResult<Profile> GetProfile(string id)
    {
      try
      {
        Profile profile = _profileService.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }


      //Get Profiles Vaults- Get Vaults by Profile Id
      //Get Profiles Keeps- Get Keeps by ProfileId

    }
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByProfileId(string id)
    {
      try
      {
        IEnumerable<Keep> keeps = _ks.GetByProfileId(id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}