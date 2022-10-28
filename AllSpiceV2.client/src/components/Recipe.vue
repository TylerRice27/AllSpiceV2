<template>
  <div class="col-md-4">
    <div
      class="recipe-bg card m-4 elevation-5 d-flex justify-content-between"
      @click="setActive()"
      data-bs-toggle="modal"
      data-bs-target="#details-modal"
    >
      <div class="d-flex flex-row justify-content-between">
        <h6
          class="
            col-md-4
            glass2
            ms-1
            mt-1
            d-flex
            justify-content-center
            text-white
          "
        >
          {{ recipe.category }}
        </h6>
        <h6 class="mdi mdi-heart glass2 mt-1 me-1 text-white"></h6>
      </div>
      <div class="d-flex justify-content-center">
        <h5 class="glass text-white">{{ recipe.title }}</h5>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/runtime-core'
import { recipeService } from '../services/RecipeService'
import { ingredientService } from '../services/IngredientService'

export default {
  props: { recipe: { type: Object, required: true } },
  setup(props) {
    return {
      img: computed(() => `url(${props.recipe?.img}`),
      async setActive() {
        try {

          await recipeService.setActive(props.recipe.id)
          await ingredientService.getIngredients(props.recipe.id)
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