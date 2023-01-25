<template>
  <div class="col-md-4">
    <div class="
        recipe-bg
        card
        m-4
        elevation-5
        d-flex
        justify-content-between
        selectable
      " @click="setActive()" data-bs-target="#details-modal">
      <div class="d-flex flex-row justify-content-between selectable">
        <h6 class="
            col-md-4
            glass2
            ms-1
            mt-1
            d-flex
            justify-content-center
            text-white
          ">
          {{ recipe.category }}
        </h6>
        <div>
          <h6 v-if="!isFave" class="mdi mdi-heart-outline glass2 mt-1 me-1 text-white selectable" @click.stop="createFavorite"></h6>
          <h6 v-else class="mdi mdi-heart glass2 mt-1 me-1 text-danger selectable" @click.stop="deleteFavorite"></h6>
        </div>
      </div>
      <div class="d-flex justify-content-between align-items-center">
        <div class="col-8 col-md-7">
          <h5 class="glass text-white text-center">{{ recipe.title }}</h5>
        </div>
        <div v-if="recipe.creatorId == account.id">
          <i class="mdi mdi-delete-forever-outline fs-3 text-danger" @click.stop="deleteRecipe"></i>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/runtime-core'
import { recipeService } from '../services/RecipeService'
import { ingredientService } from '../services/IngredientService'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { Modal } from 'bootstrap'
import { AppState } from '../AppState.js'
import { favoriteService } from '../services/FavoriteService'


export default {
  props: { recipe: { type: Object, required: true } },
  setup(props) {
    return {
      account: computed(() => AppState.account),
      isFave: computed(() => AppState.myFavorites.find(r => r.id == props.recipe.id)),
      img: computed(() => `url(${props.recipe?.img}`),
      async setActive() {
        try {
          await recipeService.setActive(props.recipe.id)
          Modal.getOrCreateInstance(document.getElementById('details-modal')).show()
          await ingredientService.getIngredients(props.recipe.id)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteRecipe() {
        try {
          if (await Pop.confirm("Destroy?", "Are you sure you want to destroy your family recipe?", "Destroy", "warning")) {
            await recipeService.deleteRecipe(props.recipe.id)
          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async createFavorite() {
        try {
          await favoriteService.createFavorite({ recipeId: props.recipe.id })
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async deleteFavorite() {
        try {
          await favoriteService.deleteFavorite(this.isFave.favoriteId)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.recipe-bg {
  background-image: v-bind(img);
  background-position: center;
  background-size: cover;
}

.card {
  height: 15rem;
}
</style>