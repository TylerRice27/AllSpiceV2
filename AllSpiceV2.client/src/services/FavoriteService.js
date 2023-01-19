import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService"



class FavoriteService {

    async getFavorites() {
        const res = await api.get("account/favorites")
        logger.log('get favorites', res.data)
        AppState.recipes = res.data
    }

    async createFavorite(fav) {
        const res = await api.post("api/favorites", fav)
        logger.log("[Create Favorite]", res.data)
        AppState.favorites.unshift(res.data)
    }


}


export const favoriteService = new FavoriteService()