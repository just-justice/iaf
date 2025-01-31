using System;

namespace A3
{
    public class LinkedList : ILinkedList
    {
        private class Node
        {
            public int Data;
            public Node? Next;
            public Node(int data) => Data = data;
        }

        private Node? head;

        public void Add(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
                head = newNode;
            else
            {
                Node temp = head;
                while (temp.Next != null)
                    temp = temp.Next;
                temp.Next = newNode;
            }
        }

        public void Remove(int value)
        {
            if (head == null)
            {
                Console.WriteLine(Constant.ListEmpty);
                return;
            }

            if (head.Data == value)
                head = head.Next;
            else
            {
                Node temp = head;
                while (temp.Next != null && temp.Next.Data != value)
                    temp = temp.Next;
                if (temp.Next != null)
                    temp.Next = temp.Next.Next;
            }
        }

        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine(Constant.ListEmpty);
                return;
            }

            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.Data + " -> ");
                temp = temp.Next;
            }
            Console.WriteLine("null");
        }
    }
}
