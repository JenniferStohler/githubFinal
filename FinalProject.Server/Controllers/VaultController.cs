using System.Collections.Generic;
using FinalProject.Server.Models;
using FinalProject.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultController : ControllerBase
  {
    private readonly VaultService _vs;
    public VaultController(VaultService vs)
    {
      _vs = vs;
    }
    [HttpGet]
    public ActionResult<List<Vault>> GetAll()
    {
      List<Vault> vaults = _vs.GetAll();
      return Ok(vaults);
    }
  }
}