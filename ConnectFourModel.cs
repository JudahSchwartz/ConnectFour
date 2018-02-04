using System;
using System.Data;

namespace ClassWork
{
    class BoardModel
    {
        private bool?[,] _board = new bool?[6, 7];
        public BoardModel()
        {
            
        }
        /// <summary>
        /// Will check if the top piece on the stack is a winner. This method should
        /// be called after each time DropPiece is called.
        /// </summary>
        /// 
        /// <returns></returns>
        public bool CheckWinner(int row,int col)
        {
            
            if (CheckDown(row,col))
            {
                return true;
            }
            for (int i = 0; i < 4; i++)
            {
                if (CheckLeft(row, col + i))
                {
                    return true;
                }

                if (CheckDownLeft(row - i, col + i))
                {
                    return true;
                }

                if (CheckUpLeft(row + i, col + i))
                {
                    return true;
                }
            }


            return false;
        }

        public void DisplayBoard()
        {
            Console.WriteLine(" A  B  C  D  E  F  G");
            for (int i = 0; i < 6; i++)
            {
                
                for (int j = 0; j < 7; j++)
                {
                    if (_board[i, j] == null)
                    {
                        Console.Write("| |");

                    }
                    else if (_board[i, j] == false)
                    {
                        Console.Write("|O|");
                    }
                    else
                    {
                        
                            Console.Write("|X|");
                        
                    }
                }
                Console.WriteLine();
            }
        }
        private bool CheckUpLeft(int row, int col)
        {
            
            if (row < 3 || col < 3 ||row>5||col>6)
            {
                return false;
            }
            bool? me = _board[row, col];
            return _board[row - 1,col - 1] == me&& _board[row - 2, col - 2] == me
                                                && _board[row - 3, col - 3] == me;
        }
        private bool CheckDown(int row, int col)
        {
            if (row > 2)
            {
                return false;
            }
            bool? me = _board[row, col];
            return _board[row + 1, col] == me && _board[row + 2, col] == me && _board[row + 3, col] == me;
        }

        private bool CheckDownLeft(int row, int col)
        {
            if (row > 2 || col < 3 || col > 6 || row < 0)
            {
                return false;
            }
            bool? me = _board[row, col];
            return _board[row + 1, col - 1] == me && _board[row + 2, col - 2] == me
                && _board[row + 3, col - 3] == me;
        }
        private bool CheckLeft(int row, int col)
        {
            
            if (col < 3||col>6)
            {
                return false;
            }
            bool? me = _board[row, col];

            return _board[row ,col- 1] == me&& 
                   _board[row, col - 2] == me&& _board[row , col- 3] == me;

        }
        
        /// <summary>
        /// Drops the piece into the board
        /// </summary>
        /// <param name="col">The column in which to drop the piece</param>
        /// <param name="turn">which piece to drop</param>
        /// <param name="rowPlaced">the row the piece is ultimately dropped into</param>
        /// <returns>whether or not piece was dropped successfully</returns>
        public bool DropPiece(int col, bool turn, out int rowPlaced)
        {
            if (_board[0, col]!=null)//The top slot is occupied
            {
                rowPlaced = -1;
                return false;
            }

            int row = 0;
            while (row<6&&_board[row, col] == null)//Get to the top occupied spot, or spot below
            //the bottom row
            {
                row++;
            }

            row--;//to go to the unoccupied spot
            _board[row, col] = turn;//place piece
            rowPlaced = row;
            return true;
        }
    }
}