<template>
  <div class="text-center detail-background">
    <div id="detail-container">
      <div class="table-responsive">
        <h1>{{stock.companyName}} Details</h1>
        <table class="table table-hover table-dark">
          <tbody>
            <tr>
              <th>Ticker Symbol</th>
              <td>{{stock.stockSymbol}}</td>
            </tr>
            <tr>
              <th>Current Price</th>
              <td>{{formatCurrency(stock.currentPrice)}}</td>
            </tr>
            <tr>
              <th>Daily Change</th>
              <td>
                {{ stock.dailyChange.toFixed(3) }}%
                <i
                  class="fas fa-2x"
                  v-bind:class="{'fa-caret-up': stock.dailyChange > 0 , 'fa-caret-down': stock.dailyChange < 0, 'fa-minus': stock.dailyChange === 0 }"
                ></i>
              </td>
            </tr>
            <tr>
              <th>Six Month Net Change</th>
              <td>{{formatCurrency(stock.netChangeSixMonths)}}</td>
            </tr>
            <tr>
              <th>Six Month Low</th>
              <td>{{formatCurrency(stock.sixMonthLow)}}</td>
            </tr>
            <tr>
              <th>Six Month High</th>
              <td>{{formatCurrency(stock.sixMonthHigh)}}</td>
            </tr>
            <tr>
              <th>Previous Day Volume</th>
              <td>{{stock.previousDayVolume}}</td>
            </tr>
            <tr>
              <th>Average Daily Volume</th>
              <td>{{stock.averageDailyVolume.toFixed(0) }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import HelperMixins from "@/mixins/HelperMixins.js";

export default {
  name: "stock-details",
  mixins: [HelperMixins],
  data() {
    return {
      stock: Object,
      data: Array,
      user: Object,
      gameId: Number,
      token: String,
      symbol: String,
      apiModel: {
        userName: "",
        gameId: ""
      }
    };
  },
  created() {
    this.symbol = this.$route.params.stockSymbol;
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.gameId = this.$attrs.gameId;
    this.apiModel.userName = this.user.sub;
    this.apiModel.gameId = this.gameId;
    this.getData();
  },
  methods: {
    getData() {
      fetch(
        `${process.env.VUE_APP_REMOTE_API}/stocks/research/${this.symbol}`,
        {
          method: "GET",
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
            Authorization: "Bearer " + this.token
          }
        }
      )
        .then(response => {
          return response.json();
        })
        .then(jsonData => {
          this.stock = jsonData;
        })
        .catch(e => {
          console.log("Error", e);
        });
    }
  }
};
</script>

<style scoped>
.fa-caret-up {
  color: green;
}
.fa-caret-down {
  color: red;
}
.fa-minus {
  color: blue;
}
.detail-background {
  background-color: darkgray;
  background-image: url(/images/register-login-background.jpg);
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  height: 100%;
  width: 100%;
  padding-top: 60px;
  padding-bottom: 220px;
}
#detail-container {
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: #343a40;
  color: white;
  margin: auto;
  padding: 25px;
  width: 35%;
}
</style>