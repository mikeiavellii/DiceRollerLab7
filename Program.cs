//ask for user to enter in number of side of die
bool getLooping = true;
Console.WriteLine("Welcome to Springsboro Casino where all we have is Dice throwing.");
Console.WriteLine("How many sides would you like each die to have? Please only enter whole numbers greater than 0.");
int dicesides = 0;
while (int.TryParse(Console.ReadLine(), out dicesides) == false)
{
  Console.WriteLine($"That is not a valid entry. \nPlease enter a whole number greater than 0.");
}

int r1 = 0;
int r2 = 0;

while (getLooping == true)
{
  if (dicesides == 6)
  {
    Console.WriteLine($"\nRolling {dicesides}-sided dice...\n\nRolling...\n\nRolling...\n");
    r1 = (DiceRoll(dicesides));
    r2 = (DiceRoll(dicesides));
    int total = r1 + r2;
    Console.WriteLine($"You rolled a {r1} and a {r2}. ({total} total)");

    string check = DiceCombos(r1, r2);
    if (check != "")
    {
      Console.WriteLine($"{DiceCombos(r1, r2)}");
    }
  }
  //if 6 was not chosen
  else
  {
    Console.WriteLine($"\nRolling {dicesides}-sided dice...\n\nRolling...\n\nRolling...\n");
    r1 = (DiceRoll(dicesides));
    r2 = (DiceRoll(dicesides));
    int total = r1 + r2;
    Console.WriteLine($"You rolled a {r1} and a {r2}. ({total} total on the {dicesides}-sided dice.");
  }
  Console.WriteLine("\nWould you like to roll again? (y/n)\n");
  //ask to restart
  while (true)
  {
    string answer = Console.ReadLine();
    
    if (answer == "y")
    {
      getLooping = true;
      break;
    }
    else if (answer == "n")
    {
      getLooping = false;
      Console.Clear();
      Console.WriteLine("Thanks for playing.");
      break;
    }
    else
    {
      Console.WriteLine("Invalid. Type either y/n.");
    }
  }
}

//Methods
//DiceRoll Method
static int DiceRoll(int dicesides)
{
  Random roll = new Random();
  return roll.Next(1, dicesides + 1);
}

static string DiceCombos(int r1, int r2)
{
  int total = r1 + r2;
  if (r1 == 1 && r2 == 1 && total == 2)
  {
    return "Snake Eyes\nCraps!";
  }
  else if ((r1 == 1 && r2 == 2 && total == 3) || (r1 == 2 && r2 == 1 && total == 3))
  {
    return "Ace Deuce\nCraps!";
  }

  else if ((r1 == 6 && r2 == 6))
  {
    return "Box Cars\nCraps!";
  }
  else if (total == 7 || total == 11)
  {
    return $"{total}. Winner!";
  }
  else
    return "";
}