<template>
  <div id="creategame-container">
    <div id="creategame" class="text-center">
      <form class="form-creategame" @submit.prevent="purchasestock">
        <h1 class="h3 mb-3 font-weight-normal">Purchase Stock</h1>
        <div
          class="alert alert-danger"
          role="alert"
          v-if="purchaseStockErrors"
        >There were problems purchasing this stock.</div>
        <table class="table table-hover table-dark text-left">
          <tbody>
            <tr>
              <td>Stock Symbol:</td>
              <td>{{stock.stockSymbol}}</td>
            </tr>
            <tr>
              <td>Stock Price:</td>
              <td>{{ formatCurrency(stock.currentPrice) }}</td>
            </tr>
            <tr>
              <td>
                <label for="numShares">How many shares do you want to purchase?</label>
              </td>
              <td>
                <input
                  type="number"
                  min="1"
                  id="numShares"
                  class="form-control"
                  placeholder="Number of Shares to Buy"
                  v-model="postApiModel.numberOfShares"
                  required
                  autofocus
                />
              </td>
            </tr>

            <tr></tr>
          </tbody>
        </table>
        <!-- <div class="row">Stock Sym: {{stock.stockSymbol}}</div>
        <div class="row">Stock Price: {{stock.currentPrice}}</div>-->

        <div class="form-group"></div>
        <!-- <p>Do you still want to buy this stock?</p> -->
        <div class="button-group">
          <button
            class="btn btn-primary purchase-buttons"
            type="submit"
            v-on:click.prevent="buildStockObject()"
          >Purchase Stock</button>

          <router-link :to="{name: 'available-stocks', params: {id: gameId}}">
            <button class="btn btn-secondary purchase-buttons" type="cancel">Cancel</button>
          </router-link>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import HelperMixin from "@/mixins/HelperMixins.js";

export default {
  name: "confirm-purchase",
  mixins: [HelperMixin],
  data() {
    return {
      user: Object,
      token: String,
      stock: Object,
      gameId: Number,
      stockSymbol: String,
      postApiModel: {
        userName: String,
        gameId: Number,
        stockSymbol: String,
        numberOfShares: 0,
        isPurchase: Boolean
      },
      purchaseStockErrors: false
    };
  },
  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.gameId = this.$route.params.gameId;
    this.stockSymbol = this.$route.params.stockSymbol;
    this.getStockData();
  },
  methods: {
    purchaseStock() {
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
            this.purchaseStockErrors = true;
          }
        })

        .then(err => console.error(err));
    },

    getStockData() {
      fetch(
        `${process.env.VUE_APP_REMOTE_API}/stocks/detail/${this.stockSymbol}`,
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
          if (response.ok) {
            response.json().then(json => {
              this.stock = json;
            });
          } else {
            this.purchaseStockErrors = true;
          }
        })
        .then(err => console.error(err));
    },
    buildStockObject() {
      this.postApiModel.userName = this.user.sub;
      this.postApiModel.gameId = this.gameId;
      this.postApiModel.stockSymbol = this.stockSymbol;
      this.postApiModel.numberOfShares = this.postApiModel.numberOfShares * 1;
      this.postApiModel.isPurchase = 1;
      this.purchaseStock();
    }
  }
};
</script>

<style scoped>
h1 {
  color:#67ddfb;
}
#creategame-container {
  background: linear-gradient(
      rgba(255, 255, 255, 0.25),
      rgba(255, 255, 255, 0.25)
    ),
    url(/Images/join-game-background.png);
  background-size: cover;
  padding-top: 5%;
  position: fixed;
  overflow: auto;
  width: 100%;
  height: 100%;
}

#creategame {
  width: 35%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
}

.purchase-buttons {
  margin: 0px 15px 0px 15px;
}
</style>
