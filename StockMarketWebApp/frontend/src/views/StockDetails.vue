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
              <th scope="row">Current Price</th>
              <th scope="row">Daily Change</th>
              <th scope="row">6-Month Change</th>
              <th scope="row">6-Month Low</th>
              <th scope="row">6-Month High</th>
              <th scope="row">Previous Day Volume</th>
              <th scope="row">Average Daily Volume</th>
              <th scope="row">Yesterdays Open</th>
              <th scope="row">Yesterdays Close</th>
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
  overflow: auto;
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
  width: 75%;
}
</style>