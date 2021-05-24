using System;
namespace trab1_es
{
  class Vector<T> where T : IComparable<T>
  {
    public int size;
    public int initialSize;
    public int numberOfElements;
    public T[] data;
    public Vector(int size)
    {
      this.size = this.initialSize = size;
      this.data = new T[this.size];
      numberOfElements = 0;
    }

    public Vector()
    {
      this.size = this.initialSize = 10;
      this.data = new T[this.size];
      numberOfElements = 0;
    }

    public T this[int i]
    {
      get { return this.data[i]; }
      set { this.data[i] = value; }
    }

    public void Add(T value)
    {
      this.data[this.numberOfElements] = value;
      this.numberOfElements++;
      if (this.numberOfElements == this.size)
      {
        ResizeData();
      }
    }

    public void Remove(int index)
    {
      if (index > numberOfElements - 1 || index < 0)
        throw new IndexOutOfRangeException();
      for (int i = index; i < numberOfElements - 1; i++)
      {
        this.data[i] = this.data[i + 1];
      }
      numberOfElements--;
    }

    public int Search(T value)
    {
      for (int i = 0; i < this.numberOfElements; i++)
      {
        if (this.data[i].CompareTo(value) == 0)
          return i;
      }

      return -1;
    }

    private void ResizeData()
    {
      this.size += this.initialSize;
      T[] aux = new T[this.size];
      for (int i = 0; i < this.numberOfElements; i++)
      {
        aux[i] = this.data[i];
      }
      this.data = aux;
    }

    public void PrintVector()
    {
      for (int i = 0; i < numberOfElements; i++)
      {
        Console.WriteLine(this.data[i]);
      }
    }
  }
}