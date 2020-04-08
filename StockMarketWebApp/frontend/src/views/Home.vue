<template>

  <div class="text-center welcome-container">

    <div id="welcome">
    
      <h1 id="h1">Welcome to the <span class="headername">Virtual Stock Market</span>!</h1>
      
      <p class="spacer"></p>

      <h5 id="question">
        &nbsp;&nbsp;&nbsp;&nbsp; Want to practice trading, but don't want to risk your own money?
        </h5>

        <h5 id="summary">
        &nbsp;&nbsp;&nbsp;&nbsp;Play games and practice with us!
      </h5>
      <h5 id="howto">
        &nbsp;&nbsp;&nbsp;&nbsp;You can play by yourself or compete with friends.
      </h5>
    
  </div>

  </div>

</template>
<script>
export default {
  name: 'home'
}
</script>

<style scoped>
.headername {
  color: rgb(71, 104, 255);
  font-weight: bold;
  font-style: italic;
}
.welcome-container{
  /* background-color: darkgray; */
  background: linear-gradient(rgba(255,255,255,.25), rgba(255,255,255,.25)), url(/images/WallStreet.jfif) no-repeat center center fixed;
  position: fixed;
  height: 100%;
  width: 100%;
  background-size: cover;
  padding-top: 5%;
  /* padding: 200px 0px 25px 0px; */
}



#welcome{
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: #343a40;
  color: white;
  margin: auto;
  padding: 20px;
  width: 65%;
}
h1 {
  padding-bottom: 25px;
}


</style>
