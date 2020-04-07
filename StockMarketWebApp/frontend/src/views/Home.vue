<!---<template>
  <div class="home">
    <h1>Welcome to the <strong>Virtual Stock Market Game</strong>!</h1>
    <h3>Want to practice your trading skills, but don't want to risk your own money? 
      Play games to practice with us! You can play 'lone-wolf' style or compete with friends.</h3>
  </div>
</template> --->

<template>

<div class="container">
  <div class="intro text">
  <img src="/images/WallStreet.jfif" id="img-wall-street" />
   <!-- add require later. I want this to be the background image...eventually -->
    <h1>Welcome to the <strong>Virtual Stock Market!</strong></h1>
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
    margin: auto;
    padding: 7rem;
    font-size: 20px;
}

.h1 {
  padding-bottom: 10px;
}

.h2 {
  padding-bottom: 15px;
}

</style>
