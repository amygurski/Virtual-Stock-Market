<template>
  <div id="app">
    <nav-bar v-bind:user="this.user"></nav-bar>
    <router-view />
    <footer-custom></footer-custom>
  </div>
</template>

<script>
import auth from "@/auth.js";
import NavBar from "@/Components/NavBar.vue"
import FooterCustom from "@/Components/FooterCustom.vue"

export default {
  components: {
          NavBar,
          FooterCustom
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
  background-color: lightgrey;
}
</style>
