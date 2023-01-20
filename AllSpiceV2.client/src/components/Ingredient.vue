<template>
  <div class="d-flex justify-content-around my-1 height">
    <!-- <li> -->
    <input
      class="form-control mx-1"
      @blur="editIngredient"
      v-if="editMode"
      v-model="ingredient.quantity"
    />
    <input
      class="form-control mx-1"
      @blur="editIngredient"
      v-if="editMode"
      v-model="ingredient.name"
    />
    <div v-else>
      <label class="px-1" v-if="!editMode">{{ ingredient.quantity }}</label>
      <label class="px-1" v-if="!editMode">{{ ingredient.name }}</label>
    </div>
    <!-- </li> -->
    <div v-if="activeRecipe.creatorId == account.id">
      <i
        v-if="!editMode"
        class="mdi mdi-pencil-outline fs-5 p-1 selectable"
        @click="editMode = true"
      ></i>
      <i
        v-if="!editMode"
        class="mdi mdi-delete-forever-outline fs-5 text-danger selectable"
        @click="deleteIngredient"
      ></i>
    </div>
  </div>
</template>


<script>
import { computed, ref } from '@vue/runtime-core'
import { AppState } from '../AppState.js';
import { ingredientService } from '../services/IngredientService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';


export default {
  props: { ingredient: { type: Object, required: true } },
  setup(props) {
    const editMode = ref(false)


    return {
      editMode,
      ingredients: computed(() => AppState.ingredients),
      activeRecipe: computed(() => AppState.activeRecipe),
      account: computed(() => AppState.account),
      async deleteIngredient() {
        try {
          if (await Pop.confirm("Remove?", "Are you sure you want to remove this ingredient?", "Remove", "warning")) {
            await ingredientService.deleteIngredient(props.ingredient.id)
          }
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },

      async editIngredient() {
        try {

          await ingredientService.editIngredient(props.ingredient)
          editMode.value = false
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
.height {
  height: 30px;
}
</style>