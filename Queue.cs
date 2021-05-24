using System;

namespace trab1_es
{
  class Queue<T> : MyList<T>
  {
    public void Push(T value)
    {
      base.Add(value);
    }

    public Node<T> Pop()
    {
      if (this.numberOfElements == 0)
        return null;

      Node<T> node = this.head;
      this.head = this.head.next;
      this.numberOfElements--;
      if (this.numberOfElements != 0)
      {
        this.head.prev = null;
      }
      return node;
    }
  }
}