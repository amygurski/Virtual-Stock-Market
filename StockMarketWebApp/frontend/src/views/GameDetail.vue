<template>
  <div id="gamedetail-container">
    <div class="row">
      <div class="card-background text-center" id="game-actions">
        <h1>Hi {{user.sub}}!</h1>
        <h2>{{game.name}}</h2>
        <p>{{game.description}}</p>
        <div class="button-group">
          <router-link :to="{name: 'available-stocks', params: {id: game.gameId}}">
            <button
              type="button"
              class="btn btn-primary btn-rounded btn-block buysell-button"
            >Buy Stocks</button>
          </router-link>
          <router-link :to="{name: 'owned-stocks', params: {id: game.gameId}}">
            <button type="button" class="btn btn-danger btn-rounded buysell-button">Sell Stocks</button>
          </router-link>
          <modal name="hello-world">hello, world!</modal>
          <button
            id="show-modal"
            class="btn btn-secondary btn-rounded buysell-button"
            @click="show"
          >Invite Players</button>
          <!-- <router-link :to="{name: 'owned-stocks', params: {id: game.gameId}}">
            <button
              type="button"
              class="btn btn-secondary btn-rounded buysell-button"
            >Invite Players</button>
          </router-link>-->
        </div>
      </div>
      <div class="card-background text-center" id="leaderboard">
        <h1>Leaderboard</h1>
        <ol class="card-text">
          <li
            v-for="leaderboard in game.leaderboardData"
            v-bind:key="leaderboard.userName"
          >{{leaderboard.userName}}: {{formatCurrency(leaderboard.currentBalance)}}</li>
        </ol>
      </div>
    </div>
<<<<<<< HEAD
    <div class="chart-container">
      
      <line-chart-reactive
      v-if="transactionLineLoaded"
      :chartdata="transactionLineData"
      :options="transactionLineOptions"
      />

    </div>
=======
    <div class="card-background chart-container"></div>
>>>>>>> 35ad37d697978044122875a7ab3f960cd2266442
    <owned-stocks-list v-bind:gameId="this.id" v-bind:user="this.user" v-bind:token="this.token"></owned-stocks-list>
    <div class="card-background" id="transaction-table-container">
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
import OwnedStocksList from "@/Components/OwnedStocksList.vue";
<<<<<<< HEAD
import LineChartReactive from "@/Components/LineChartReactive.vue";
=======
>>>>>>> 35ad37d697978044122875a7ab3f960cd2266442

export default {
  name: "game-detail",
  mixins: [HelperMixin],

  components: {
    OwnedStocksList,
<<<<<<< HEAD
    LineChartReactive,
=======
>>>>>>> 35ad37d697978044122875a7ab3f960cd2266442
  },
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
      transactionLineData: {
        labels: Array,
        datasets: [],
      },
      transactionLineOptions: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
      }
    };
  },
  mounted() {
    this.id = this.$route.params.id;
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.ApiModel.username = this.user.sub;
    this.ApiModel.gameid = this.$route.params.id;
    this.getData();
    this.getTransactionData().jsonData;
    // this.buildTransactionLineData();
  },
  //   }  mounted() {

  //   },
  methods: {
    openModal() {
            this.modalOpen = !this.modalOpen;
        },  
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
    show() {
      this.$modal.show("hello-world");
    },
    hide() {
      this.$modal.hide("hello-world");
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
          this.transactions = jsonData
          this.buildTransactionLineData();
        })
        .catch(e => {
          console.log("Error", e);
        });
    },
    buildTransactionLineData() {
<<<<<<< HEAD
      this.transactions.forEach( transaction => {
        transaction.rawDate = new Date(transaction.transactionDate)
      })

      this.transactions.sort((a, b) => {
        return a.rawDate - b.rawDate
      })

      this.transactionLineData.labels = this.buildTransactionLabels();
      this.transactionLineData.datasets.push(
        {
          label: 'Cash Balance',
          data: this.buildTransactionDataPoints()
        }
      )
      this.transactionLineLoaded = true;
=======
      let groomedLabelData = this.buildTransactionLabels();
      this.transactions.sort();
      this.transactionLineRawData = groomedLabelData;
      this.transactionLineData.label = groomedLabelData.formattedDates;
>>>>>>> 35ad37d697978044122875a7ab3f960cd2266442
    },
    buildTransactionLabels() {
      let formattedDatesArr = [];

      // this.transactions.forEach(transaction => {
      //   const rawDate = new Date(transaction.transactionDate);
      //   rawDatesArr.push(rawDate);
      // });

      // rawDatesArr.sort((a, b) => {
      //   return a - b;
      // });

      this.transactions.forEach(transaction => {
        formattedDatesArr.push(this.formatDateAndTime(transaction.rawDate));
      });

<<<<<<< HEAD
      return formattedDatesArr;
    },
    buildTransactionDataPoints() {
      let transactionData = [];
      let transactionBalance = 0;
      this.transactions.forEach( transaction => {
        transactionBalance += transaction.netValue;
        transactionData.push(transactionBalance);
      })
      return transactionData
=======
      return {
        firstDate: rawDatesArr[0],
        rawDates: rawDatesArr,
        formattedDates: formattedDatesArr
      };
>>>>>>> 35ad37d697978044122875a7ab3f960cd2266442
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
    }
  }
};
</script>

<style scoped>
/* .card-container {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  flex-wrap: nowrap;
}
.detail-card {
  width: 25%;
} */

.chart-container {
  width: 75%;
  margin-top: 5%;
}

.btn-primary {
  margin-bottom: 5px;
}

.btn-secondary {
  margin-left: 5px;
}

#header {
  width: 25%;
  padding: 0px;
}

#leaderboard {
  width: 50%;
}
h1 {
  color: #67ddfb;
}
h2 {
  color: white;
}

.card-background {
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid black;
  background-color: #343a40;
  color: white;
}

#transaction-table-container {
  width: 75%;
  margin-top: 5%;
}

#transaction-history-header {
  margin-bottom: 20px;
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

/* .gamedetail {
  width: 75%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
} */

ul {
  padding: 0px;
}

li {
  list-style-type: none;
}

#transaction-history-header {
  margin-bottom: 20px;
}

#owned-stocks-header {
  margin-bottom: 500px;
}

#owned-stocks-container {
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: #343a40;
  color: white;
  margin: auto;
  padding: 25px;
  width: 75%;
}
</style>