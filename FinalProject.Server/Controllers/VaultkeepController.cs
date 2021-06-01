using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Server.Models;
using FinalProject.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class VaultkeepController : ControllerBase
  {
    private readonly VaultkeepService _vks;
    public VaultkeepController(VaultkeepService vks)
    {
      vks = _vks;

    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultkeepService>> Create([FromBody] VaultkeepService vk)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsnyc<Vaultkeep>();
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
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<List<Vaultkeep>> GetAll()
    {

    }


  }

  ///api/vaults/{{vaultId}}/keeps
  //POST, DELETE, GET
}
