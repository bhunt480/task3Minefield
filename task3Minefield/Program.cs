using System;

public class Minefield
{
    private readonly int n;
    private readonly int m;
    private readonly bool[,] bombs;
    private readonly int[,] currentPosition;

    public Minefield(int n, int m)
    {
        this.n = n;
        this.m = m;
        this.bombs = new bool[n, m];
        this.currentPosition = new int[2, 2];
    }

    public void AddBomb(int x, int y)
    {
        bombs[x, y] = true;
    }

    public void ClearBomb(int x, int y)
    {
        bombs[x, y] = false;
    }

    public bool IsSafe(int x, int y)
    {
        return !bombs[x, y];
    }

    public void MoveToSafestPosition()
    {
        int x = currentPosition[0, 0];
        int y = currentPosition[0, 1];
        int bestX = x;
        int bestY = y;
        bool foundSafePosition = false;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }
                int newX = x + i;
                int newY = y + j;
                if (newX >= 0 && newX < n && newY >= 0 && newY < m)
                {
                    if (IsSafe(newX, newY))
                    {
                        bestX = newX;
                        bestY = newY;
                        foundSafePosition = true;
                        break;
                    }
                }
            }
            if (foundSafePosition)
            {
                break;
            }
        }
        currentPosition[0, 0] = bestX;
        currentPosition[0, 1] = bestY;
        currentPosition[1, 0] = bestX;
        currentPosition[1, 1] = bestY;
    }

    public bool HasReachedEnd()
    {
        return currentPosition[0, 0] == n - 1 && currentPosition[0, 1] == m - 1;
    }

    public static void Main(string[] args)
    {
        int n = 10;
        int m = 10;
        Minefield minefield = new Minefield(n, m);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                minefield.AddBomb(i, j);
            }
        }
        while (!minefield.HasReachedEnd())
        {
            minefield.MoveToSafestPosition();
        }
        Console.WriteLine("Totoshka and Ally have successfully passed through the minefield!");
    }
}
