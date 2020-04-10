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
<div>Stock: {{stock.symbol}}, {{stock.name}}</div>
<div>{{stock.lastPrice}}, {{stock.percentChange}}</div>
<p>Do you still want to buy this stock?</p>
        <div class="form-group">
          <button class="btn btn-lg btn-primary btn-block" type="submit">Purchase Stock</button>
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
    };
  },
  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.getData();
  },
  methods: {
    creategame() {
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
