using System.ComponentModel.Design;

namespace Run
{
    class program
    {

        static void Main(string[] args)
        {
            //Initalise vairables
            string? winner = null;
            int choiceInt;
            string[] boardValues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[,] playerInfo =
            {
                {"Player 1", "X"},
                {"Player 2", "O"}
            };
            int currentPlayer = 0;
            int xCount = 0;
            int oCount = 0;

            do
            {
                Console.Clear();

                Console.WriteLine($"\r\n█▄░█ █▀█ █░█ █▀▀ █░█ ▀█▀ █▀   ▄▀█ █▄░█ █▀▄   █▀▀ █▀█ █▀█ █▀ █▀ █▀▀ █▀\r\n█░▀█ █▄█ █▄█ █▄█ █▀█ ░█░ ▄█   █▀█ █░▀█ █▄▀   █▄▄ █▀▄ █▄█ ▄█ ▄█ ██▄ ▄█");

                if (CheckWinner() == "X" || CheckWinner() == "O")
                {
                    Console.Clear();
                    Console.WriteLine($"{winner}'s Win! Congrats");
                    ShowBoard(boardValues);
                    Console.WriteLine("Press any button to play again");
                    Console.ReadLine();
                    Main(boardValues);
                    continue;
                }
                else if (CheckWinner() == "Draw")
                {
                    Console.Clear();
                    Console.WriteLine($"It was a Draw... Better luck next time!");
                    ShowBoard(boardValues);
                    Console.WriteLine("Press any button to play again");
                    Console.ReadLine();
                    Main(boardValues);
                    continue;
                }

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

                //Create playing board
                Console.WriteLine($"+-------+-------+-------+");
                Console.WriteLine($"|       |       |       |");
                Console.Write($"|   ");
                ColorChange(x[1]);
                Console.Write($"   |   ");
                ColorChange(x[2]);
                Console.Write($"   |   ");
                ColorChange(x[3]);
                Console.Write($"   |\n");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"+-------+-------+-------+");
                Console.WriteLine($"|       |       |       |");
                Console.Write($"|   ");
                ColorChange(x[4]);
                Console.Write($"   |   ");
                ColorChange(x[5]);
                Console.Write($"   |   ");
                ColorChange(x[6]);
                Console.Write($"   |\n");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"+-------+-------+-------+");
                Console.WriteLine($"|       |       |       |");
                Console.Write($"|   ");
                ColorChange(x[7]);
                Console.Write($"   |   ");
                ColorChange(x[8]);
                Console.Write($"   |   ");
                ColorChange(x[9]);
                Console.Write($"   |\n");
                Console.WriteLine($"|       |       |       |");
                Console.WriteLine($"+-------+-------+-------+");

            }



            //Get where the user wants to place peice
            void UserInput(int player)
            {
                do
                {
                    Console.WriteLine($"Please pick a number on the board to place your peice");
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
                //Checks to see if user input is equal to 0 
                if (location == 0)
                {
                    Console.WriteLine($"{playerInfo[player, 0]} please choose a number thats on the board!");
                    UserInput(player);
                }

                try
                {

               
                //Checks to see if location choose has already been chosen
                    if (boardValues[location] == "X" || boardValues[location] == "O" ){
                        Console.WriteLine($"An {boardValues[location]} has already been placed at this location. Please choose somewhere else...");
                        UserInput(player);
                    }
                    else {
                        try
                        {
                            //Trys to update the with X or O where the player has specified
                            boardValues[location] = playerInfo[currentPlayer, 1];
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine($"{ex.Message} {playerInfo[player, 0]} please choose a number in scope");
                            UserInput(player);
                        }
                        if (player == 0)
                        { 
                            currentPlayer = 1;
                        }
                        else
                        {
                            currentPlayer = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} {playerInfo[player, 0]} please choose a number in scope");
                    UserInput(player);
                }
            }

            string CheckWinner()
            {
                string[] r = boardValues;


                //Check diagonal Winner
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

                //Check vertical Winner
                if (r[1] == r[4] && r[4] == r[7])
                {
                    winner = r[1];
                    return winner;
                }
                else if (r[2] == r[5] && r[5] == r[8])
                {
                    winner = r[2];
                    return winner;
                }
                else if (r[3] == r[6] && r[6] == r[9])
                {
                    winner = r[7];
                    return winner;
                }

                //Check horizontal winner
                if (r[1] == r[5] && r[5] == r[9])
                {
                    winner = r[1];
                    return winner;
                }
                else if (r[3] == r[5] && r[5] == r[7])
                {
                    winner = r[4];
                    return winner;
                }

                int xCount = r.Count(r => r == "X");
                int oCount = r.Count(r => r == "O");

                if (xCount == 5 && oCount == 4) {

                    return "Draw";

                }
                return null;
            }

            //Displays the variables in a different color if they are user placed
            void ColorChange(string val)
            {
                if (val == "O" || val == "X") 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(val);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(val);
                }
            }

        }


    }
}