namespace Mark_Martinez_MasterMind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;
            Console.WriteLine("Welcome to Mastermind!\n");
            Console.WriteLine("Press 4 for easy, 5 for meduim, and 6 for hard");

            string difficulty = Console.ReadLine();

            while (keepPlaying)
            {
                Mastermind mastermind = new Mastermind(difficulty);
                mastermind.StartGame().GetAwaiter().GetResult();

                Console.WriteLine("Do you want to play again? Press y for yes and n for no.");

                if (Console.ReadLine().ToLower() == "n")
                {
                    keepPlaying = false;
                }
            }
        }
    }
}
