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
    private readonly VaultService _vs;


    public ProfileController(ProfileService profileService, KeepService ks, VaultService vs)
    {
      _profileService = profileService;
      _ks = ks;
      _vs = vs;
    }
    [HttpGet("{id}")]
    // [Authorize]
    public ActionResult<Profile> GetProfileById(string id)
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
    [HttpGet("{id}/vaults")]
    public ActionResult<List<Vault>> GetProfileVaultId(string id)
    {
      return Ok(_vs.GetVaultsByProfileId(id));
    }
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeepsByProfileId(string id)
    {
      try
      {
        IEnumerable<Keep> keeps = _ks.GetKeepsByProfileId(id);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}