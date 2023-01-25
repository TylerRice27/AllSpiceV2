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
    AppState.favorites.unshift(res.data)
  }

  async deleteFavorite(id) {
    const res = await api.delete(`api/favorites/${id}`)
    logger.log('[Delete Favorite]', res.data)
    AppState.myFavorites.filter(m => m.id != id)
  }


}


export const favoriteService = new FavoriteService()