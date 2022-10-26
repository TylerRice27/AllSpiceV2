<template>
  <div class="row">
    <Recipe v-for="r in recipes" :key="r.id" :recipe="r" />
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
      recipes: computed(() => AppState.recipes)

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
</style>
