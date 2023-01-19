import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService"



class RecipeService {

  async getRecipes() {
    const res = await api.get("api/recipes")
    logger.log("get my recipes", res.data);
    AppState.recipes = res.data
  }


  async getMyRecipes() {
    const res = await api.get("api/recipes")
    let recipes = AppState.recipes = res.data
    let filteredRec = recipes.filter(r => r.creatorId == AppState.account.id)
    logger.log("filtered", filteredRec)
    AppState.recipes = filteredRec
  }

  async createRecipe(recipeData) {
    const res = await api.post("api/recipes", recipeData)
    logger.log(res.data)
    AppState.recipes.unshift(res.data)
  }

  async setActive(id) {
    const res = await api.get(`api/recipes/${id}`)
    logger.log(res.data)
    AppState.activeRecipe = res.data
  }

  async deleteRecipe(id) {
    const res = await api.delete(`api/recipes/${id}`)
    logger.log('Removing Recipe', res.data)
    AppState.recipes = AppState.recipes.filter(r => r.id != id)
  }

}

export const recipeService = new RecipeService()