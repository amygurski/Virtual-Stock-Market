<template>
  <div id="mygames-container">
    <div id="mygames" class="text-center">
      <div class="table-responsive">
          <h1>My Games</h1>
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
            <tr v-bind:key="game" v-for="game in data">
              <td>{{ game.creatorUsername }}</td>
              <td>{{ game.gameName }}</td>
              <td>{{ game.dateCreated }}</td>
              <td>{{ game.endDate }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "my-games",
  data() {
    return {
      data: []
    };
  },

  mounted() {
    this.getData();
  },

  methods: {
    getData() {
      // vue-resource example
      fetch(`${process.env.VUE_APP_REMOTE_API}/games/mygames`)
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
#mygames-container {
  background: linear-gradient(rgba(255,255,255,.25), rgba(255,255,255,.25)),url(/Images/Join-Game-Background.png);
  background-size: cover;
  padding-top: 8%;
  position: fixed;
  width: 100%;
  height: 100%;
}

#mygames {
  width: 75%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0,0,0,0.05);
  background-color:#343a40;
  color: white;
}


</style>