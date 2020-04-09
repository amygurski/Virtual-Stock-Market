<template>
  <div id="app">
    <nav-bar></nav-bar>
    <router-view v-bind:user="this.user" v-bind:token="this.token"/>
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
      user: null,
      token: null
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
    this.token = auth.getToken();
  },
  watch: {
    $route: function() {
      this.user = auth.getUser();
      this.token = auth.getToken();
    }
  }
};
</script>

<style>
html {
  background-color: lightgrey;
}
</style>
