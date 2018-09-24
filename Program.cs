using System;
using number_guess.models;

namespace number_guess
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello.  What is your name?");
      string name = Console.ReadLine();
      Console.WriteLine($"Would you like to play a game, {name} (Y/N)?");
      string response = Console.ReadLine().ToUpper();
      bool playing = false;
      if (response == "Y")
      {
        playing = true;
      }
      //initiate a new game unless the player chooses not to
      while (playing)
      {
        //initialize the game
        Game game = new Game();
        bool won = false;
        Console.WriteLine("I am thinking of an integer between 0 and 100.  Please make a guess and hit enter.");

        //repeat until the game is won
        while (!won)
        {
          string input = Console.ReadLine();
          int guess;
          bool valid = Int32.TryParse(input, out guess);
          if (!valid)
          {
            Console.WriteLine("Invalid guess. Please choose a whole number between 0 and 100");
            continue;
          }
          int result = game.Play(guess);
          switch (result)
          {
            case -1://guess was too high
              Console.WriteLine("My number is lower.  Please guess again.");
              break;
            case 1://guess was too low
              Console.WriteLine("My number is higher.  Please guess again.");
              break;
            default://that was the number
              won = true;
              break;
          }
        }

        //once the correct selection is made
        Console.WriteLine($"That's it!  You guessed my number in {game.Guesses} moves.");
        Console.WriteLine("Would you like to play again (Y/N)?");
        response = Console.ReadLine().ToUpper();
        if (response != "Y")
        {
          playing = false;
        }
      }
      //end game
      Console.WriteLine($"Thanks for playing, {name}.  Have a great day!");
    }
  }
}
