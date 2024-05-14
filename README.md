# MasterMind Game

Mastermind is a game where a computer creates a 4 digit  combination and the user has 10 tries to guess the combination. The user is also prompted with feedback such as when the user has used a correct digit in the combination and if that digit is in the correct place. Example the combination is "1536", if the user guesses "1458" then the computer would tell them "You have 2 correct numbers and 1 is in the correct place.". The user also has the ability to choose the difficulty in order to make it more exciting and difficult! 

# Thought Process
## Understaing the problem.
   I had to understand what is being asked and broke it down into 3 parts.<br/>
   a. The first part was getting a random number by implementing the api.<br/>
   b. Second compaing the random number to a user's guess.<br/>
   c. Providing feedback to help the user guess the combination.<br/>
## Planning 
   Once I broke it down, I started planning on <br/>
   a. Creating a function to make the GET call to the api<br/>
   b. Ensuring the user's input is validated and able to compare with the combination<br/>
   c. How I wanted to compare the input with the guess in order to provide feedback<br/>
   d. I also wanted to "disperse" the logic among function so not one function is doing everything.<br/>

## Problem Solving Steps
 1. I had to first get the base of the game down before implementing some extra features.<br/>
 2. Using the HTTP client in order to make that api call with the correct parameters to get that random combination .<br/>
 3. After receiving the combination, I had to grab the user's guess and check if it matched exactly with the random combination. If it guess is correct then the user is a Mastermind and the game ends. <br/>
 4. If it did not match exactly,then I had to iterate throughout the guess and see if the random combination contained any of the guess's digits. If it did then the counter for correct numbers goes up and if that digit is in the correct place then the counter for correct places goes up as well.<br/>
 5. With the counters holding information for feedback, the user is then displayed the counters value to help them with their attempts.<br/>
 6. I also had to have a way to end the game, and my solution was to have a variable that has an initial value of 10 (the user is given 10 chances) and decrement it after each attempt if the guess is incorrect.
 7. Once the base of the game worked as intended, whether the user guesses it within 10 tries or fails, I wanted to implement a way where  the user is allowed to continue playing without leaving the console application.
 8. That is where i created a while loop to hold the logic that runs the game and if the user decides to not play again, it will close the application else the user plays another round.
 9. I also wanted to implement difficulty levels, so if the user wants an easy combination, the it would be a 4 digit combo or they could choose to go to medium which would be a 5 digit combo, or hard which would be a 6 digit combo. In order to get these combinations, I had to create a variable to hold a user's input to dynamically change a parameter when making my api call.<br/>
 10. Lastly I wanted to keep track of scores if a user continues to play. I did this by creating a list that adds to the list the user's score every time they finish a game. 


# Requirements
* Visual Studio 

# Installation

clone this repo and then navigate to the repository folder on your computer and open up the .sln file to open it up in Visual Studio. Then  press the play button to run this application in your console.

```bash
git clone https://github.com/xmbm17/MasterMind_Game.git
```

# Visuals
![Screenshot 2024-05-14 171909](https://github.com/xmbm17/MasterMind_Game/assets/106717417/5e457a53-d0d9-41e9-b187-6d5c4f6e2765)
