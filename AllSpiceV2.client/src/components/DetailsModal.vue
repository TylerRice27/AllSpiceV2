<template>
	<!-- <div class="row"> -->
	<div class="col-md-5">
		<img class="img-fluid custom" :src="activeRecipe.img" alt="" />
	</div>
	<div class="col-md-3"></div>
	<div class="col-md-3"></div>
	<!-- </div> -->
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
	max-height: auto;
	max-width: auto;
}
</style>