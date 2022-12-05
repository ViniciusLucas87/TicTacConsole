using System;

namespace TicTacToeGameConsole
{

    class Program
    {



        static void Main(string[] args)
        {


            int currentPlayer = -1;
            char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int gameStatus = 0;


            //loop this functions
            do
            {
                Console.Clear();
                currentPlayer = GetNextPlayer(currentPlayer);



                HeadsUpDisplay(currentPlayer);
                DrawGameBoard(gameMarkers);
                GameEngine(gameMarkers, currentPlayer);


                //Check after turns if theres a winner
                //No winner = keep playing and running the loop
                gameStatus = CheckWinner(gameMarkers);


            } while (gameStatus.Equals(0));

            Console.Clear();
            HeadsUpDisplay(currentPlayer);
            DrawGameBoard(gameMarkers);

            //Player win conditition
            if (gameStatus.Equals(1))

            {
                Console.WriteLine($"(|o_o|)   {0}\n{1}, Player {currentPlayer} is the winner!!  (|o_o|)  ");
                   

            }
            //Draw conditition
            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"The game is a Draw! Try Again!");
            }
        }

        private static int CheckWinner(char[] gameMarkers)
        {
            // checking if we have the winner the game must stop or restart

            if (IsGameWinner(gameMarkers))
            //winner, announce who and stop the game
            {
                return 1;
            }

            //all markers placed = draw stop game

            if (IsGameDraw(gameMarkers))
            {
                return 2;
            }
            return 0;

        }

        private static bool IsGameDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                   gameMarkers[1] != '2' &&
                   gameMarkers[2] != '3' &&
                   gameMarkers[3] != '4' &&
                   gameMarkers[4] != '5' &&
                   gameMarkers[5] != '6' &&
                   gameMarkers[6] != '7' &&
                   gameMarkers[7] != '8' &&
                   gameMarkers[8] != '9' &&
                   gameMarkers[0] != '9';


        }
        //We`re Telling the game the wins conditition when 3 gameMarkers are filled with the same value of a defined player "x" or "o" 
        private static bool IsGameWinner(char[] gameMarkers)
        {
            if (IsGameMarkerstheSame(gameMarkers, 0, 1, 2))
            {
                return true;

            }
            if (IsGameMarkerstheSame(gameMarkers, 3, 4, 5))
            {
                return true;
            }
             if (IsGameMarkerstheSame(gameMarkers, 6, 7, 8))
             {
            return true;
             }
            
                if (IsGameMarkerstheSame(gameMarkers, 0, 3, 6))
                {
                    return true;

                }
                if (IsGameMarkerstheSame(gameMarkers, 1, 4, 7))
                {
                    return true;
                }
                if (IsGameMarkerstheSame(gameMarkers, 2, 5, 8))
                {
                    return true;
                }
                      if (IsGameMarkerstheSame(gameMarkers, 0, 4, 8))
                {
                    return true;
                }
                      if (IsGameMarkerstheSame(gameMarkers, 2, 4, 6))
                {
                    return true;
                }
                return false;
        }

        private static bool IsGameMarkerstheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }
        private static void GameEngine(char[] gameMarkers, int currentPlayer)
                {

                    bool notValidMove = true;
            do 
            {
            //As the users place 0 or X the game board will be updated and notify the turns
            string userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput) && 
               (userInput.Equals("1")||
                userInput.Equals("2") ||
                userInput.Equals("3") ||
                userInput.Equals("4") ||
                userInput.Equals("4") ||
                userInput.Equals("5") ||
                userInput.Equals("6") ||
                userInput.Equals("7") ||
                userInput.Equals("8") ||
                userInput.Equals("9")))
            {    
                Console.Clear();

                int.TryParse(userInput, out var gamePlacementMarker);

                char currentMarker = gameMarkers[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('0'))
                {
                    Console.WriteLine("Placement has already a marker please try another placement");

                }
                    else
                {
                    gameMarkers[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);
                    notValidMove = false;

                 }

           }
else
{
    Console.WriteLine("Invalid value please select another placement");

}
          } while (notValidMove) ;
        }


        private static char GetPlayerMarker(int player)
{
    if (player % 2 == 0)

    {
        return '0';

    }
    return 'x';
    
        }

        
        
        static void HeadsUpDisplay(int PlayerNumber)
        {
            //1. Instructions for the play


            //Greetings
            Console.WriteLine("Welcome to Tic Tac Toe Game!!");

            //Display Player X or O --> Player 1 is X and Player 2 is 0
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: 0");
            Console.WriteLine("");

            //Who`s turn is it?

            // Instruct the user how to play the game
            Console.WriteLine($"Player {PlayerNumber} to move, Please select a number from 1 to 9 from the game board.");
            Console.WriteLine();           

        }
        static void DrawGameBoard(char[] gameMarkers)
        { 
            //Draw the game board function

            Console.WriteLine($" {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} ");
            
           }
        static int GetNextPlayer(int player)
        {
            //detect whos the next player 1 after 2 and player 2 after 1
            if (player.Equals(1))
            {
                return 2;
            }
                return 1;
            
            

        }
}
    

}