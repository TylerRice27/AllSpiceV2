<template>
  <!-- <div class="row"> -->
  <div class="row d-flex">
    <div class="col-md-5">
      <img class="img-fluid custom" :src="activeRecipe.img" alt="" />
    </div>

    <div class="col-md-3 ms-4 mt-5 mb-5">
      <div class="card h-100 card-color">
        <h3 class="text-center glass4 text-white">Recipe Instructions</h3>

        <p class="ps-3">{{ activeRecipe.instructions }}</p>
      </div>
    </div>

    <div class="col-md-3 ms-4 mt-5 mb-5">
      <div class="card h-100 card-color">
        <h3 class="text-center d-flex glass4 text-white">Recipe Ingredients</h3>

        <Ingredient v-for="i in ingredients" :key="i.id" :ingredient="i" />

        <div class="input-group mb-3">
          <input type="text" class="form-control ms-2" placeholder="Quantity" />
          <input type="text" class="form-control" placeholder="Ingredient" />
          <button
            @click="createIngredient"
            class="btn btn-warning me-2 my-orange"
            type="button"
          >
            <i title="Add an Ingredient" class="mdi mdi-plus"></i>
          </button>
        </div>

        <!-- <div class="input-group mb-1 mt-4">
          <input
            placeholder="Add an Ingredient!"
            type="text"
            class="rounded p-1 borz form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
          />
          <span class="input-group-text mdi mdi-plus">@</span>
          <i title="Add an Ingredient" class="mdi mdi-plus fs-4"></i>
        </div> -->
      </div>
    </div>
  </div>
</template>


<script>
import { computed, watchEffect, } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { ingredientService } from '../services/IngredientService'
export default {
  setup() {


    return {
      activeRecipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients),


      async createIngredient() {
        try {
          await ingredientService.createIngredient()
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
.custom {
  max-height: 30rem;
  width: 100%;
}

.card-color {
  background-color: #f0f2f4;
}
</style>