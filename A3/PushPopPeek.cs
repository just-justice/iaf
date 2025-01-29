

// Create a stack class with Push, Pop and Peek operations
class Stack
{
    private List<int> items = new List<int>();
    private const string PopErrorMessage = "Pop from empty stack";
    private const string PeekErrorMessage = "Peek from empty stack";

    public void Push(int item)
    {
        // Adds an item to the top of the stack
        items.Add(item);
    }

    public int Pop()
    {
        // Returns the top item from the stack
        if (items.Count == 0)  // Check if the stack is empty directly
            throw new InvalidOperationException(PopErrorMessage);

        int topItem = items[^1];
        items.RemoveAt(items.Count - 1);
        return topItem;
    }

    public int Peek()
    {
        // Returns the top item without removing it
        if (items.Count == 0)  // Check if the stack is empty directly
            throw new InvalidOperationException(PeekErrorMessage);

        return items[^1];
    }

    public int Size()
    {
        // Returns the number of elements in the stack
        return items.Count;
    }

    // Example usage
    public static void Main()
    {
        Stack stack = new Stack();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine(stack.Peek());  // Output: 30
        Console.WriteLine(stack.Pop());   // Output: 30
        Console.WriteLine(stack.Size());  // Output: 2
    }
}


