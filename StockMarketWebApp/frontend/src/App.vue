<template>
  <div id="app">
    <nav-bar></nav-bar>
    <router-view />
  </div>
</template>

<script>
import auth from "@/auth.js";
import NavBar from "@/Components/NavBar.vue"

export default {
  components: {
          NavBar
  },
  data() {
    return {
      user: null
    };
  },
  methods: {
    logout() {
      auth.logout();
      this.$router.push("/login");
      this.user = null;
    }
  },
  created() {
    this.user = auth.getUser();
  },
  watch: {
    $route: function() {
      this.user = auth.getUser();
    }
  }
};
</script>

<style>
html {
  background-color: #343a40;
}
</style>
