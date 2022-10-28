import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"




class IngredientService {

    async getIngredients(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log("ingredients for this recipe", res.data)
        AppState.ingredients = res.data
    }

    async createIngredient(recipeData) {
        const res = await api.create('api/ingredients')
        logger.log("creating an ingredient", res.data)
        AppState.ingredients.push(res.data)
    }


}


export const ingredientService = new IngredientService()