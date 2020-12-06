using System;
using System.Dynamic;

namespace Vector_Software_Alg_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Enter Sudoku size: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] random_sudoku = new int[N,N];
            int[,] valid_sudoku =
                {
                {7,8,4,1,5,9,3,2,6 },
                {5,3,9,6,7,2,8,4,1 },
                {6,1,2,4,3,8,7,5,9 },
                {9,2,8,7,1,5,4,6,3 },
                {3,5,7,8,4,6,1,9,2 },
                {4,6,1,9,2,3,5,8,7 },
                {8,7,6,3,9,4,2,1,5 },
                {2,4,3,5,6,1,9,7,8 },
                {1,9,5,2,8,7,6,3,4 }
                };
        Console.WriteLine("-----------------------");
            //filling up random_sudoku
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    random_sudoku[i, j] = rnd.Next(1, 9);   
                }
            }
            //loop for output sudoku
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{random_sudoku[i, j]} ");//change your array
                }
                Console.WriteLine("");
            }
            //function that checks if sudoku is valid  
            bool Validate(int[,] grid)
            {
                for (int i = 0; i < 9; i++)
                {
                    bool[] row = new bool[10];
                    bool[] col = new bool[10];

                    for (int j = 0; j < 9; j++)
                    {
                        if (row[grid[i, j]] & grid[i, j] > 0)
                        {
                            return false;
                        }
                        row[grid[i, j]] = true;

                        if (col[grid[j, i]] & grid[j, i] > 0)
                        {
                            return false;
                        }
                        col[grid[j, i]] = true;

                        if ((i + 3) % 3 == 0 && (j + 3) % 3 == 0)
                        {
                            bool[] sqr = new bool[10];
                            for (int m = i; m < i + 3; m++)
                            {
                                for (int n = j; n < j + 3; n++)
                                {
                                    if (sqr[grid[m, n]] & grid[m, n] > 0)
                                    {
                                        return false;
                                    }
                                    sqr[grid[m, n]] = true;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            //valid sudoku validation check
            if (Validate(valid_sudoku) == true)
            {
                Console.WriteLine("Sudoku valid!");
            }
            else
            {
                Console.WriteLine("Sudoku invalid");
            }
            //random sudoku validation check
            if (Validate(random_sudoku) == true)
            {
                Console.WriteLine("Sudoku valid!");
            }
            else
            {
                Console.WriteLine("Sudoku invalid");
            }
        }
    }
}
