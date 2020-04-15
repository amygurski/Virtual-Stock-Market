<template>
  <div class="text-center research-background">
    <!-- <input type="text" id="search" v-model="search" placeholder="Search Stocks..." /> -->
    <div id="research-container">
      <div class="table-responsive">
        <div class=header>
        <h1>
          Available Stocks</h1>
           <h1 style="text:align-right">  <input type="text" id="search" v-model="search" placeholder="Search Stocks..." /> </h1>
          
        </div>
        <table class="table table-hover table-dark">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Ticker Symbol</th>
              <th scope="col">Name</th>
              <th @click="sort('currentPrice')">Current Price</th>
              <th scope="col">Daily Percent Change</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            <tr v-bind:key="stock.stockSymbol" v-for="stock in filteredData">
              <td>{{stock.stockSymbol}}</td>
              <td>{{stock.companyName}}</td>
              <td>{{ formatCurrency(stock.currentPrice) }}</td>
              <td>{{ stock.percentChange.toFixed(3) }}% <i class="fas fa-2x" v-bind:class="{'fa-caret-up': stock.percentChange > 0 , 'fa-caret-down': stock.percentChange < 0, 'fa-minus': stock.percentChange = 0 }"></i></td>
              <td>
                <router-link
                  :to="{ name: 'confirm-purchase', params: {stockSymbol: stock.stockSymbol, gameId: gameId} }"
                >
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Buy Stock</button>
                </router-link>
              </td>
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
  name: "available-stocks",
  mixins: [HelperMixin],
  data() {
    return {
      search: "",
      stock: Object,
      data: [],
      user: Object,
      gameId: Number,
      currentSort:'name',
  currentSortDir:'asc'
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
      fetch(`${process.env.VUE_APP_REMOTE_API}/stocks/currentprices`, {
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
    },
    sort(s) {
      if(s === this.currentSort) {
        this.currentSortDir = this.currentSortDir ==='asc'?'desc':'asc';
      }
      this.currentSort = s;
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
    // sortedData() {
    //   // eslint-disable-next-line vue/no-side-effects-in-computed-properties
    //   return this.data.sort((a,b) => {
    //     let modifier = 1;
    //     if (this.currentSortDir === 'desc') modifier = -1;
    //     if(a[this.currentSort] < b[this.currentSort]) return -1 * modifier;
    //     if(a[this.currentSort] > b[this.currentSort]) return 1 * modifier;
    //     return 0;
    //   });
    // }
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
  color: plum;
}

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
#search {
  margin: 20px;
  /* border: 10px solid #343a40; */
  border-radius: 10px;
  padding: 2.5px;
  width: 40%;
  height: 10%;
  font-size: 55%;
}
</style>
