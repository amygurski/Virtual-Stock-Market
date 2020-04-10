<template>
  <div class="text-center owned-stocks-background">
    <div id="owned-stocks-container">
      <div class="table-responsive">
        <h1>Owned Stocks</h1>
        <table class="table table-hover table-dark">
          <thead class="thead-dark">
            <tr>
              <th scope="col">Symbol</th>
              <th scope="col">Name</th>
              <th scope="col">Current Share Price</th>
              <th scope="col">Percent Daily Change</th>
              <th scope="col">Stock Purchase Price</th>
              <th scope="col"></th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Test</td>
              <td>Test</td>
              <td>Test</td>
              <td>Test</td>
              <td>Test</td>
              <td>
                <router-link :to="{ name: 'sell-stock' }">
                  <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Sell Stock</button>
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
export default {
  name: "see-owned-stocks"
};
</script>

<style scoped>
.owned-stocks-background {
  background-color: darkgray;
  background-image: url(/images/Rules-Page-Background.jpg);
  padding-top: 5%;
  position: fixed;
  height: 100%;
  width: 100%;
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