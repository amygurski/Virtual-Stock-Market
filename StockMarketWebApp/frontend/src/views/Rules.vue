<template>

  <div class="text-center">

    <div id="text-container">
    
      <H1 id="h1">Game Rules</H1>
      
      <p class="spacer"></p>

      <p id="rules">
        &nbsp;&nbsp;&nbsp;&nbsp;Welcome to the Virtual Stock Market! As a player, to start you must first either create a new game
        or join an existing game. Once you have created, or joined a game you will be provided with $100,000.00 of starting
        money for you to invest into any available stocks of your choice. You and your fellow
        players have the ability to buy, sell, and research stocks historical trends so that you
        can make informed choices about your investments. 
        </p>

        <p id="rules2">
        &nbsp;&nbsp;&nbsp;&nbsp;The length of the game will be determined at creation of the game session
        and players will have until the end date of the game to make as much money as possible. When the game ends
        each players remaining stocks will be sold automatically at their current market price and give
        each player their final cash totals. The player with the most money at the end, wins.
      </p>
    
    </div>

  </div>

</template>

<script>
export default {
    name: 'game-rules'
}
</script>

<style scoped>

div{
  background-color: darkgray;
  background-image: url(/images/Rules-Page-Background-2.jpg);
  padding: 8%;
}
#text-container{
  border: 2px solid black;
  border-radius: 25px;
  background-image: none;
  background-color: white;
  margin: auto;
  padding: 25px;
  width: 60%;
}

</style>