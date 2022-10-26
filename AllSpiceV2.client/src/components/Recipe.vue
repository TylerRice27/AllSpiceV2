<template>
  <div class="component">
    {{ recipe }}
  </div>
</template>


<script>
export default {
  props: { recipe: { type: Object, required: true } },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
</style>