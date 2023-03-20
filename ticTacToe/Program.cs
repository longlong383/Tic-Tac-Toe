using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticTacToe
{
    internal class Program
    {
        /*PLAN:
        First section:
        Create visual layout for tic tac toe box
        Second Section:
        Create lists for positions in the tic tac toe box
        Third Section:
        Create code based on user Input
        -Coordinate entry
        -Invalid entries by user
        -Restart and Quit options
        Fourth Section:
        Create different code for different situations:
        -For how users can win
            -Horizontal Row
            -Vertical Row
            -Diagonal Row
        -For situation if nobody wins
        Reference codes for color:
        Console.BackgroundColor = ConsoleColor.Gray;

        Console.ForegroundColor = ConsoleColor.White;
         */


        //creation of positions on gameboard 
        static List<string> row(string letter)
        {
            //creates new list to be added to gameboard locations
            List <string> list = new List<string>();
            for (int i = 1; i <= 3; i++)
            {
                list.Add(letter + $"{i}");
            }
            return list;
        }
        //visual display for game
        static void layout(List <List<string>> m)
        {
            string[] row1 = { "A", "B", "C" };
            string[] column = { "1", "2", "3" };
            //set colors so that they're more visible
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
            //creating top part of tic tac toe box
            for (int i = 0; i < column.Length; i++)
            {
                Console.Write("   ");
                Console.Write(column[i]);
            }
            Console.Write("  ");
            //creating every row after the first row of the tic tac toe box
            for (int i = 0; i < row1.Length; i++)
            {
                //first writing down row letter
                Console.WriteLine();
                Console.Write(" ");
                Console.Write(row1[i]);
                Console.Write(" ");

                //then writing open boxes for where x and o's will go
                for (int j = 0; j < column.Length; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (m[i][j] == "X "|| m[i][j] == "O ")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(" " + m[i][j]);
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("\n               ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        //used to check and verify that the user's input is valid for a position
        static string locationChecker(List <List<string>> n, string m, int p)
        {

            int z = 0;
            
            //goes into the list
            for (int i = 0; i < 3; i++)
            {
                if (m == "Restart"|| m == "Quit")
                { 
                    return m;
                }
                //verifies that the userInput is not "X " or "O "
                while (true)
                {
                    if (m == "X " || m == "O ")
                    {
                        Console.WriteLine("Please input a valid coordinate");
                        m = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                //goes into the specific item in a list2
                for (int y = 0; y < 3; y++)
                {
                   
                    //verifies if the user coordiante is the same as the coordinate in the gameboard
                    if (n[i][y] == m)
                    {
                        //replaces coordinate with X or O from user one or two
                        if (p == 1)
                        {
                            n[i][y] = "X ";
                        }
                        else 
                        {
                            n[i][y] = "O ";
                        }
                        //breaks out of first loop
                        z = 1;
                        break;
                    }
                }
                //if the user coordinate input is valid, then z is now one, and it can break out
                if (z == 1)
                {
                    break;
                }
                //if user input isn't valid
                if (i == 2)
                {
                    Console.WriteLine("Please input a valid coordinate");
                    m = Console.ReadLine();
                    i = -1;
                }
                
            }
            m = " ";
            return m;


        }
        static string endGame(string m)
        {
            //code that runs once one of the win options has been acheived
            Console.WriteLine("\nEnter 'Quit' if you would like to quit, and Enter 'Restart' if you would like to restart");
            while (true)
            {
                m = Console.ReadLine();
                if (m == "Restart" || m == "Quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid menu option");
                }
            }
            return m;
        }
        static string winChecker(List<List<string>> m, int i)
        {
            //place holders
            string n = " ";
            string end = " ";

            int quit = 0;
            //counters used to count how many times a user gets X or O across a column, row or diagonal
            int counter1 = 0, counter2 = 0;
            //somebody gets all three across a horizontoal row
            for (int p = 0; p < 3; p++)
            {
                //goes into the specific item in a list
                for (int y = 0; y < 3; y++)
                {
                    //verifies if the user coordiante is the same as the coordinate in the gameboard
                    if (m[p][y] == "X ")
                    {
                        counter1++;
                    }
                    else if (m[p][y] == "O ")
                    {
                        counter2++;
                    }
                    //if player one gets all 3 across a row
                    if (counter1 == 3)
                    {
                        Console.WriteLine("\nPlayer 1 wins!");
                        end = endGame(n);
                        quit++;
                        break;
                    }
                    //if player two gets all 3 across a row
                    if (counter2 == 3)
                    {
                        Console.WriteLine("\nPlayer 2 wins!");
                        end = endGame(n);
                        quit++;
                        break;
                    }
                }
                if (quit == 1)
                {
                    return end;
                }
                counter1 = 0;
                counter2 = 0;

            }


            //if someone gets all three vertically
            for (int x = 0; x < 3; x++)
            {
                //goes into the specific item in a list
                for (int a = 0; a < 3; a++)
                {

                    //verifies if the user coordiante is the same as the coordinate in the gameboard
                    
                    if (m[a][x] == "X ")
                    {
                        counter1++;
                    }
                    else if (m[a][x] == "O ")
                    {
                        counter2++;
                    }
                    //if player one gets all 3 across a column
                    if (counter1 == 3)
                    {
                        Console.WriteLine("\nPlayer 1 wins!");
                        end = endGame(n);
                        quit++;
                        break;
                    }
                    //if player two gets all 3 across a column
                    if (counter2 == 3)
                    {
                        Console.WriteLine("\nPlayer 2 wins!");
                        end = endGame(n);
                        quit++;
                        break;
                    }
                }

                if (quit == 1)
                {
                    return end;
                }
                counter1 = 0;
                counter2 = 0;

            }
            //if there's a diagonal
            for (int y = 0; y < 3; y++)
            {
                if (m[y][y] == "X ")
                {
                    counter1++;
                }
                if (m[y][y] == "O ")
                {
                    counter2++;
                }
                //player one gets 3 across diagonal
                if (counter1 == 3)
                {
                    Console.WriteLine("\nPlayer 1 wins!");
                    end = endGame(n);
                    return end;
                }
                //player two gets 3 across diagonal
                if (counter2 == 3)
                {
                    Console.WriteLine("\nPlayer 2 wins!");
                    end = endGame(n);
                    return end;
                }
            }
            counter1 = 0;
            counter2 = 0;
            int b = 2;
            //check other diagonal
            for (int y = 0; y < 3; y++)
            {
                if (m[y][b] == "X ")
                {
                    counter1++;
                }
                if (m[y][b] == "O ")
                {
                    counter2++;
                }
                if (counter1 == 3)
                {
                    Console.WriteLine("\nPlayer 1 wins!");
                    end = endGame(n);
                    return end;
                }
                if (counter2 == 3)
                {
                    Console.WriteLine("\nPlayer 2 wins!");
                    end = endGame(n);
                    return end;
                }
                b--;
            }
            //if nobody wins
            if (i == 9)
            {
                Console.WriteLine("\nNobody Wins!");
                end = endGame(n);
            }
            return end;

        }

        static void Main(string[] args)
        {
            //locations on gameboard
            List<List<string>> locations = new List<List<string>>();
            string[] row1 = { "A", "B", "C" };
            //used to determine which player is playing
            int who;

            int quit = 0;

            while (true)
            {
                int turns = 0;
                for (int i = 0; i < row1.Length; i++)
                {
                    locations.Add(row(row1[i]));
                }
                layout(locations);
                Console.WriteLine("\nWelcome to TicTacToe!");
                Console.WriteLine("Player one will be 'X', and Player 2 will be 'O'");
                Console.WriteLine("When entering coordinates, enter the row (i.e. the letter on the left) in capital first," +
                    "\nthen the column (i.e. the number on the top) without seperating them by spaces (ex. A1)");
                
                while (true)
                {
                    Console.WriteLine("\nEnter 'Quit' if you would like to quit, and Enter 'Restart' at any time if you would like to restart");
                    Console.WriteLine("\nPlayer one input coordinates:");
                    string n = Console.ReadLine();
                    //know which player is playing
                    who = 1;
                    //ensure valid coordinate
                    n = locationChecker(locations, n, who);
                    //check to see if they've entered menu options
                    if (n == "Restart")
                    {
                        Console.Clear();
                        locations.Clear();
                        break;
                    }
                    else if (n == "Quit")
                    {
                        quit++;
                        break;
                    }
                    turns++;
                    Console.Clear();
                    //prints visual display
                    layout(locations);
                    //check to see if user won a game
                    n = winChecker(locations, turns);
                    //execute menu options if a game is finished
                    if (n == "Restart")
                    {
                        Console.Clear();
                        locations.Clear();
                        break;
                    }
                    else if (n == "Quit")
                    {
                        //quit is enabled
                        quit++;
                        break;
                    }
                    //same code but with player 2
                    Console.WriteLine("\nEnter 'Quit' if you would like to quit, and Enter 'Restart' at any time if you would like to restart");
                    Console.WriteLine("\nPlayer two input coordinates:");
                    n = Console.ReadLine();
                    who = 2;
                    n = locationChecker(locations, n, who);
                    if (n == "Restart")
                    {
                        Console.Clear();
                        locations.Clear();
                        break;
                    }
                    else if (n == "Quit")
                    {
                        quit++;
                        break;
                    }
                    turns++;
                    Console.Clear();
                    layout(locations);
                    n = winChecker(locations, turns);
                    if (n == "Restart")
                    {
                        Console.Clear();
                        locations.Clear();
                        break;
                    }
                    else if (n == "Quit")
                    {
                        quit++;
                        break;
                    }

                }
                //if quit is enabled, it will break and go to endCode
                if (quit == 1)
                {
                    break;
                }
                
            }

            //end Code
            Console.Clear();
            Console.WriteLine("Have a nice day");


            Console.ReadKey();
            
        }
    }
}

