using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpiceV2.Models;
using AllSpiceV2.Services;
using CodeWorks.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpiceV2.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {

    private readonly RecipesService _rs;

    private readonly IngredientsService _is;

    private readonly Auth0Provider _auth0Provider;

    public RecipesController(RecipesService rs, IngredientsService @is, Auth0Provider auth0Provider)
    {
      _rs = rs;
      _is = @is;
      _auth0Provider = auth0Provider;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
    {

      try
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        newRecipe.CreatorId = userInfo.Id;
        Recipe recipe = _rs.Create(newRecipe);
        return Ok(recipe);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

    }

    [HttpGet]

    public ActionResult<List<Recipe>> GetAll()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAll();
        return Ok(recipes);

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

    }

    [HttpGet("{id}")]

    public ActionResult<Recipe> GetById(int id)
    {

      try
      {
        Recipe recipe = _rs.GetById(id);
        return Ok(recipe);

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

    }

    [HttpGet("{id}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredientsByRecipe(int id)

    {
      // NOTE Come back here and check good eats
      try
      {
        List<Ingredient> ingredients = _is.GetIngredientsByRecipe(id);
        return Ok(ingredients);

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }


    }


    [HttpPut("{id}")]
    [Authorize]

    public async Task<ActionResult<Recipe>> Edit(int id, [FromBody] Recipe update)
    {
      try
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        update.Id = id;
        Recipe recipe = _rs.Edit(update, userInfo.Id);
        return Ok(recipe);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
        string message = _rs.Delete(id, userInfo.Id);
        return Ok(message);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}