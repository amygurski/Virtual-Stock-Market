<!-- 
  The Header component is used to house the UI and logic to display the header for the web page.
  NOTES:
  - The navigation displays some items depending if the user has logged in or not.  
  DEPENDENCIES:
    None
-->

<template>
  <header>
    <div class="container">
      <h1>TEgram</h1>
      <nav>
        <ul>
          <li class="left-nav">
            <router-link to="/">Home</router-link>
          </li>
          <li>
            <router-link to="/post">Post</router-link>
          </li>
          <li>
            <router-link to="/favorites">Favorites</router-link>
          </li>
          <li v-if="isAuthenticated">
            <a href="/logout" v-on:click.prevent="logout">Logout</a>
          </li>
          <li v-else>
            <router-link to="/login">Login</router-link>
          </li>
        </ul>
      </nav>
    </div>
  </header>
</template>

<script>
import auth from "@/shared/auth";

export default {
  name: "the-header",
  data() {
    return {
      isAuthenticated: auth.getUser() !== null
    };
  },
  methods: {
    /**
     * Logs the user out and takes them to the login page
     * @function
     */
    logout() {
      auth.destroyToken();
      this.$router.push("/login");
    }
  },
  computed: {
    getUser() {
      return auth.getUser();
    }
  }
};
</script>

<style scoped>
header {
  background-color: #fff;
  border-bottom: 1px solid #eee;
}

h1 {
  text-align: center;
  margin-top: 0;
  margin-bottom: 0;
}

ul {
  display: flex;
  justify-content: space-between;
  padding-left: 0;
  margin: 0;
}

li {
  list-style: none;
  line-height: 2rem;
}

li a {
  font-weight: bold;
  font-size: 1.3rem;
}

li.left-nav {
  flex: 2;
}

li:not(.left-nav) {
  margin-left: 1.5rem;
}
</style>
