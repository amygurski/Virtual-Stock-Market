<template>
  <div id="owned-stocks-container">
    <div class="table-responsive">
      <h3 id="owned-stocks-header" class="text-center" >Owned Stocks</h3>
      <table class="table table-hover table-dark">
        <thead class="thead-dark">
          <tr>
            <th scope="col">Symbol</th>
            <th scope="col">Name</th>
            <th scope="col">Number of Shares</th>
            <th scope="col">Current Share Price</th>
            <th scope="col">Average Purchase Price</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          <tr v-bind:key="stock.stockSymbol" v-for="stock in data">
            <td>{{stock.stockSymbol}}</td>
            <td>{{stock.companyName}}</td>
            <td>{{stock.numberOfShares}}</td>
            <td>{{ formatCurrency(stock.currentSharePrice) }} &nbsp; <i v-bind:class="{'fas fa-2x fa-caret-up': stock.percentChange > 0 , 'fas fa-2x fa-caret-down': stock.percentChange < 0 }"></i></td>
            <td>{{ formatCurrency(stock.avgPurchasedPrice) }}</td>
            <td>
              <router-link
                :to="{ name: 'sell-stock', params: {gameId: gameId, ownedModel: stock } }"
              >
                <button type="button" class="btn btn-danger btn-rounded btn-sm m-0">Sell Stock</button>
              </router-link>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import HelperMixins from "@/mixins/HelperMixins.js";

export default {
  name: "owned-stocks",
  mixins: [HelperMixins],
  data() {
    return {
      data: Array,
      user: Object,
      gameId: Number,
      token: String,
      apiModel: {
        userName: '',
        gameId: ''
      }
      }
    },
  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.gameId = this.$attrs.gameId;
    this.apiModel.userName = this.user.sub;
    this.apiModel.gameId = this.gameId;
    this.ownedStock();
  },
  methods: {
    ownedStock() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/stocks/owned`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + this.token
        },
        body: JSON.stringify(this.apiModel)
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
.fa-caret-up {
  color: green;
}
.fa-caret-down {
  color: red;
}

#owned-stocks-container {
  margin-top: 5%;
}
</style>