import { AppState } from "../AppState";
import { api } from "./AxiosService"



class RecipeService {

    async getRecipes() {
        const res = await api.get("api/recipes")
        console.log("get my recipes", res.data);
        AppState.recipes = res.data
    }


}

export const recipeService = new RecipeService()