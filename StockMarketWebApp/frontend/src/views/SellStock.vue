<template>
  <div class="text-center sell-stocks-background">
    <div id="sell-stocks-container">
      <form class="form-stock">
        <h1>Sell Stock</h1>
        <table class="table table-hover table-dark text-left">
          <tbody>
            <tr>
              <td>
                <label for="symbol" class="form-controll">Symbol</label>
              </td>
            </tr>
            <tr>
              <td>
                <label for="name" class="form-controll">Name</label>
              </td>
            </tr>
            <tr>
              <td>
                <label for="stock-purchase-price" class="form-controll">Stock Purchase Price</label>
              </td>
            </tr>
            <tr>
              <td>
                <label for="current-share-price" class="form-controll">Current Share Price</label>
              </td>
            </tr>
            <tr>
              <td>
                <label for="currently-owned-shares" class="form-controll">Currently Owned Shares</label>
              </td>
            </tr>
          </tbody>
        </table>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: "sell-stock"
};
</script>

<style scoped>
.sell-stocks-background {
  background-color: darkgray;
  background-image: url(/images/Rules-Page-Background.jpg);
  padding-top: 5%;
  position: fixed;
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
  width: 60%;
}

</style>