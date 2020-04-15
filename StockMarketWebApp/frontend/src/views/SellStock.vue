<template>
  <div class="text-center sell-stocks-background">
    <div id="sell-stocks-container">
      <form class="form-stock">
        <h1>Sell Stock</h1>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="sellStockErrors"
        >There were problems selling this stock.</div>
        <table class="table table-hover table-dark text-left">
          <tbody>
            <tr>
              <td>Symbol:</td>
              <td>{{ ownedModel.stockSymbol }}</td>
            </tr>
            <tr>
              <td>Name:</td>
              <td>{{ ownedModel.companyName }}</td>
            </tr>
            <tr>
              <td>Stock Average Purchase Price:</td>
              <td>{{ formatCurrency(ownedModel.avgPurchasedPrice) }}</td>
            </tr>
            <tr>
              <td>Current Share Price:</td>
              <td>{{ formatCurrency(ownedModel.currentSharePrice) }}</td>
            </tr>
            <tr>
              <td>Currently Owned Shares:</td>
              <td>{{ ownedModel.numberOfShares }}</td>
            </tr>
            <tr>
              <td>How many shares do you want to sell?</td>
              <td>
                <input
                  type="number"
                  v-bind:max="ownedModel.numberOfShares"
                  min="1"
                  id="currently-owned-shares"
                  class="form-control"
                  v-model="postApiModel.numberOfShares"
                  autofocus
                />
              </td>
            </tr>
          </tbody>
        </table>
        <div v-if="ownedModel.currentSharePrice > ownedModel.avgPurchasedPrice" class="alert alert-info">
          <h4 >You will make {{formatCurrency((ownedModel.currentSharePrice-ownedModel.avgPurchasedPrice)*postApiModel.numberOfShares)}} in stock value from this sale.</h4>
        </div>
        <div v-else class="alert alert-danger">
          <h4>You will lose {{formatCurrency((ownedModel.avgPurchasedPrice-ownedModel.currentSharePrice)*postApiModel.numberOfShares)}} in stock value from this sale.</h4>
        </div>
        <div class="alert alert-success"> 
          <h5>{{formatCurrency(postApiModel.numberOfShares * ownedModel.currentSharePrice)}} will be returned to your balance.</h5>
        </div>
        <div class="button-group">
          <button
            type="button"
            class="btn btn-primary btn-rounded sell-buttons"
            v-on:click.prevent="buildApiModel()"
          >Confirm Sale</button>
          <router-link :to="{ name: 'owned-stocks', params: {id: gameId } }">
            <button type="button" class="btn btn-secondary btn-rounded sell-buttons">Cancel</button>
          </router-link>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import HelperMixin from "@/mixins/HelperMixins.js";

export default {
  name: "sell-stock",
  mixins: [HelperMixin],
  data() {
    return {
      user: Object,
      token: String,
      stock: Object,
      gameId: Number,
      ownedModel: Object,
      sellStockErrors: false,
      postApiModel: {
        userName: String,
        gameId: Number,
        stockSymbol: String,
        numberOfShares: 1,
        isPurchase: Boolean
      }
    };
  },
  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.gameId = this.$route.params.gameId;
    this.ownedModel = this.$route.params.ownedModel;
  },
  methods: {
    buildApiModel() {
      this.postApiModel.userName = this.user.sub;
      this.postApiModel.gameId = this.gameId;
      this.postApiModel.stockSymbol = this.ownedModel.stockSymbol;
      this.postApiModel.isPurchase = false; //is Sell
      this.sellStock();
    },
    sellStock() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/transactions/newtransaction`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          Authorization: "Bearer " + this.token
        },
        body: JSON.stringify(this.postApiModel)
      })
        .then(response => {
          if (response.ok) {
            this.$router.push({
              path: `/game-detail/${this.gameId}`
            });
          } else {
            this.sellStockErrors = true;
          }
        })

        .then(err => console.error(err));
    }
    // getStockData() {
    //   fetch(
    //     `${process.env.VUE_APP_REMOTE_API}/stocks/detail/${this.stockSymbol}`,
    //     {
    //       method: "GET",
    //       headers: {
    //         Accept: "application/json",
    //         "Content-Type": "application/json",
    //         Authorization: "Bearer " + this.token
    //       }
    //     }
    //   )
    //     .then(response => {
    //       if (response.ok) {
    //         response.json().then(json => {
    //           this.stock = json;
    //         });
    //       } else {
    //         this.sellStockErrors = true;
    //       }
    //     })
    //     .then(err => console.error(err));
    // },
  }
};
</script>

<style scoped>
h1 {
  color: #cce5ff;
}
.sell-stocks-background {
  background-color: darkgray;
  background-image: url(/images/Rules-Page-Background.jpg);
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  height: 100%;
  width: 100%;
}
#sell-stocks-container {
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: #343a40;
  color: white;
  margin: auto;
  padding: 25px;
  width: 35%;
}

.sell-buttons {
  margin: 15px 15px 0px 15px;
}
</style>