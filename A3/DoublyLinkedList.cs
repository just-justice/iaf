using System;

namespace A3
{
    public class DoublyLinkedList : IDoublyLinkedList
    {
        private class Node
        {
            public int Data;
            public Node? Next;
            public Node? Prev;
            public Node(int data) => Data = data;
        }

        private Node? head;
        private Node? tail;

        public void Add(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
                head = tail = newNode;
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        public void Remove(int value)
        {
            if (head == null)
            {
                Console.WriteLine(Constant.ListEmpty);
                return;
            }

            Node? temp = head;
            while (temp != null && temp.Data != value)
                temp = temp.Next;

            if (temp == null) return;

            if (temp.Prev != null)
                temp.Prev.Next = temp.Next;
            else
                head = temp.Next;

            if (temp.Next != null)
                temp.Next.Prev = temp.Prev;
            else
                tail = temp.Prev;
        }

        public void DisplayForward()
        {
            Node? temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " <-> ");
                temp = temp.Next;
            }
            Console.WriteLine("null");
        }

        public void DisplayBackward()
        {
            Node? temp = tail;
            while (temp != null)
            {
                Console.Write(temp.Data + " <-> ");
                temp = temp.Prev;
            }
            Console.WriteLine("null");
        }
    }
}
