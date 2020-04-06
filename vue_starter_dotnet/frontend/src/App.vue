<template>
  <div id="app">
    <div id="nav">
      <div v-if="user">
        Logged in
        <div>
          <button v-on:click="logout">Logout</button>
        </div>
      </div>
      <div v-else>
        <div>
          <router-link :to="{name: 'login'}">Login</router-link>
        </div>
        <div>
          <router-link :to="{name: 'register'}">Register</router-link>
        </div>
      </div>
      <router-link to="/">Home</router-link>
    </div>
    <router-view />
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  data() {
    return {
      user: null,
    };
  },
  methods: {
    logout() {
      auth.logout();
      this.$router.push('/login');
      this.user = null;
    },
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
