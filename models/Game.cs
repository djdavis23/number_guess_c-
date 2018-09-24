
using System;

namespace number_guess.models
{
  public class Game
  {
    private Random rand;
    private int TheNumber { get; set; }
    public int Guesses { get; private set; }

    public Game()
    {
      this.rand = new Random();
      TheNumber = rand.Next(101);
      Guesses = 0;

    }

    public int Play(int guess)
    {
      Guesses++;

      if (guess == TheNumber)
      {
        return 0;
      }
      else if (guess > TheNumber)
      {
        return -1;
      }
      else { return 1; }
    }
  }
}
