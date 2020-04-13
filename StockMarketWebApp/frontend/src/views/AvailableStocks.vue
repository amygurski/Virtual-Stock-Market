<template>
  <div class="text-center research-background">
    <div id="research-container">
      <div class="table-responsive">
        <h1>Available Stocks</h1>
        <table class="table table-hover table-dark" > 
          <thead class="thead-dark">
            <tr>
              <th scope="col">Ticker Symbol</th>
              <th scope="col">Name</th>
              <th scope="col">Current Price</th>
              <th scope="col">Daily Percent Change</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-bind:key="stock.stockSymbol" v-for="stock in data">
              <td>{{stock.stockSymbol}}</td>
              <td>{{stock.companyName}}</td>
              <td>{{ formatCurrency(stock.currentPrice) }}</td>
              <td>{{ stock.percentChange.toFixed(3) }}%</td>
              <td>
                <router-link :to="{ name: 'confirm-purchase', params: {stockSymbol: stock.stockSymbol, gameId: gameId} }">
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Buy Stock</button>
                </router-link>
              </td>
              <td>
                <router-link :to="{name: 'stock-details', params: {stockSymbol: stock.stockSymbol}}">
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Stock Details</button>
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
import HelperMixin from "@/mixins/HelperMixins.js";

//remember to include v-if="data" in table once data has been added
export default {
  name: "available-stocks",
  mixins: [HelperMixin],
  data() {
      return {
          stock: Object,
          data: Array,
          user: Object,
          gameId: Number,
      };
  },
  mounted() {
    this.token = this.$attrs.token
    this.user = this.$attrs.user
    this.gameId = this.$route.params.id
    this.getData();
  },
  methods: {
      getData() {
      // vue-resource example
      fetch(`${process.env.VUE_APP_REMOTE_API}/stocks/currentprices`, {
        method: "GET",
        headers: {
          "Content-Type": 'application/json',
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
.research-background {
  background-color: darkgray;
  background-image: url(/images/register-login-background.jpg);
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  height: 100%;
  width: 100%;
}
#research-container {
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: #343a40;
  color: white;
  margin: auto;
  padding: 25px;
  width: 60%;
}
</style>