<template>
  <div id="joingame-container">
    <div id="joingame" class="text-center">
      <div class="table-responsive">
        <h1>Join a Game</h1>
        <table class="table table-hover table-dark" v-if="data">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Creator</th>
              <th scope="col">Game Name</th>
              <th scope="col">Date Created</th>
              <th scope="col">Game Ends</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-bind:key="game.gameId" v-for="game in data">
              <td>{{ game.creatorUsername }}</td>
              <td>{{ game.name }}</td>
              <td>{{ game.dateCreated }}</td>
              <td>{{ game.endDate }}</td>
              <td>
                <router-link :to="{ name: 'join-game-detail', params: {id: game.gameId} }">
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Join Game</button>
                </router-link>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "join-game",
  data() {
    return {
      data: Array,
      user: Object,
      token: String
    };
  },

  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.getData();
  },

  methods: {
    getData() {
      console.log("token: " + this.token);
      // vue-resource example
      fetch(`${process.env.VUE_APP_REMOTE_API}/games/currentgames`, {
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
          this.data = jsonData;
        })
        .catch(e => {
          console.log("Error", e);
        });
    }
  }
};
</script>

<style scoped>
#joingame-container {
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
  padding-top: 60px;
  padding-bottom: 220px;
}

#joingame {
  width: 75%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
}
</style>