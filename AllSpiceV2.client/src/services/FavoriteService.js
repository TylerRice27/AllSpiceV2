import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService"



class FavoriteService {

  async retrieveFavorites() {
    const res = await api.get('account/favorites')
    logger.log('get ACCOUNT FAVORITES PLEASE', res.data)
    AppState.myFavorites = res.data

  }

  async getFavorites() {
    const res = await api.get("account/favorites")
    logger.log('get favorites', res.data)
    AppState.recipes = res.data
  }

  async createFavorite(fav) {
    const res = await api.post("api/favorites", fav)
    logger.log("[Create Favorite]", res.data)
    AppState.myFavorites.unshift(res.data)
    //  TODO Need to rewrite my backend to get the favorite object back so I can update it manually with 
    // Its favorite Id
  }

  async deleteFavorite(id) {
    const res = await api.delete(`api/favorites/${id}`)
    logger.log('[Delete Favorite]', res.data)
    AppState.myFavorites = AppState.myFavorites.filter(m => m.favoriteId != id)


  }
}





export const favoriteService = new FavoriteService()