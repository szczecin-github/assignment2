int xWins = 0, oWins = 0, draws = 0;
while (true)
{
    Console.WriteLine("Menu");
    Console.WriteLine("1. New Game");
    Console.WriteLine("2. About the Author");
    Console.WriteLine("3. Exit");
    try
    {
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                int result = PlayGame();
                if (result == 1) xWins++;
                else if (result == -1) oWins++;
                else draws++;
                Console.WriteLine("Score: x = " + xWins + ", o = " + oWins + ", draws = " + draws);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
                break;
            case 2:
                Console.WriteLine("About the Author: My name is Kacper, I am from Poland and I study computer science");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
                break;
            case 3:
                Console.WriteLine("Are you sure you want to quit? y/n");
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "y") return;
                Console.Clear();
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
    }
}
int PlayGame()
{
    Console.WriteLine("Welcome to Tic-Tac-Toe!");
    string[] array = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
    void GameBoard()
    {
        Console.Clear();
        Console.WriteLine(" " + array[6] + " | " + array[7] + " | " + array[8]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + array[3] + " | " + array[4] + " | " + array[5]);
        Console.WriteLine("---+---+---");
        Console.WriteLine(" " + array[0] + " | " + array[1] + " | " + array[2]);
    }
    bool CheckWin()
    {
        int[][] winCombinations = new int[][]
        {
            new int[] { 0, 1, 2 },
            new int[] { 3, 4, 5 },
            new int[] { 6, 7, 8 },
            new int[] { 0, 3, 6 },
            new int[] { 1, 4, 7 },
            new int[] { 2, 5, 8 },
            new int[] { 0, 4, 8 },
            new int[] { 2, 4, 6 }
        };

        foreach (var combination in winCombinations)
        {
            if (array[combination[0]] != " " && array[combination[0]] == array[combination[1]] && array[combination[1]] == array[combination[2]])
            {
                return true;
            }
        }
        return false;
    }
    Console.WriteLine("Choose space you want to start, please use the number pad.");
    Console.WriteLine(" 7 | 8 | 9 ");
    Console.WriteLine("---+---+---");
    Console.WriteLine(" 4 | 5 | 6 ");
    Console.WriteLine("---+---+---");
    Console.WriteLine(" 1 | 2 | 3 ");
    for (int aa = 1; aa <= 9; aa++)
    {
        try
        {
            int userinput = Convert.ToInt32(Console.ReadLine());
            if ((userinput >= 1) && (userinput <= 9))
            {
                if (array[userinput - 1] != " ")
                {
                    Console.WriteLine("Space already taken. Please choose a different space.");
                    aa--;
                }
                else
                {
                    if (aa % 2 == 0)
                    {
                        array[userinput - 1] = "x";
                        Console.WriteLine("x's move > " + userinput);
                        GameBoard();
                    }
                    else
                    {
                        array[userinput - 1] = "o";
                        Console.WriteLine("o's move > " + userinput);
                        GameBoard();
                    }
                }
                if (CheckWin())
                {
                    Console.WriteLine((aa % 2 == 0 ? "x" : "o") + " wins!");
                    return aa % 2 == 0 ? 1 : -1;
                }
                else if (aa == 9)
                {
                    Console.WriteLine("It's a draw!");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                aa--;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
            aa--;
        }
    }
    Console.WriteLine("Game Over!");
    return 0;
}
