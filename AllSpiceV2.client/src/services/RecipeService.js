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


}

export const recipeService = new RecipeService()