<template>
	<header>
		<Navbar />
	</header>
	<main>
		<Modal id="create-form">
			<template #header>
				<h3 class="glass text-center text-white">Create a recipe</h3>
			</template>
			<template #body>
				<CreateForm />
			</template>
		</Modal>
		<router-view />
		<div class="add-button">
			<button
				title="Create Recipe"
				v-if="account.id"
				class="glass3"
				data-bs-toggle="modal"
				data-bs-target="#create-form"
			>
				<i class="fs-1 text-white mdi mdi-plus-outline"></i>
			</button>
		</div>
	</main>
	<footer></footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
	setup() {
		return {
			appState: computed(() => AppState),
			account: computed(() => AppState.account)
		}
	},
	components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
