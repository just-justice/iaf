using System;

namespace A3
{
    public class PushPopPeek : IPushPopPeek
    {
        private class Node
        {
            public int Data;
            public Node? Next;
            public Node(int data) => Data = data;
        }

        private Node? top;

        public void Push(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = top;
            top = newNode;
        }

        public int Pop()
        {
            if (top == null)
            {
                Console.WriteLine(Constant.StackEmpty);
                return -1;
            }

            int value = top.Data;
            top = top.Next;
            return value;
        }

        public int Peek()
        {
            if (top == null)
            {
                Console.WriteLine(Constant.StackEmpty);
                return -1;
            }
            return top.Data;
        }

        public bool IsEmpty() => top == null;
    }
}
