<template>
  <div class="text-center research-background">
    <input type="text" id="search" v-model="search" placeholder="Search Stocks..." />
    <div id="research-container">
      <div class="table-responsive">
        <h1>Research Stocks</h1>
        <table class="table table-hover table-dark">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Ticker Symbol</th>
              <th scope="col">Name</th>
              <th scope="col">Current Price</th>
              <th scope="col">Daily Change %</th>
              <th scope="col">Six Month Low</th>
              <th scope="col">Six Month High</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-bind:key="stock.stockSymbol" v-for="stock in filteredData">
              <td>{{stock.stockSymbol}}</td>
              <td>{{stock.companyName}}</td>
              <td>{{ formatCurrency(stock.currentPrice) }}</td>
              <td>
                {{ stock.percentChange.toFixed(3) }}% &nbsp;
                <i
                  class="fas fa-2x"
                  v-bind:class="{'fa-caret-up': stock.percentChange > 0 , 'fa-caret-down': stock.percentChange < 0 }"
                ></i>
              </td>
              <td>{{formatCurrency(stock.sixMonthLow) }}</td>
              <td>{{formatCurrency(stock.sixMonthHigh) }}</td>
              <td>
                <router-link
                  :to="{name: 'stock-details', params: {stockSymbol: stock.stockSymbol}}"
                >
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
  name: "research-index",
  mixins: [HelperMixin],
  data() {
    return {
      search: "",
      stock: Object,
      data: [],
      user: Object,
      gameId: Number
    };
  },
  mounted() {
    this.token = this.$attrs.token;
    this.user = this.$attrs.user;
    this.gameId = this.$route.params.id;
    this.getData();
  },
  methods: {
    getData() {
      // vue-resource example
      fetch(`${process.env.VUE_APP_REMOTE_API}/stocks/research`, {
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
          this.data = jsonData;
        })
        .catch(e => {
          console.log("Error", e);
        });
    }
  },
  computed: {
    filteredData() {
      const filter = new RegExp(this.search, "i");
      return this.data.filter(
        stock =>
          stock.companyName.match(filter) || stock.stockSymbol.match(filter)
      );
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

.research-background {
  background-color: darkgray;
  background-image: url(/images/register-login-background.jpg);
  padding-top: 3%;
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
  width: 75%;
}
#search {
  margin: 20px;
  border: 10px solid #343a40;
  border-radius: 10px;
  padding: 10px;
  width: 12%;
  font-size: 125%;
}
</style>