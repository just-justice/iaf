using System;
using A3;

class Program
{
    static void Main()
    {
        // Linked List Test
        LinkedList list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Display();
        list.Remove(20);
        list.Display();

        // Doubly Linked List Test
        DoublyLinkedList dlist = new DoublyLinkedList();
        dlist.Add(5);
        dlist.Add(15);
        dlist.DisplayForward();
        dlist.DisplayBackward();

        // PushPopPeek (Stack) Test
        PushPopPeek stack = new PushPopPeek();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Is Stack Empty? {stack.IsEmpty()}");
    }
}
