<template>
  <div class="text-center detail-background">
    <div id="detail-container">
      <div class="table-responsive">
        <h1>Stock Details</h1>
        <table class="table table-hover table-dark">
          <thead class="thead-dark">
            <tr>
              <th scope="row">Ticker Symbol</th>
              <th scope="row">Name</th>
              <th scope="row">Volume</th>
              <th scope="row">Net Change</th>
              <th scope="row">1-Year Change</th>
              <th scope="row">52 Week Range</th>
              <th scope="row">Revenue</th>
              <th scope="row"></th>
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
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "stock-details"
};
</script>

<style scoped>
.detail-background {
  background-color: darkgray;
  background-image: url(/images/register-login-background.jpg);
  padding-top: 5%;
  position: fixed;
  height: 100%;
  width: 100%;
}
#detail-container {
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