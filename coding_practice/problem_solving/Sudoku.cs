namespace coding_challenges
{
    public static class Sudoku
    {
        public static void Resolve(char[][] board)
        {
            Utility<char>.DisplayMatrix(board, 3, false);

            Solve(board);

            Utility<char>.DisplayMatrix(board, 3, false);
        }
        private static bool Solve(char[][] board)
        {
            Point<int> point = GetNextEmptyPoint(board);

            if (point.X == 9 && point.Y == 9)
            {
                return true;
            }

            for (int n = 1; n <= 9; n++)
            {
                if (IsAvailable(board, n, point.X, point.Y))
                {
                    board[point.Y][point.X] = (char)(n + 48);

                    if (Solve(board))
                    {
                        return true;
                    }

                    board[point.Y][point.X] = '.';
                }
            }

            return false;
        }

        private static Point<int> GetNextEmptyPoint(char[][] board)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (board[y][x] == '.')
                    {
                        return new Point<int>(x, y);
                    }
                }
            }

            return new Point<int>(9, 9);
        }

        private static bool IsAvailable(char[][] board, int n, int r, int c)
        {
            return (!IsUsedInRow(board, n, r)
                    && !IsUsedInCol(board, n, c)
                    && !IsUsedInBox(board, n, r - r % 3, c - c % 3));
        }

        private static bool IsUsedInRow(char[][] board, int n, int r)
        {
            int v = 0;

            for (int y = 0; y < board.Length; y++)
            {
                if (int.TryParse(board[y][r].ToString(), out v))
                {
                    if (n == v)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsUsedInCol(char[][] board, int n, int c)
        {
            int v = 0;

            for (int x = 0; x < board.Length; x++)
            {
                if (int.TryParse(board[c][x].ToString(), out v))
                {
                    if (n == v)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsUsedInBox(char[][] board, int n, int r, int c)
        {
            int v = 0;

            for (int y = 0; y < board.Length / 3; y++)
            {
                for (int x = 0; x < board.Length / 3; x++)
                {
                    if (int.TryParse(board[y + c][x + r].ToString(), out v))
                    {
                        if (n == v)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
