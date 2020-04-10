<template>
  <div class="text-center sell-stocks-background">
    <div id="sell-stocks-container">
      <form class="form-stock">
        <h1>Sell Stock</h1>
        <table class="table table-hover table-dark text-left">
          <tbody>
            <tr>
              <td>
                Symbol: 
              </td>
              <td>
                Value in curly-braces
              </td>
            </tr>
            <tr>
              <td>
                Name: 
              </td>
              <td>
                Value in curly-braces
              </td>
            </tr>
            <tr>
              <td>
                Stock Purchase Price: 
              </td>
              <td>
                Value in curly-braces
              </td>
            </tr>
            <tr>
              <td>
                Current Share Price: 
              </td>
              <td>
                Value in curly-braces
              </td>
            </tr>
            <tr>
              <td>
                Currently Owned Shares:
              </td>
              <td>
                Value in curly-braces
              </td>
            </tr>
            <tr>
              <td>
                How many shares do you want to sell?
              </td>
              <td>
                <input
                  type="number"
                  max='10'
                  id="currently-owned-shares"
                  class="form-control"
                  placeholder="0"
                  autofocus
                />
              </td>
            </tr>
            <tr>
              <td>
                <button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Cancel</button>
              </td>
              <td><button type="button" class="btn btn-primary btn-rounded btn-sm m-0">Confirm</button>
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
  width: 25%;
}
</style>