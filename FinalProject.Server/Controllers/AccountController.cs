using System;
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
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    public AccountController(AccountService accountService)
    {
      _accountService = accountService;
    }
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<AccountController>> GetTaskAsync()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}