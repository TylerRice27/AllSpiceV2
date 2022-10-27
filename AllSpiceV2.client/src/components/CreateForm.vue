<template>
  <form @submit.prevent="createRecipe">
    <div class="mb-1 p-3">
      <label>Title</label>
      <input type="" class="form-control" v-model="recipeData.title" />
    </div>
    <div class="p-3">
      <label>Image</label>
      <input type="" class="form-control" v-model="recipeData.img" />
      <img
        class="img-fluid form-img rounded mt-4"
        :src="recipeData.img"
        alt=""
      />
    </div>
    <div class="mb-1 p-3">
      <label>Instructions</label>
      <input type="" class="form-control" v-model="recipeData.instructions" />
    </div>
    <div class="mb-1 p-3">
      <label>Category</label>
      <input type="" class="form-control" v-model="recipeData.category" />
    </div>
    <div class="modal-footer">
      <button
        type="button"
        class="btn btn-danger"
        data-bs-dismiss="modal"
        @click="resetModal()"
      >
        Close
      </button>
      <button type="submit" class="btn btn-none glass text-white">
        Create
      </button>
    </div>
  </form>
</template>


<script>
import { ref } from '@vue/reactivity'
import { recipeService } from '../services/RecipeService'
import { Modal } from 'bootstrap'
export default {
  setup() {
    const recipeData = ref({})
    return {
      recipeData,
      async createRecipe() {
        try {
          await recipeService.createRecipe(recipeData.value)
          Modal.getOrCreateInstance(document.getElementById('create-form')).hide()
          // Line below clears form after submit
          recipeData.value = {}
        } catch (error) {
          logger.error(error)
          Pop.toast(error.message, 'error')
        }
      },
      resetModal() {
        // Line below clears when modal is closed and not submitted
        recipeData.value = {}
      }
    }
  }
}
</script>


<style lang="scss" scoped>
input {
  border: none !important;
  margin-top: 3px;
}

.form-img {
  width: 29rem;
  height: 20rem;
}
</style>