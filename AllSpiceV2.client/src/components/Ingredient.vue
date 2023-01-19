<template>
  <div class="d-flex justify-content-around height">
    <p>
      {{ ingredient.quantity }}
      {{ ingredient.name }}
    </p>
    <div>
      <i
        class="mdi mdi-pencil-outline fs-5 p-1 selectable"
        @click="editIngredient"
      ></i>
      <i
        class="mdi mdi-delete-forever-outline fs-5 text-danger selectable"
        @click="deleteIngredient"
      ></i>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState.js';
import { ingredientService } from '../services/IngredientService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';


export default {
  props: { ingredient: { type: Object, required: true } },
  setup(props) {
    return {
      ingredients: computed(() => AppState.ingredients),
      async deleteIngredient() {
        try {
          if (await Pop.confirm("Destroy Me Maybe?", "Are you sure you want to remove this ingredient?", "Remove", "warning")) {
            await ingredientService.deleteIngredient(props.ingredient.id)
          }
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
.height {
  height: 30px;
}
</style>