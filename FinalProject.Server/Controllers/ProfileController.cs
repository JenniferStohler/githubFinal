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
    private readonly ProfileService _profileService;

    public ProfileController(ProfileService profileService)
    {
      _profileService = profileService;
    }
    [HttpGet("{id}")]
    // [Authorize]
    public ActionResult<Profile> GetProfile(string id)
    {
      try
      {
        Profile p = _profileService.GetProfileById(id);
        return Ok(p);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }
  }
}