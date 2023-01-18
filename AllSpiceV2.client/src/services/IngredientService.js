import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"




class IngredientService {

  async getIngredients(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log("ingredients for this recipe", res.data)
    AppState.ingredients = res.data
  }

  async createIngredient(ingredient) {
    const res = await api.post('api/ingredients', ingredient)
    logger.log("creating an ingredient", res.data)
    AppState.ingredients.push(res.data)
  }

  async deleteIngredient(id) {
    const res = await api.delete(`api/ingredients/${id}`)
    logger.log("deleting an ingredient", res.data)
    AppState.ingredients = AppState.ingredients.filter(i => i.id != id)
  }


}


export const ingredientService = new IngredientService()