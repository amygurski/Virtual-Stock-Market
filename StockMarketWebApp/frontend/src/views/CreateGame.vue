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
            id="enddate"
            class="form-control"
            placeholder="DateTime.Now"
            v-model="endDate"
            required
          />
          <!-- value="Date.now;" -->
          <!-- v-model="game.endDate" -->
        </div>
        <div class="form-group">
          <label for="enddate">End Time</label>
          <input
            type="time"
            placeholder="16:30:00"
            step="300"
            id="endtime"
            class="form-control"
            v-model="endTime"
            required
          />
          <!-- v-model="game.endTime" -->
        </div>
        <!-- <input type="hidden" id="combinedDateTime" v-model="this.game.endDate" /> -->

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
  data() {
    return {
      endDate: String,
      endTime: String,
      user: Object,
      token: String,
      game: Object,
      createGameErrors: false
    };
  },
  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.game = {
      name: "",
      startDate: "",
      endDate: "",
      description: "",
      userName: this.user.sub
    };
  },
  // computed: {
  //   combinedDateTime: function() {
  //     return this.endDate + "T" + this.endTime;
  //   },
  methods: {
    creategame() {
      this.game.endDate = this.endDate + "T" + this.endTime;
      fetch(`${process.env.VUE_APP_REMOTE_API}/games/newgame`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + this.token
        },
        body: JSON.stringify(this.game)
      })
        .then(response => {
          if (response.ok) {
            response.json().then(json => {
              // gameResult = json
              this.$router.push({
                path: `/game-detail/${json.id}`
              });
            });
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
  padding-bottom: 10%;
  position: fixed;
  overflow: auto;
  width: 100%;
  height: 100%;
  padding-top: 60px;
  padding-bottom: 220px;
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
