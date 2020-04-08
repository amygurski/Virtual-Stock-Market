<template>
  <div id="creategame-container">
    <div id="creategame" class="text-center">
      <form class="form-creategame" @submit.prevent="creategame">
        <h1 class="h3 mb-3 font-weight-normal">Create Game</h1>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="createGameErrors"
        >There were problems creating this game.</div>
        <div class="form-group">
          <label for="startdate">Start Date</label>
          <input type="date" id="startdate" class="form-control" v-model="game.startDate" required />
        </div>

        <div class="form-group">
          <label for="enddate">End Date</label>
          <input
            type="date"
            value="Date.now;"
            id="enddate"
            class="form-control"
            v-model="game.endDate"
            required
          />
        </div>

        <div class="form-group">
          <label for="name" class="sr-only">Name</label>
          <input
            type="text"
            id="name"
            class="form-control"
            placeholder="Game Name"
            v-model="game.name"
            required
            autofocus
          />
        </div>

        <div class="form-group">
          <label for="description" class="sr-only">Description</label>
          <textarea
            id="description"
            class="form-control"
            placeholder="Description"
            v-model="game.description"
            rows="4"
            required
          />
        </div>
        <div class="form-group">
          <button class="btn btn-lg btn-primary btn-block" type="submit">Create Game</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "creategame",
  props: {
    user: Object
  },
  data() {
    return {
      game: {
        name: "",
        startDate: "",
        endDate: "",
        description: "",
        userName: this.user.sub
      },
      createGameErrors: false
    };
  },
  methods: {
    creategame() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/games/newgame`, {
        method: "POST",
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.game)
      })
        .then(response => {
          if (response.ok) {
            response.json().then( json => {
              console.log(json);
              this.$router.push({ name: 'game-detail', params: {id: json.id}})
            })
            
          } else {
            this.createGameErrors = true;
          }
        })

        .then(err => console.error(err));
    }
  }
};
</script>

<style scoped>
label {
  float: left;
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
  width: 100%;
  height: 100%;
}

#creategame {
  width: 25%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
}
</style>
