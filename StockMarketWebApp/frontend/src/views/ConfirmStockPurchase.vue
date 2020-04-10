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
<div>Stock Sym: {{stock.symbol}}</div>
<div> Stock Name: {{stock.name}}</div>
<div>Stock Price: {{stock.lastPrice}}</div>
<div> Daily Percent Change: {{stock.percentChange}}</div>

 <div class="form-group">
          <label for="numShares">Name</label>
          <input
            type="text"
            id="numShares"
            class="form-control"
            placeholder="Number of Shares to Buy"
            v-model="game.name"
            required
            autofocus
          />
        </div>
<p>Do you still want to buy this stock?</p>
        <div class="form-group">
          <button class="btn btn-lg btn-primary btn-block" type="submit">Purchase</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "confirm-purchase",
  data() {
    return {
      user: Object,
      token: String,
      stock: Object,
      gameId: Number,
      stockSymbol: String
    };
  },
  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.gameId = this.$route.params.gameId;
    this.stockSymbol = this.$route.params.stockSymbol
  },
  methods: {
    purchaseStock() {
      fetch(`${process.env.VUE_APP_REMOTE_API}/stocks/purchase`, {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          "Authorization": "Bearer " + this.token
        },
        body: JSON.stringify(this.stock)
      })
        .then(response => {
          if (response.ok) {
            response.json().then(json => {
              // gameResult = json
              this.$router.push({
                path: `/stock/available/${json.id}`
              });
            });
          } else {
            this.createGameErrors = true;
          }
        })

        .then(err => console.error(err));
    }
  },
  getStockData() {

  }
};
</script>

<style scoped>
label {
  float: left;
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
  width: 25%;
  padding: 25px;
  margin: auto;
  border-radius: 25px;
  border: 2px solid rgba(0, 0, 0, 0.05);
  background-color: #343a40;
  color: white;
}
</style>
