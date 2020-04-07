<!---<template>
  <div class="home">
    <h1>Welcome to the <strong>Virtual Stock Market Game</strong>!</h1>
    <h3>Want to practice your trading skills, but don't want to risk your own money? 
      Play games to practice with us! You can play 'lone-wolf' style or compete with friends.</h3>
  </div>
</template> --->

<!---<template>

<div class="container">
  <div id="intro text">
     <h1>Welcome to the <em><strong>Virtual Stock Market!</strong></em></h1>
   <img src="/images/WallStreet.jfif" id="img-wall-street" /> 
    add require later. I want this to be the background image...eventually 
   
    <h2>Want to practice trading, but don't want to risk your own money?</h2>
    <h3>Play games and practice with us! You can play 'lone-wolf' style or compete with friends.</h3>
  </div>
</div>

</template> -->

<template>

  <div class="text-center welcome-container">

    <div id="welcome">
    
      <H1 id="h1">Welcome to the <strong>Virtual Stock Market!</strong></H1>
      
      <p class="spacer"></p>

      <h3 id="question">
        &nbsp;&nbsp;&nbsp;&nbsp; Want to practice trading, but don't want to risk your own money?
        </h3>

        <h3 id="summary">
        &nbsp;&nbsp;&nbsp;&nbsp;Play games and practice with us!
      </h3>
      <h3 id="howto">
        &nbsp;&nbsp;&nbsp;&nbsp;You can play by yourself or compete with friends.
      </h3>
    
  </div>

  </div>

</template>
<script>
export default {
  name: 'home'
}
</script>

<style scoped>
.welcome-container{
  /* background-color: darkgray; */
  background: linear-gradient(rgba(255,255,255,.25), rgba(255,255,255,.25)), url(/images/WallStreet.jfif) no-repeat center center fixed;
  position: fixed;
  height: 100%;
  width: 100%;
  background-size: cover;
  padding-top: 8%;
  /* padding: 200px 0px 25px 0px; */
}



#welcome{
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: white;
  margin: auto;
  padding: 20px;
  width: 65%;
}
h1 {
  padding-bottom: 25px;
}


</style>
