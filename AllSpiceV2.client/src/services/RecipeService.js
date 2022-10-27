import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService"



class RecipeService {

  async getRecipes() {
    const res = await api.get("api/recipes")
    logger.log("get my recipes", res.data);
    AppState.recipes = res.data
  }

  async getFavorites() {
    const res = await api.get("account/favorites")
    logger.log('get favorites', res.data)
    AppState.recipes = res.data
  }

  async getMyRecipes() {
    const res = await api.get("api/recipes")
    let recipes = AppState.recipes = res.data
    let filteredRec = recipes.filter(r => r.creatorId == AppState.account.id)
    logger.log("filterd", filteredRec)
    AppState.recipes = filteredRec

  }

}

export const recipeService = new RecipeService()