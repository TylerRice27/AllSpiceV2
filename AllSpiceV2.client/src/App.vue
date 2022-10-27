<template>
  <header>
    <Navbar />
  </header>
  <main>
    <Modal id="create-form">
      <template #header>
        <h3 class="glass4 text-center text-white">Create a recipe</h3>
      </template>
      <template #body>
        <CreateForm />
      </template>
    </Modal>
    <Modal class="modal-dialog modal-xl" id="details-modal">
      <template #header>
        <div class="d-flex flex-row glass4 justify-content-between">
          <h3 class="text-center text-white">{{ activeRecipe.title }}</h3>
          <h5 class="text-white glass5">{{ activeRecipe.category }}</h5>
          <button
            type="button"
            class="btn-close mt-2 me-1"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
      </template>
      <template #body>
        <DetailsModal />
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
      account: computed(() => AppState.account),
      activeRecipe: computed(() => AppState.activeRecipe)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
