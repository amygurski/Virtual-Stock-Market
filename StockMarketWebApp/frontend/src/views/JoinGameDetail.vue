<template>
  <div id="creategame-container">
    <div id="creategame" class="text-center">
      <h1 class="h3 mb-3 font-weight-normal">Game Detail</h1>
      <table class="table table-hover table-dark text-left">
        <tbody>
          <tr>
            <td>Game:</td>
            <td>{{game.name}}</td>
          </tr>
          <tr>
            <td>Creator:</td>
            <td>{{game.creatorUsername}}</td>
          </tr>
          <tr>
            <td>Game Start Date:</td>
            <td>{{game.dateCreated}}</td>
          </tr>
          <tr>
            <td>Game End Date:</td>
            <td>{{game.endDate}}</td>
          </tr>
          <tr>
            <td>Game Description:</td>
            <td>{{game.description}}</td>
          </tr>
        </tbody>
      </table>
      <!-- <div class="row">Stock Sym: {{stock.stockSymbol}}</div>
      <div class="row">Stock Price: {{stock.currentPrice}}</div>-->

      <div class="form-group"></div>
      <!-- <p>Do you still want to buy this stock?</p> -->
      <div class="button-group">
        <button
          class="btn btn-primary purchase-buttons"
          type="submit"
          v-on:click.prevent="addUserToGame"
        >Join Game</button>

        <router-link :to="{name: 'join-game'}">
          <button class="btn btn-secondary purchase-buttons" type="cancel">Cancel</button>
        </router-link>
      </div>
    </div>
  </div>
  <!-- <div id="gamedetail-container">
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
  </div>-->
</template>

<script>
export default {
  name: "join-game-detail",
  data() {
    return {
      inviteUserAPI: {
        userName: "",
        gameId: ""
      },
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
    this.inviteUserAPI.gameId = this.id;
    this.inviteUserAPI.userName = this.user.sub;
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
    },
    addUserToGame() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/games/joingame`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + this.token
        },
        body: JSON.stringify(this.inviteUserAPI)
      })
        .then(response => {
          if (response.ok) {
            this.$router.push({
              name: "game-detail",
              params: {
                id: this.game.gameId,
                alertMessage:
                  "You have successfully joined this game. Have fun!",
                alertSuccess: true
              }
            });
          } else {
            this.$router.push({
              name: "game-detail",
              params: {
                id: this.game.gameId,
                alertMessage:
                  "You are already playing this game. Here's the details. Have fun!",
                alertSuccess: false
              }
            });
          }
        })
        .catch(e => {
          console.log("Error", e);
        });
    }
  }
};
</script>

<style scoped>
h1 {
  color: #67ddfb;
}
#creategame-container {
  background: linear-gradient(
      rgba(255, 255, 255, 0.25),
      rgba(255, 255, 255, 0.25)
    ),
    url(/Images/join-game-background.png);
  background-size: cover;
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  width: 100%;
  height: 100%;
  padding-top: 60px;
  padding-bottom: 220px;
}

#creategame {
  width: 35%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
}

.purchase-buttons {
  margin: 0px 15px 0px 15px;
}
/* #gamedetail-container {
  background: linear-gradient(
      rgba(255, 255, 255, 0.25),
      rgba(255, 255, 255, 0.25)
    ),
    url(/Images/Join-Game-Background.png);
  background-size: cover;
  padding-top: 5%;
  position: fixed;
  overflow: auto;
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
} */
</style>