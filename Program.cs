using System;

namespace trab1_es
{
  class Program
  {
    static void Main(string[] args)
    {
      Maze maze = new Maze(40, 40);
      Vector<Cell> path = Search.FindThePath(maze);
      maze.PrintMaze(path);
    }
  }
}
