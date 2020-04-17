# Final Capstone - Virtual Stock Market Game

Virtual Stock Market game that allows users to buy and sell stocks and track their results. Each player receives a starting balance of $100,000 for investments when they start or join a game. The game gets live stock market data every 15 minutes and has 150 stocks so you can have fun seeing how your play investments would do in the real world. It also has 6 months of historical data (updated daily) to allow you to research stocks. Players can create games and play solo or invite existing players to play or join existing games.  When the game ends the system sells all owned stocks and the user with the highest ending balance wins.

We deployed it to Azure so check it out here (be sure to register to play!): http://virtualstockmarket.azurewebsites.net/

This was my final capstone project at Tech Elevator. It was run as a 2 week agile sprint with a product owner (Tech Elevator staff), scrum master (instructor), and a 4 student development team. We had daily standups and sprint reviews. It uses Vue for the front end and ASP.NET Core MVC for the backend. We used a Trello board to manage the project:

![Trello Board](https://github.com/amygurski/Virtual-Stock-Market/blob/master/TrelloBoard.PNG)

## Requirements (User stories)
MVP:
1. Login. As a Player, I can login so that I can play.
2. Register. As a Player, I can register with the system so that I can log in and play.
3. View Games. As a Player, I can see a list of all my current games.
4. Create Game. As a Player, I can create a new game and I will assigned as the Organizer for that game. A game will have an end date when the game will finish and a name.
5. Buy a Stock. As a Player, I can buy a stock. I can specify the trade in dollars or in shares.
6. Sell a Stock. As a Player, I can sell a stock. The value of the trade will be added to my available cash immediately.
7. See Stocks. As a Player, I can see my available cash and the status of all of my current stocks.
8. Invite players to game. As an Organizer, I can invite existing Players into my game. They will be given an initial $100,000 to invest.
9. See Leaderboard. As a Player, I can see the running total of the portfolio value of all the other players in this game.
10. Game End. When the game end date is reached, the system will sell all outstanding stock balances for all the Players in the game and prevent anymore trades from happening. The winner is the Player with the most cash.

Optional:
1. See trades. As a Player, I can see all of the trades that I’ve done in the game.
2. Pay commission. As a Player, I have to pay a $19.95 commission on every trade.
3. Search for stocks. As a Player, I can search for and research stocks on the site so that I can pick a good one to buy.
