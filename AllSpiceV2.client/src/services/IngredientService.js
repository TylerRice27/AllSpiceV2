import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"




class IngredientService {

    async getIngredients(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log("ingredients for this recipe", res.data)
        AppState.ingredients = res.data
    }


}


export const ingredientService = new IngredientService()