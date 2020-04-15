<template>
  <div class="text-center owned-stocks-background">
    <!-- <div id="owned-stocks-container"> -->

    <owned-stocks-list
      v-bind:user="this.user"
      v-bind:gameId="this.gameId"
      v-bind:token="this.token"
    ></owned-stocks-list>
    <!-- </div> -->
  </div>
</template>

<script>
import HelperMixins from "@/mixins/HelperMixins.js";
import OwnedStocksList from "@/Components/OwnedStocksList.vue";

export default {
  name: "owned-stocks",
  mixins: [HelperMixins],
  components: {
    OwnedStocksList
  },
  data() {
    return {
      // data: Array,
      user: Object,
      gameId: Number,
      token: String,
      apiModel: {
        userName: "",
        gameId: ""
      }
    };
  },
  created() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.gameId = this.$route.params.id;
    // this.apiModel.userName = this.user.sub;
    // this.apiModel.gameId = this.gameId;
    // this.ownedStock();
  }
  // methods: {
  //   ownedStock() {
  //     fetch(`${process.env.VUE_APP_REMOTE_API}/stocks/owned`, {
  //       method: "POST",
  //       headers: {
  //         Accept: "application/json",
  //         "Content-Type": "application/json",
  //         Authorization: "Bearer " + this.token
  //       },
  //       body: JSON.stringify(this.apiModel)
  //     })
  //       .then(response => {
  //         return response.json();
  //       })
  //       .then(jsonData => {
  //         this.data = jsonData;
  //       })
  //       .catch(e => {
  //         console.log("Error", e);
  //       });
  //   }
  // }
};
</script>

<style scoped>
.owned-stocks-background {
  background-color: darkgray;
  background-image: url(/images/Rules-Page-Background.jpg);
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  height: 100%;
  width: 100%;
  padding-top: 60px;
  padding-bottom: 220px;
}
#owned-stocks-container {
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


      <!-- <div class="table-responsive">
        <h1>Owned Stocks</h1>
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
              <td>{{ formatCurrency(stock.currentSharePrice) }}</td>
              <td>{{ formatCurrency(stock.avgPurchasedPrice) }}</td>
              <td>
                <router-link
                  :to="{ name: 'sell-stock', params: {gameId: gameId, ownedModel: stock } }"
                >
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Sell Stock</button>
                </router-link>
              </td>
            </tr>
          </tbody>
        </table>
      </div> -->