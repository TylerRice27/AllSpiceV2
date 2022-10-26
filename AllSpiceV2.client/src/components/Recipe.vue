<template>
  <div class="recipe-bg col-md-4 card">
    <h6>{{ recipe.category }}</h6>
    <h5>{{ recipe.title }}</h5>
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
.recipe-bg {
  //   background-image: url(`${props.recipe.img}`);
}
</style>