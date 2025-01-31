namespace A3
{
    public interface IPushPopPeek
    {
        void Push(int value);
        int Pop();
        int Peek();
        bool IsEmpty();
    }
}