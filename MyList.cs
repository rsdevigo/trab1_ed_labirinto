using System;

namespace trab1_es
{
  class MyList<T>
  {
    public int numberOfElements;
    public Node<T> head;
    public Node<T> tail;

    public MyList()
    {
      this.numberOfElements = 0;
      this.head = this.tail = null;
    }


    public void Add(T value)
    {
      Node<T> newNode = new Node<T>(value);
      if (numberOfElements == 0)
      {
        this.head = this.tail = newNode;
      }
      else
      {
        this.tail.next = newNode;
        newNode.prev = this.tail;
        this.tail = newNode;
      }
      numberOfElements++;
    }

    public void PrintList()
    {
      Node<T> current = this.head;
      while (current != null)
      {
        Console.WriteLine(current.value);
        current = current.next;
      }

    }
  }
}