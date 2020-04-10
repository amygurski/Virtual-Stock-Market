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
            <th scope="col">Stock Symbol</th>
            <th scope="col"># of Shares</th>
            <th scope="col">Share Price</th>
            <th scope="col">Buy/Sell</th>
          </tr>
        </thead>
        <tbody>
          <tr v-bind:key="transaction.userId" v-for="transaction in transactions">
            <td>{{ formatDate(transaction.transactionDate) }}</td>
            <td>{{transaction.stockSymbol}}</td>
            <td>{{transaction.numberOfShares}}</td>
            <td>{{transaction.transactionPrice}}</td>
            <td v-if="transaction.isPurchase" style="color: green">Buy</td>
            <td v-else style="color: red">Sell</td>
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
    },
    formatDate(dateString) {
      let rawDate = new Date(Date.parse(dateString));
      let options = { year: 'numeric', month: '2-digit', day:'2-digit'}
      return new Intl.DateTimeFormat('en-US', options).format(rawDate);
    }
  },
  computed: {
    currentBalance: function() {
      let balance = 0;
      if (this.transactions.length > 0) {
        this.transactions.forEach(element => {
          balance += parseInt(element.numberOfShares * element.transactionPrice);
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
  top: 0;
  left: 0;
  overflow: auto;
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