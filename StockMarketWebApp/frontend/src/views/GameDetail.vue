<template>
  <div id="gamedetail-container">
    <div class="gamedetail text-center">
      <h1>Hi {{user.sub}}!</h1>
      <div class="card-container">
        <div class="card text-white bg-dark detail-card">
          <div class="card-header">Game Id: {{game.gameId}}</div>
          <div class="card-body">
            <h5 class="card-title">Creator: {{game.creatorUsername}}</h5>
            <p class="card-text">{{game.description}}</p>
          </div>
        </div>
        <div class="card text-white bg-dark detail-card">
          <div class="card-header">Your Balance: {{currentBalance}}</div>
          <div class="card-body">
            <h5 class="card-title">The remainder of funds</h5>
            <p class="card-text">You're doing great!</p>
          </div>
        </div>
        <div class="card text-white bg-dark detail-card">
          <div class="card-header">Leaderboard</div>
          <div class="card-body">
            <h5 class="card-title">Winner:</h5>
            <ul class="card-text">
              <li>second place</li>
              <li>third place</li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <div class="gamedetail" id="table-container">
      <table class="table table-hover table-dark detail-table">
        <thead class="thead-dark">
          <tr>
            <th scope="col">Date</th>
            <th scope="col">Co-Trader</th>
            <th scope="col">Stock Symbol</th>
            <th scope="col"># of Shares</th>
            <th scope="col">Share Price</th>
            <th scope="col">Bought/Sold</th>
          </tr>
        </thead>
        <tbody>
          <tr v-bind:key="transaction.userId" v-for="transaction in transactions">
            <td>{{transaction.transactiondate}}</td>
            <td>{{transaction.userid}}</td>
            <td>{{transaction.stockSymbol}}</td>
            <td>{{transaction.numberOfShares}}</td>
            <td>{{transaction.transactionPrice}}</td>
            <td>{{transaction.isPurchase}}</td>
          </tr>
        </tbody>
      </table>
    </div>
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
      id: Number,
      transactions: [],
      ApiModel: {
        username: "",
        gameid: ""
      }
    };
  },
  created() {
    this.id = this.$route.params.id;
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.ApiModel.username = this.user.sub;
    this.ApiModel.gameid = this.$route.params.id;
    this.getData();
    this.getTransactionData();
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
    getTransactionData() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/transactions/getbygameanduser`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + this.token
        },
        body: JSON.stringify(this.ApiModel)
      })
        .then(response => {
          return response.json();
        })
        .then(jsonData => {
          this.transactions = jsonData;
        })
        .catch(e => {
          console.log("Error", e);
        });
    }
  },
  computed: {
    currentBalance: function() {
      let balance = 0;
      if (this.transactions.length > 0) {
        this.transactions.array.forEach(element => {
          balance += Int.parse(element);
        });
      }
      return balance;
    }
  }
};
</script>

<style scoped>
.card-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  flex-wrap: nowrap;
}
.detail-card {
  width: 30%;
}
#table-container {
  margin-top: 5%;
}
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

.gamedetail {
  width: 75%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
}
</style>