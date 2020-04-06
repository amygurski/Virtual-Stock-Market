<template>
  <nav class="navbar navbar-expand navbar-dark bg-primary">
    <router-link to="/" class="navbar-brand">
      <img src="../assets/telogo.png" alt width="32" height="32" />
      TE Snippets
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#te-snippets-navbar"
      aria-controls="te-snippets-navbar"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="te-snippets-navbar">
      <ul class="navbar-nav mr-auto">
        <router-link tag="li" class="nav-item" to="/" active-class="active" exact>
          <a class="nav-link">All Snippets</a>
        </router-link>
        <router-link tag="li" class="nav-item" to="/save" active-class="active">
          <a class="nav-link">Add Snippet</a>
        </router-link>
      </ul>
    </div>
    <div class="navbar-collapse collapse">
      <ul class="navbar-nav ml-auto">
        <li class="nav-item" @click="logout">
          <a class="nav-link" href="#">Logout</a>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
import auth from '../auth';

export default {
  name: 'SnippetNavigation',
  methods: {
    logout() {
      auth.logout();
      this.$router.go('/');
    },
  },
};
</script>

<style>
nav {
  margin-bottom: 20px;
}
a.navbar-brand,
a.nav-link {
  font-family: 'Acme', sans-serif;
}
</style>
