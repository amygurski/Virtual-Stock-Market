<template>
  <div class="text-center research-background">
    <div id="research-container">
      <div class="table-responsive">
        <h1>Research Stocks</h1>
        <table class="table table-hover table-dark" > 
          <thead class="thead-dark">
            <tr>
              <th scope="col">Ticker Symbol</th>
              <th scope="col">Name</th>
              <th scope="col">Current Price</th>
              <th scope="col">Net Change</th>
              <th scope="col">Percent Change</th>
              <th scope="col">52 Week Low</th>
              <th scope="col">52 Week High</th>
              <th scope="col">Number Of Trades</th>
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
              <td>Test</td>
              <td>Test</td>
              <td>Test</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
//remember to include v-if="data" in table once data has been added
export default {
  name: "research-index"
};
</script>

<style>
.research-background {
  background-color: darkgray;
  background-image: url(/images/register-login-background.jpg);
  padding-top: 5%;
  position: fixed;
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