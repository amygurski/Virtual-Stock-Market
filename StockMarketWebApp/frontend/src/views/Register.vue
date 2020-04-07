<template>
<div id="register-container">
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        There were problems registering this user.
      </div>

      <div class="form-group">
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      </div>
      <div class="form-group">
      <label for="firstname" class="sr-only">First Name</label>
      <input
        type="text"
        id="firstname"
        class="form-control"
        placeholder="First Name"
        v-model="user.firstname"
        required
      />
      </div>
      <div class="form-group">
      <label for="email" class="sr-only">Email</label>
      <input
        type="email"
        id="email"
        class="form-control"
        placeholder="Email"
        v-model="user.email"
        required
      />
      </div>
      <div class="form-group">
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      </div>
      <div class="form-group">
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      </div>
      <div class="form-group">
        <button class="btn btn-lg btn-primary btn-block" type="submit">
          Create Account
        </button>
      </div>
      <div class="form-group">
        <router-link :to="{ name: 'login' }">
          Have an account?
        </router-link>
      </div>

    </form>
  </div>
</div>
</template>

<script>
export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        firstname: '',
        email: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
    };
  },
  methods: {
    register() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/register`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.user),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/login', query: { registration: 'success' } });
          } else {
            this.registrationErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },
};
</script>

<style scoped>
#register-container {
  background: linear-gradient(rgba(255,255,255,.25), rgba(255,255,255,.25)),url(/Images/register-login-background.jpg) no-repeat center center fixed;
  padding: 25px 0px 25px 0px;
  position: fixed;
  width: 100%;
  height: 100%;
}

#register {
  width: 25%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0,0,0,0.05);
  background-color: white;
}

</style>
