<!---<template>
  <div class="home">
    <h1>Welcome to the <strong>Virtual Stock Market Game</strong>!</h1>
    <h3>Want to practice your trading skills, but don't want to risk your own money? 
      Play games to practice with us! You can play 'lone-wolf' style or compete with friends.</h3>
  </div>
</template> --->

<template>

<div class="container" >
  <div class="intro text">
     <h1>Welcome to the <em><strong>Virtual Stock Market!</strong></em></h1>
  <img src="/images/WallStreet.jfif" id="img-wall-street" />
   <!-- add require later. I want this to be the background image...eventually -->
   
    <h2>Want to practice trading, but don't want to risk your own money?</h2>
    <h3>Play games and practice with us! You can play 'lone-wolf' style or compete with friends.</h3>
  </div>
</div>

</template>
<script>
export default {
  name: 'home'
}
</script>

<style>
.container {
    max-width: 1200px;
    margin: 0 auto;
    text-align: center;
    padding: 7rem;
    font-size: 20px;
  
}

h1 {
  padding-bottom: 30px;
}

h2 {
  padding: 15px;
}
img {
  opacity: 0.7;
}


</style>
