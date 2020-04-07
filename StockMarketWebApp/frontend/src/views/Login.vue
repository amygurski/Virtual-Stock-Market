<template>
<div id="login-container">
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
        <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="invalidCredentials"
        >Invalid username and password!</div>
        <div
          class="alert alert-success"
          role="alert"
          v-if="this.$route.query.registration"
        >Thank you for registering, please sign in.</div>
        <div class="form-group">
          <label for="username" class="sr-only grey-text">Your Username</label>
          <input
            type="text"
            id="username"
            class="form-control"
            placeholder="Your username"
            v-model="user.username"
            required
            autofocus
          />
        </div>
        <div class="form-group">
          <label for="password" class="sr-only">Your Password</label>
          <input
            type="password"
            id="password"
            class="form-control"
            placeholder="Your password"
            v-model="user.password"
            required
          />
        </div>

        <div class="text-center mt-4 form-group">
          <button type="submit" class="btn btn-primary">LOGIN</button>
        </div>

        <div class="text-center mt-4 form-group">
          <router-link :to="{ name: 'register' }">Need an account?</router-link>
        </div>
    </form>
  </div>
</div>
</template>

<script>
import auth from "../auth";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/login`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.user)
      })
        .then(response => {
          if (response.ok) {
            return response.text();
          } else {
            this.invalidCredentials = true;
          }
        })
        .then(token => {
          if (token != undefined) {
            if (token.includes('"')) {
              token = token.replace(/"/g, "");
            }
            auth.saveToken(token);
            this.$router.push("/");
          }
        })
        .catch(err => console.error(err));
    }
  }
};
</script>

<style>

#login {
  width: 25%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0,0,0,0.05);
  background-color: white;
}

#login-container {
  background: linear-gradient(rgba(255,255,255,.25), rgba(255,255,255,.25)), url(/Images/register-login-background.jpg) no-repeat center center fixed;
  padding: 25px 0px 50px 0px;
  position: fixed;
  width: 100%;
  height: 100%;
}

</style>
