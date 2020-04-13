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
          <div class="card-header">Your Balance: {{ formatCurrency(computedCurrentBalance) }}</div>
          <div class="card-body">
            <h5 class="card-title">The remainder of funds</h5>
            <p class="card-text">You're doing great!</p>
          </div>
        </div>
        <div class="card text-white bg-dark detail-card">
          <div class="card-header">Leaderboard</div>
          <div class="card-body">
            <ol class="card-text">
              <li
                v-for="leaderboard in game.leaderboardData"
                v-bind:key="leaderboard.userName"
              >{{leaderboard.userName}}: {{formatCurrency(leaderboard.currentBalance)}}</li>
            </ol>
          </div>
        </div>
      </div>
      <div class="buysell-container">
        <router-link :to="{name: 'available-stocks', params: {id: game.gameId}}">
          <button type="button" class="btn btn-primary btn-rounded buysell-button">Buy Stocks</button>
        </router-link>
        <router-link :to="{name: 'owned-stocks', params: {id: game.gameId}}">
          <button type="button" class="btn btn-primary btn-rounded buysell-button">Sell Stocks</button>
        </router-link>
      </div>
    </div>
    <div class="chart-container">
      


    </div>
    <div class="gamedetail" id="transaction-table-container">
      <h3 id="transaction-history-header" class="text-center">Transaction History</h3>
      <table class="table table-hover table-dark detail-table">
        <thead class="thead-dark">
          <tr>
            <th scope="col">Date</th>
            <th scope="col">Stock Symbol</th>
            <th scope="col">Company Name</th>
            <th scope="col"># of Shares</th>
            <th scope="col">Share Price</th>
            <th scope="col">Buy/Sell</th>
            <th scope="col">Net Value</th>
          </tr>
        </thead>
        <tbody>
          <tr v-bind:key="transaction.transactionDate" v-for="transaction in transactions">
            <td>{{ formatDateOnly(transaction.transactionDate) }}</td>
            <td>{{transaction.stockSymbol}}</td>
            <td>{{transaction.companyName}}</td>
            <td>{{transaction.numberOfShares}}</td>
            <td>{{formatCurrency(transaction.transactionPrice)}}</td>
            <td v-if="transaction.isPurchase" style="color: green">Buy</td>
            <td v-else style="color: red">Sell</td>
            <td>{{formatCurrency(transaction.netValue)}}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import HelperMixin from "@/mixins/HelperMixins.js";

export default {
  name: "game-detail",
  mixins: [HelperMixin],
  data() {
    return {
      game: Object,
      token: String,
      user: Object,
      id: Number,
      currentBalance: Number,
      transactions: [],
      ApiModel: {
        username: "",
        gameid: ""
      },
      transactionLineLoaded: false,
      transactionLineData: {},
      transactionLineOptions: {}
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
    buildTransactionLineData() {
      console.log(this.buildTransactionLabels());
    },
    buildTransactionLabels() {
      let rawDatesArr = [];
      let formattedDatesArr = [];

      this.transactions.forEach(transaction => {
        const rawDate = new Date(transaction.transactionDate);
        rawDatesArr.push(rawDate);
      });

      rawDatesArr.sort((a, b) => {
        return a - b;
      });

      rawDatesArr.forEach(rawDate => {
        formattedDatesArr.push(this.formatDateAndTime(rawDate));
      });

      return {
        firstDate: rawDatesArr[0],
        rawDates: rawDatesArr,
        formattedDates: formattedDatesArr
      }
    }
  },
  computed: {
    computedCurrentBalance: function() {
      let balance = 0;
      if (this.game.leaderboardData !== undefined) {
        this.game.leaderboardData.forEach(ele => {
          if (ele.userName === this.user.sub) {
            balance = ele.currentBalance;
          }
        });
      }
      return balance;
    },
    computedDateTest: function() {
      return new Date(this.transactions[0].transactionDate);
    },
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
  width: 25%;
}
#transaction-table-container {
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
  padding-bottom: 10%;
  position: fixed;
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

.buysell-button {
  width: 30%;
  margin: 25px 25px 0px 25px;
}

ul {
  padding: 0px;
}

li {
  list-style-type: none;
}

#transaction-history-header {
  margin-bottom: 20px;
}
</style>