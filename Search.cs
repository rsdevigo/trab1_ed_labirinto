using System;

namespace trab1_es
{
  class Search
  {
    //TODO: Criar o algoritmo de encontrar o caminho da saída do labirinto
    public static Vector<Cell> FindThePath(Maze maze)
    {
      return GetPathByExit(maze.exit);
    }

    private static Vector<Cell> GetPathByExit(Cell exit)
    {
      Vector<Cell> path = new Vector<Cell>();

      Cell current = exit;
      while (current != null)
      {
        path.Add(current);
        current = current.parent;
      }
      return path;
    }

    private static Vector<Cell> GetUnvisitedCells(Vector<Cell> cells)
    {
      Vector<Cell> unvisitedCells = new Vector<Cell>();
      for (int i = 0; i < cells.numberOfElements; i++)
      {
        if (!cells[i].visited)
          unvisitedCells.Add(cells[i]);
      }

      return unvisitedCells;
    }
  }
}