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
        <h3 class="text-center glass4 text-white">Recipe Instructions</h3>

        <p class="ps-3">{{ activeRecipe.ingredients }}</p>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      activeRecipe: computed(() => AppState.activeRecipe),
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