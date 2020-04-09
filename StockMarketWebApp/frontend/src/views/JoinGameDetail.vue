<template>
  <div id="gamedetail-container">
    <div id="gamedetail" class="text-center">
      <div class="table-responsive">
        <h1>Game Details</h1>
        <div class="card text-white bg-dark mb-3" style="max-width: 18rem;">
          <div class="card-header">Header</div>
          <div class="card-body">
            <h5 class="card-title">Dark card title</h5>
            <p
              class="card-text"
            >Some quick example text to build on the card title and make up the bulk of the card's content.</p>
          </div>
        </div>
        <div class="card text-white bg-primary mb-10" style="max-width: 75%;">
          <div class="card-header">Game Id: {{game.gameId}} Game Owner: {{game.creatorUsername}}</div>
          <div class="card-body">
            <h5 class="card-title">{{game.name}}</h5>
            <p class="card-text">{{game.description}}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "join-game-detail",
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
#gamedetail-container {
  background: linear-gradient(
      rgba(255, 255, 255, 0.25),
      rgba(255, 255, 255, 0.25)
    ),
    url(/Images/Join-Game-Background.png);
  background-size: cover;
  padding-top: 5%;
  position: fixed;
  width: 100%;
  height: 100%;
}

#gamedetail {
  width: 75%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
}
</style>