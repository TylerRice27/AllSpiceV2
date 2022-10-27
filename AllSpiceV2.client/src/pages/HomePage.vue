<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div
        class="
          card
          elevation-5
          d-flex
          flex-row
          justify-content-evenly
          align-items-center
          ty
        "
      >
        <div class="selectable" @click="getRecipes()">Home</div>
        <div class="selectable" @click="getMyRecipes()">My Recipes</div>
        <div class="selectable" @click="getFavorites()">Favorites</div>
      </div>
    </div>

    <div class="row">
      <Recipe v-for="r in recipes" :key="r.id" :recipe="r" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { recipeService } from '../services/RecipeService'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
export default {
  setup() {
    onMounted(async () => {
      try {
        await recipeService.getRecipes()
      } catch (error) {
        logger.error(error)
        Pop.toast(error.message, 'error')
      }
    }
    )

    return {
      recipes: computed(() => AppState.recipes),
      account: computed(() => AppState.account),
      async getRecipes() {
        try {
          await recipeService.getRecipes()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async getFavorites() {
        try {
          await recipeService.getFavorites()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      async getMyRecipes() {
        try {
          await recipeService.getMyRecipes()
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}

.ty {
  height: 3rem;
  width: 20rem;
  transform: translateY(-32px);
}
</style>
