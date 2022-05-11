using System;

namespace lab_6
{
    public class Steck
    {
        public int Size;
        public int[] Array;
        public int Top;

        public Steck(int Size)
        {
            this.Size = Size;
            this.Top = 0;
            this.Array = new int[this.Size];
        }

        public bool IsFull()
        {
            return this.Top == this.Size;
        }
        public bool IsEmpty()
        {
            return this.Top == 0;
        }
        public void Push(int Element)
        {
            if (this.IsFull())
                throw new Exception();
            this.Array[this.Top++] = Element;
        }
        public int Peek()
        {
            return this.Array[this.Top - 1];
        }
        public int Pop()
        {
            return this.Array[--this.Top];
        }
    }

}
