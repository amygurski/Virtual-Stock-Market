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
              <td>{{stock.stockSymbol}}</td>
            </tr>
            <tr>
              <td>Name:</td>
              <td>{{stock.companyName}}</td>
            </tr>
            <tr>
              <td>Stock Purchase Price:</td>
              <td>{{stock.currentPrice}}</td>
            </tr>
            <tr>
              <td>Current Share Price:</td>
              <td>TBC</td>
            </tr>
            <tr>
              <td>Currently Owned Shares:</td>
              <td>TBC</td>
            </tr>
            <tr>
              <td>How many shares do you want to sell?</td>
              <td>
                <input
                  type="number"
                  max="10"
                  min="0"
                  id="currently-owned-shares"
                  class="form-control"
                  placeholder="0"
                  autofocus
                />
              </td>
            </tr>
          </tbody>
        </table>
        <div class="button-group">
          <button
            type="button"
            class="btn btn-primary btn-rounded sell-buttons"
            v-on:click.prevent="buildStockObject()"
          >Confirm Sale</button>
          <router-link :to="{ name: 'owned-stocks', params: {gameId: id } }">
            <button type="button" class="btn btn-secondary btn-rounded sell-buttons">Cancel</button>
          </router-link>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "sell-stock",
  data() {
    return {
      user: Object,
      token: String,
      stock: Object,
      gameId: Number,
      stockSymbol: String,
      sellStockErrors: false,
      postApiModel: {
        userName: String,
        gameId: Number,
        stockSymbol: String,
        numberOfShares: 0,
        isPurchase: Boolean
      }
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
            this.sellStockErrors = true;
          }
        })
        .then(err => console.error(err));
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
    },
    buildStockObject() {
      this.postApiModel.userName = this.user.sub;
      this.postApiModel.gameId = this.gameId;
      this.postApiModel.stockSymbol = this.stockSymbol;
      this.postApiModel.numberOfShares = this.postApiModel.numberOfShares * 1;
      this.postApiModel.isPurchase = 0; //is Sell
      this.sellStock();
    }
  }
};
</script>

<style scoped>
h1 {
  color:#67ddfb;
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