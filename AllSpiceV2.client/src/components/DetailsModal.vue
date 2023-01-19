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

        <div
          v-if="activeRecipe.creatorId == account.id"
          class="input-group mb-3"
        >
          <input
            type="text"
            class="form-control ms-2"
            placeholder="Quantity"
            v-model="editable.quantity"
          />
          <input
            type="text"
            class="form-control"
            placeholder="Name"
            v-model="editable.name"
          />
          <button
            @click="createIngredient"
            class="btn btn-warning me-2 my-orange"
            type="button"
          >
            <i title="Add an Ingredient" class="mdi mdi-plus"></i>
          </button>
        </div>
        <Ingredient v-for="i in ingredients" :key="i.id" :ingredient="i" />
      </div>
    </div>
  </div>
</template>


<script>
import { computed, ref, } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { ingredientService } from '../services/IngredientService'
export default {
  setup() {
    const editable = ref({})


    return {
      editable,
      activeRecipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients),
      account: computed(() => AppState.account),


      async createIngredient() {
        try {
          let ingredient = {
            recipeId: AppState.activeRecipe.id,
            quantity: editable.value.quantity,
            name: editable.value.name
          }
          await ingredientService.createIngredient(ingredient)
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }

      },
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