using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            stackOfStrings.Push("penko");
            stackOfStrings.Push("pe2nko");
            stackOfStrings.Push("pen4ko");

            StackOfStrings newStack = new StackOfStrings();
            newStack.Push("pen2ko");
            newStack.Push("pe23nko");
            newStack.Push("pen4k4o");

            stackOfStrings.AddRange(newStack);

            Console.WriteLine(string.Join(" ", stackOfStrings));
        }
    }
}
