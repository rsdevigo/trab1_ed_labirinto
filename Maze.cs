using System;


namespace trab1_es
{
  class Maze
  {
    public int width;
    public int height;
    public Cell[,] maze;
    public Cell entrance;
    public Cell exit;
    public Maze(int row, int col)
    {
      this.width = col;
      this.height = row;
      maze = new Cell[this.height, this.width];
      this.StartMaze();
      this.BuildMaze();
      this.ChooseEntrance();
      this.ChooseExit();
    }

    private void StartMaze()
    {
      for (int i = 0; i < this.height; i++)
      {
        for (int j = 0; j < this.width; j++)
        {
          this.maze[i, j] = new Cell(i, j, 'c');
        }
      }
    }

    public void PrintMaze(Vector<Cell> path)
    {
      for (int i = 0; i < this.width + 2; i++)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("# ");
      }
      Console.ResetColor();
      Console.WriteLine("");
      for (int i = 0; i < this.height; i++)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("# ");
        Console.ResetColor();
        for (int j = 0; j < this.width; j++)
        {
          if (this.maze[i, j].value == '#')
          {
            Console.ForegroundColor = ConsoleColor.Green;
          }
          else if (this.maze[i, j].value == 'P')
          {
            Console.ForegroundColor = ConsoleColor.Cyan;
          }
          else if (this.maze[i, j].value == 'E')
          {
            Console.ForegroundColor = ConsoleColor.Magenta;
          }
          else if (path != null && path.Search(this.maze[i, j]) != -1)
          {
            Console.ForegroundColor = ConsoleColor.Yellow;
          }
          Console.Write(this.maze[i, j].value + " ");
          Console.ResetColor();
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("#");
        Console.ResetColor();
      }
      for (int i = 0; i < this.width + 2; i++)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("# ");
      }
      Console.ResetColor();
      Console.WriteLine("");
    }

    public Vector<Cell> GetNeighbors(Cell cell)
    {
      Vector<Cell> neighbors = new Vector<Cell>(4);
      int i = cell.posRow;
      int j = cell.posCol;
      if (i != 0)
        neighbors.Add(maze[i - 1, j]);

      if (j != 0)
        neighbors.Add(maze[i, j - 1]);

      if (i != this.height - 1)
        neighbors.Add(maze[i + 1, j]);

      if (j != this.width - 1)
        neighbors.Add(maze[i, j + 1]);

      return neighbors;
    }

    private void BuildMaze()
    {
      CutMaze(maze[0, 0], width, height, false);
    }

    private void CreateWall(int start, int end, int fixedIdx, bool isHorizontal)
    {
      for (int i = start; i < end; i++)
      {
        if (!isHorizontal)
          maze[i, fixedIdx].value = '#';
        else
          maze[fixedIdx, i].value = '#';
      }
    }

    private void CutMaze(Cell origin, int w, int h, bool isHorizontal)
    {
      if (w < 2 || h < 2)
        return;
      Random rnd = new Random();
      if (!isHorizontal)
      {
        if (w - 2 < 1)
          return;
        int cutLine = rnd.Next(1, w - 2);
        CreateWall(origin.posRow, origin.posRow + h, origin.posCol + cutLine, isHorizontal);
        maze[origin.posRow, origin.posCol + cutLine].value = 'c';
        CutMaze(origin, cutLine, h, !isHorizontal);
        CutMaze(maze[origin.posRow, origin.posCol + cutLine + 1], w - cutLine - 1, h, !isHorizontal);
      }
      else
      {
        if (h - 2 < 1)
          return;
        int cutLine = rnd.Next(1, h - 2);
        CreateWall(origin.posCol, origin.posCol + w, origin.posRow + cutLine, isHorizontal);
        maze[origin.posRow + cutLine, origin.posCol].value = 'c';
        CutMaze(origin, w, cutLine, !isHorizontal);
        CutMaze(maze[origin.posRow + cutLine + 1, origin.posCol], w, h - cutLine - 1, !isHorizontal);
      }
    }

    private void ChooseEntrance()
    {
      Random rnd = new Random();
      int col = rnd.Next(0, width);
      int row = rnd.Next(0, height);

      while (maze[row, col].value != 'c')
      {
        col = rnd.Next(0, width);
        row = rnd.Next(0, height);
      }

      maze[row, col].value = 'P';
      this.entrance = maze[row, col];
    }

    private void ChooseExit()
    {
      Random rnd = new Random();
      int col = rnd.Next(0, width);
      int row = rnd.Next(0, height);

      while (maze[row, col].value != 'c' && maze[row, col] != this.entrance)
      {
        col = rnd.Next(0, width);
        row = rnd.Next(0, height);
      }

      maze[row, col].value = 'E';
      this.exit = maze[row, col];
    }
  }
}