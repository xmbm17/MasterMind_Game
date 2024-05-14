using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Mark_Martinez_MasterMind
{
    public class Mastermind
    {
        private string _level = "4";
        private int _chances;
        private List<string> _pastGuesses = new List<string>();
        private List<int> _pastScores = new List<int>();
        private string _winningCombo;
        private bool _isPlaying = true;
        private int _score = 0;

        public Mastermind() { }
        public void StartGameAsync()
        {

            while (_isPlaying == true)
            {

                Console.WriteLine("Welcome to Mastermind!\n");
                Console.WriteLine("Press 4 for easy, 5 for medium, and 6 for hard.");

                _level = Console.ReadLine();

                if (_level != "4" && _level != "5" && _level != "6")
                {
                    Console.WriteLine("Please enter 4 for easy, 5 for medium, and 6 for hard.");
                }
                else
                {

                    _winningCombo = getWinningComboAsync(_level).Result.ToString();
                    _chances = 10;

                    while (_chances > 0)
                    {
                        Console.WriteLine($"\nEnter your {_level} digit guess, you have {_chances} chances left.");

                        string userGuess = Console.ReadLine();

                        if (userGuess.Length != Convert.ToInt32(_level))
                        {
                            Console.WriteLine($"Please enter a {_level} digit combination.");
                        }
                        else
                        {
                            if (validateGuess(userGuess))
                            {
                                Console.WriteLine("Congrats, you've won, you're a MasterMind!\n");

                                break;
                            }
                            else
                            {
                                int numbersCorrect = 0;
                                int numbersInCorrectPlaces = 0;

                                _pastGuesses.Add(userGuess);

                                for (int i = 0; i < Convert.ToInt32(_level); i++)
                                {
                                    if (_winningCombo.Contains(userGuess[i]))
                                    {
                                        numbersCorrect++;
                                    }
                                    if (_winningCombo[i] == userGuess[i])
                                    {
                                        numbersInCorrectPlaces++;
                                    }
                                }
                                Console.WriteLine();

                                if (numbersCorrect == 0)
                                {
                                    Console.WriteLine("Feedback: All incorrect numbers.\n");
                                }
                                else
                                {
                                    Console.WriteLine($"Feedback: {numbersCorrect} numbers are correct and {numbersInCorrectPlaces} are in the correct places.\n");
                                }

                                Console.WriteLine("Here are your past guesses:");

                                foreach (string guess in _pastGuesses)
                                {
                                    Console.WriteLine(guess);
                                }

                                _chances--;
                            }

                        }
                    }
                    if (_chances == 0)
                    {
                        Console.WriteLine($"Sorry you're out of chances, the correct combination was : {_winningCombo}");

                    }
                    Console.WriteLine("Do you want to play again ? Press y for yes and n for no.");
                    if (Console.ReadLine().ToLower() == "n")
                    {
                        _score = _chances;
                        _pastScores.Add(_score);
                        Console.WriteLine($"Here is your score: {_score}\n");
                        Console.WriteLine("Here are your past scores: ");
                        foreach (int pastScore in _pastScores)
                        {
                            Console.Write($"{pastScore} ,");

                        }
                        Thread.Sleep(5000);
                        _isPlaying = false;
                    }
                    else
                    {
                        _score = _chances;
                        _pastScores.Add(_score);

                        Console.WriteLine($"Here is your score: {_score}\n");
                        Console.WriteLine("Here are your past scores: ");
                        foreach (int pastScore in _pastScores)
                        {
                            Console.Write($"{pastScore} ,");

                        }
                        Console.WriteLine();
                        _isPlaying = true;

                        Thread.Sleep(3000);
                    }
                    Console.Clear();
                    _pastGuesses.Clear();
                }
            }
        }



        bool validateGuess(string userGuess)
        {
            if (userGuess == _winningCombo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> getWinningComboAsync(string level)
        {
            string randomCombination = await RandomNumApiCall(level);

            randomCombination = string.Join("", randomCombination.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
            return randomCombination;
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
