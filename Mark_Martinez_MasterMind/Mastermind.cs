using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mark_Martinez_MasterMind
{
    public class Mastermind
    {
        string difficultyLevel;
        int chances;
        public Mastermind(string difficulty)
        {
            difficultyLevel = difficulty;
            chances = 10;
        }

        public async Task StartGame()
        {
            string[] pastGuesses = { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X" };

            string randomCombination = await RandomNumApiCall(difficultyLevel);

            randomCombination = string.Join("", randomCombination.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            Console.WriteLine(randomCombination, "here is the random combo");
            Console.WriteLine($"You will have 10 attempts to guess the {difficultyLevel} digit combination, goodluck!\n");

            while (chances > 0)
            {
                Console.WriteLine($"Enter your {difficultyLevel} guess, you have {chances} chances left");

                string userGuess = Console.ReadLine();

                if (userGuess.Length != Convert.ToInt32(difficultyLevel))
                {
                    Console.WriteLine($"Please enter a {difficultyLevel} digit combination");
                }
                else
                {

                    if (userGuess == randomCombination)
                    {
                        Console.WriteLine("Congrats, you've won, you're a MasterMind!");
                        break;
                    }
                    else
                    {
                        int numbersCorrect = 0;
                        int numbersInCorrectPlaces = 0;

                        pastGuesses[chances - 1] = userGuess;

                        for (int i = 0; i < Convert.ToInt32(difficultyLevel); i++)
                        {
                            if (randomCombination.Contains(userGuess[i]))
                            {
                                numbersCorrect++;
                            }
                            if (randomCombination[i] == userGuess[i])
                            {
                                numbersInCorrectPlaces++;
                            }
                        }
                        Console.WriteLine();

                        if (numbersCorrect == 0)
                        {
                            Console.WriteLine("All incorrect.");
                        }
                        else
                        {
                            Console.WriteLine($"{numbersCorrect} numbers are correct and {numbersInCorrectPlaces} are in the correct places.");
                        }

                        Console.WriteLine("Here are your past guesses: ");

                        foreach (string guess in pastGuesses)
                        {
                            Console.WriteLine(guess);
                        }

                        chances--;
                    }
                }
            }
            if (chances == 0)
            {
                Console.WriteLine($"Sorry you're out of chances, the correct combination was : {randomCombination}");

            }
        }


        static async Task<string> RandomNumApiCall(string difficulty)
        {
            string finalData = "";

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    string baseUrl = "https://www.random.org/integers/";

                    HttpResponseMessage response = await client.GetAsync($"{baseUrl}?num={difficulty}&min=0&max=7&col=4&base=10&format=plain&rnd=new");

                    if (response.IsSuccessStatusCode)
                    {
                        finalData = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occured : " + e.Message);
                }

            };
            return finalData;
        }

    }
}
