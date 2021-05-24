using System;

namespace trab1_es
{
  class Cell : IComparable<Cell>
  {
    public char value;
    public int posRow;
    public int posCol;
    public bool visited;
    public Cell parent;
    public Cell(int row, int col, char val)
    {
      this.posRow = row;
      this.posCol = col;
      this.value = val;
      this.visited = false;
      this.parent = null;
    }
    public int CompareTo(Cell value)
    {
      if (value.posRow == this.posRow && value.posCol == this.posCol)
        return 0;

      return -1;
    }
  }
}