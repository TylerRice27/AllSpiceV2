<template>
	<div class="col-md-4">
		<div class="recipe-bg card m-4 elevation-5 d-flex justify-content-between">
			<div class="d-flex flex-row justify-content-between">
				<h6
					class="
						col-md-4
						glass2
						ms-1
						mt-1
						d-flex
						justify-content-center
						text-white
					"
				>
					{{ recipe.category }}
				</h6>
				<h6 class="mdi mdi-heart glass2 mt-1 me-1 text-danger"></h6>
			</div>
			<div class="d-flex justify-content-center">
				<h5 class="glass text-white">{{ recipe.title }}</h5>
			</div>
		</div>
	</div>
</template>


<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
	props: { recipe: { type: Object, required: true } },
	setup(props) {
		return {
			img: computed(() => `url(${props.recipe?.img}`),
		}
	}
}
</script>


<style lang="scss" scoped>
.recipe-bg {
	background-image: v-bind(img);
	background-position: center;
	background-size: cover;
}

.card {
	height: 15rem;
}
</style>