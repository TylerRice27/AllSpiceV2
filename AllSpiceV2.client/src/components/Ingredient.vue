<template>
  <p>
    {{ ingredient.quantity }}
    {{ ingredient.name }}
  </p>
</template>


<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: { ingredient: { type: Object, required: true } },
  setup() {
    return {
      //   ingredients: computed(() => AppState.ingredients)
    }
  }
}
</script>


<style lang="scss" scoped>
</style>