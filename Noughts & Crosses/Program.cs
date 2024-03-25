/*

|x|o|x|
-------



*/
using System.Net.Http.Headers;

namespace Run
{
    class program
    {

     

        static void Main(string[] args) 
        {
            //Initalise vairables
            string? winner = null;
            int choiceInt;
            string[] boardValues = {"0" ,"1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[,] playerInfo =
            {
                {"Player 1", "X"},
                {"Player 2", "O"}
            };
            int currentPlayer = 0; 
            int xCount = 0;
            int oCount = 0; 
            
            Console.WriteLine("Welcome to Noughts & Crosses");
            Thread.Sleep(1000);

            do
            {
                Console.Clear();
                if (CheckWinner() != null){
                    Console.Clear();
                    Console.WriteLine($"{winner}'s Win! Congrats");
                    ShowBoard(boardValues);
                    Console.WriteLine("Press any button to play again"); 
                    Console.ReadLine();
                    Main(boardValues);
                    continue;
                };

                Console.WriteLine($"\n{playerInfo[0, 0]} = {playerInfo[0, 1]} and {playerInfo[1, 0]} = {playerInfo[1, 1]}\n");

                ShowBoard(boardValues);
                
                
                
                if (currentPlayer == 0)
                {
                    Console.WriteLine("Player 1 your turn");
                    UserInput(currentPlayer);

                }
                else
                {
                    Console.WriteLine("Player 2 your turn");
                    UserInput(currentPlayer);
                }
                

            } while (winner == null);


            

            //Show the current board
            void ShowBoard(string[] row)
            {
                

                string[] x = row;

                Console.WriteLine($"+-------+-------+-------+");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"|   {x[1]}   |   {x[2]}   |   {x[3]}   |");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"+-------+-------+-------+");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"|   {x[4]}   |   {x[5]}   |   {x[6]}   |");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"+-------+-------+-------+");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"|   {x[7]}   |   {x[8]}   |   {x[9]}   |");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"+-------+-------+-------+");


            }

         

            //Get where the user wants to place peice
            void UserInput(int player)
            {
                do
                {
                    

                    Console.WriteLine($"{playerInfo[player, 0]} please pick a number on the board to place your peice");
                   string playerChoice = Console.ReadLine();

                    

                    if (!int.TryParse(playerChoice, out choiceInt))
                    {
                        Console.WriteLine("invalid Choice");
                    }
                    else
                    {
                        choiceInt = choiceInt;
                        
                        
                        continue;
                    }

                } while (choiceInt < 0);

                PlacePeice(choiceInt, player);

            }

            void PlacePeice(int location, int player)
            {
                try
                {
                    boardValues[location] = playerInfo[currentPlayer, 1];
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex.Message}, {playerInfo[player,0]} please choose a number in scope");
                    UserInput(player);
                }
                if (player == 0)
                {
                    xCount++;
                    currentPlayer = 1;
                }
                else
                {
                    oCount++;
                    currentPlayer = 0;
                }
            }

            string CheckWinner()
            {
                string[] r = boardValues;

                
                    //Check horozontal 
                    if (r[1] == r[2] && r[2] == r[3])
                    {
                        winner = r[1];
                        return winner;
                    }
                    else if (r[4] == r[5] && r[5] == r[6])
                    {
                        winner = r[4];
                        return winner;
                    }
                    else if (r[7] == r[8] && r[8] == r[9])
                    {
                        winner = r[7];
                        return winner;
                    }
                return null;
            }

        }


    }
}