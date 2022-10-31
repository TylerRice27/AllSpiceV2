using System;
using System.Threading.Tasks;
using CodeWorks.Utils;
using AllSpiceV2.Models;
using AllSpiceV2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AllSpiceV2.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;
    private readonly Auth0Provider _auth0Provider;

    private readonly FavoritesService _fs;

    public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoritesService fs)
    {
      _accountService = accountService;
      _auth0Provider = auth0Provider;
      _fs = fs;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("favorites")]
    [Authorize]
    public async Task<ActionResult<Account>> GetFavorites()

    {
      try
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        List<FavoritedRecipe> favorites = _fs.GetAccountFavorites(userInfo.Id);
        return Ok(favorites);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

  }
}
