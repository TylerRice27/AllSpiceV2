<template>
  <nav class="navbar-expand-lg navbar-dark back px-3">
    <div class="collapse navbar-collapse justify-content-end" id="navbarText">
      <Login />
    </div>
    <button
      class="navbar-toggler"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <router-link class="navbar-brand" :to="{ name: 'Home' }">
      <h3 class="text-center mt-3 mb-3">All Spice</h3>
      <p class="text-center fs-5 text-white">Cherish Your Family</p>
      <p class="text-center fs-5 text-white">And Their Cooking</p>
    </router-link>
  </nav>
</template>

<script>
import Login from './Login.vue'
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.back {
  background-image: url("../assets/img/allspice.png");
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  height: 18rem;
}
</style>
