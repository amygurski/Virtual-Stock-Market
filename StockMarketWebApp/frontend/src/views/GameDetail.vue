<template>
  <div>
    <h1>Id: {{game.gameId}}</h1>
    <h2>Creator: {{game.creatorUsername}}</h2>
    <h3>Name: {{game.name}}</h3>
    <h4>Description: {{game.description}}</h4>
  </div>
</template>

<script>
export default {
  name: "game-detail",
  data() {
    return {
      game: Object,
      token: String,
      user: Object,
      id: Number
    };
  },
  created() {
    this.id = this.$route.params.id;
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.getData();
  },
  //   }  mounted() {

  //   },
  methods: {
    getData() {
      // vue-resource example
      fetch(`${process.env.VUE_APP_REMOTE_API}/games/${this.id}`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + this.token
        }
      })
        .then(response => {
          return response.json();
        })
        .then(jsonData => {
          this.game = jsonData;
        })
        .catch(e => {
          console.log("Error", e);
        });
    }
  }
};
</script>

<style>
</style>