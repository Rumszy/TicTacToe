using System;

namespace TicTacToe
{
    class Program
    {
        //Declare a two dimensional matrix to store the 9 values.
        public static string[,] matrix = new string[3, 3];
        static void Main(string[] args)
        {
            //Initialize Players with InitializePlayer()
            Player playerOne = InitializePlayer();
            Player playerTwo = InitializePlayer();
            
            //Initialize matrix values with InitializeTable()
            InitializeTable();

            //Start the game with StartGame()
            StartGame(playerOne, playerTwo);
        }

        /// <summary>
        /// Sets the matrix values from 1 to 9.
        /// </summary>
        public static void InitializeTable()
        {
            int initializer = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = initializer.ToString();
                    initializer++;
                }
            }
            UpdateTable();
        }
        /// <summary>
        /// Sets player name to the value which the user entered.
        /// </summary>
        /// <returns>Returns the Player object.</returns>
        public static Player InitializePlayer()
        {
            Player playerOne = new Player();
            Console.Write("Please enter your name: ");
            playerOne.Name = Console.ReadLine();

            Console.WriteLine($"Welcome {playerOne.Name}.");

            return playerOne;
        }
        /// <summary>
        /// Checks if the game has come to an end, either with winning or lack of turns.
        /// </summary>
        /// <param name="playerOne">First user.</param>
        /// <param name="playerTwo">Second user.</param>
        public static void CheckStatus(Player playerOne, Player playerTwo)
        {
            string anotherGame = null;
            if ((matrix[0, 0] == matrix[0, 1] && matrix[0, 0] == matrix[0, 2] && matrix[0, 0] == "X")       ||//1st row
                    (matrix[1, 0] == matrix[1, 1] && matrix[1, 0] == matrix[1, 2] && matrix[1, 0] == "X")   ||//2nd row
                    (matrix[2, 0] == matrix[2, 1] && matrix[2, 0] == matrix[2, 2] && matrix[2, 0] == "X")   ||//3rd row
                    (matrix[0, 0] == matrix[1, 0] && matrix[0, 0] == matrix[2, 0] && matrix[0, 0] == "X")   ||//1st column
                    (matrix[0, 1] == matrix[1, 1] && matrix[0, 1] == matrix[2, 1] && matrix[0, 1] == "X")   ||//2nd column
                    (matrix[0, 2] == matrix[1, 2] && matrix[0, 2] == matrix[2, 2] && matrix[0, 2] == "X")   ||//3rd column
                    (matrix[0, 0] == matrix[1, 1] && matrix[0, 0] == matrix[2, 2] && matrix[0, 0] == "X")   ||//diagonal
                    (matrix[0, 2] == matrix[1, 1] && matrix[0, 2] == matrix[2, 0] && matrix[0, 2] == "X"))    //reverse diagonal
            {
                playerOne.Score++;
                Console.Clear();
                UpdateTable();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The winner is: {playerOne.Name}.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"The current score is: {playerOne.Name} {playerOne.Score} - {playerTwo.Score} {playerTwo.Name}");
                Console.Write("Do you want to play another game (y/n)? ");
                anotherGame = Console.ReadLine();

                if (anotherGame.Equals("y")) StartGame(playerOne, playerTwo);
                else Environment.Exit(0);
            }
            else if ((matrix[0, 0] == matrix[0, 1] && matrix[0, 0] == matrix[0, 2] && matrix[0, 0] == "O")  ||//1st row
                    (matrix[1, 0] == matrix[1, 1] && matrix[1, 0] == matrix[1, 2] && matrix[1, 0] == "O")   ||//2nd row
                    (matrix[2, 0] == matrix[2, 1] && matrix[2, 0] == matrix[2, 2] && matrix[2, 0] == "O")   ||//3rd row
                    (matrix[0, 0] == matrix[1, 0] && matrix[0, 0] == matrix[2, 0] && matrix[0, 0] == "O")   ||//1st column
                    (matrix[0, 1] == matrix[1, 1] && matrix[0, 1] == matrix[2, 1] && matrix[0, 1] == "O")   ||//2nd column
                    (matrix[0, 2] == matrix[1, 2] && matrix[0, 2] == matrix[2, 2] && matrix[0, 2] == "O")   ||//3rd column
                    (matrix[0, 0] == matrix[1, 1] && matrix[0, 0] == matrix[2, 2] && matrix[0, 0] == "O")   ||//diagonal
                    (matrix[0, 2] == matrix[1, 1] && matrix[0, 2] == matrix[2, 0] && matrix[0, 2] == "O"))    //reverse diagonal)
            {
                playerTwo.Score++;
                Console.Clear();
                UpdateTable();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The winner is: {playerTwo.Name}.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"The current score is: {playerOne.Name} {playerOne.Score} - {playerTwo.Score} {playerTwo.Name}");
                Console.Write("Do you want to play another game (y/n)? ");
                anotherGame = Console.ReadLine();

                if (anotherGame.Equals("y")) StartGame(playerOne, playerTwo);
                else Environment.Exit(0);
            }

            int counterForGameEnd = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "X" || matrix[i, j] == "O") counterForGameEnd++;
                }
            }

            if (counterForGameEnd == 9) StartGame(playerOne, playerTwo);
        }
        /// <summary>
        /// Updates the matrix and draws it to the console.
        /// </summary>
        public static void UpdateTable()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {matrix[0, 0]}  |  {matrix[0, 1]}  |  {matrix[0, 2]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {matrix[1, 0]}  |  {matrix[1, 1]}  |  {matrix[1, 2]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {matrix[2, 0]}  |  {matrix[2, 1]}  |  {matrix[2, 2]}  ");
            Console.WriteLine("     |     |     ");   
        }
        /// <summary>
        /// Controls the turns and updates the matrix.
        /// </summary>
        /// <param name="playerOne">First user.</param>
        /// <param name="playerTwo">Second user.</param>
        public static void StartGame(Player playerOne, Player playerTwo)
        {
            int currentChoice, counter = 1;
            bool inputIsParsable;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            InitializeTable();

            do
            {
                if (counter % 2 == 1)
                {
                    Console.Write($"(X) {playerOne.Name}'s choice is: ");
                    inputIsParsable = int.TryParse(Console.ReadLine(), out currentChoice);
                    if (inputIsParsable && currentChoice > 0 && currentChoice < 10)
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i, j].Equals(currentChoice.ToString()))
                                {
                                    counter++;
                                    matrix[i, j] = "X";
                                    CheckStatus(playerOne, playerTwo);
                                    Console.Clear();
                                    UpdateTable();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, please type in a number between 1 and 9.");
                        continue;
                    }
                }
                else
                {
                    Console.Write($"(O) {playerTwo.Name}'s choice is: ");
                    inputIsParsable = int.TryParse(Console.ReadLine(), out currentChoice);
                    if (inputIsParsable && currentChoice > 0 && currentChoice < 10)
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i, j].Equals(currentChoice.ToString()))
                                {
                                    counter++;
                                    matrix[i, j] = "O";
                                    CheckStatus(playerOne, playerTwo);
                                    Console.Clear();
                                    UpdateTable();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input, please type in a number between 1 and 9.");
                        continue;
                    }
                }

            } while (true);
        }
    }
}
