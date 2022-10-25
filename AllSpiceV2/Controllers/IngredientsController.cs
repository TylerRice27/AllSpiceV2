using AllSpiceV2.Services;
using CodeWorks.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using AllSpiceV2.Models;
using System;

namespace AllSpiceV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _is;

        private readonly Auth0Provider _auth0Provider;

        public IngredientsController(IngredientsService @is, Auth0Provider auth0Provider)
        {
            _is = @is;
            _auth0Provider = auth0Provider;
        }

        [HttpPost]
        // NOTE Does not auto import Authorize line for 
        // using Microsoft.AspNetCore.Authorization;
        [Authorize]


        public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient newIngredient)
        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

                Ingredient ingredient = _is.Create(newIngredient);
                return Ok(ingredient);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<Ingredient>> Delete(int id)

        {
            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

                Ingredient ingredient = _is.Delete(id, userInfo.Id);
                // To return a message you need to return it in quotations or you can return the whole object
                return Ok("Ingredient has been deleted");

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }



    }


}