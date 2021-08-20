using System;

namespace Stack
{
   
    class Program
    {

        static void Main(string[] args)
        {

            Queue<int> stack = new Queue<int>(5, 2.345f);
            stack.EnQeueue(1);
            stack.EnQeueue(2);
            stack.EnQeueue(3);
            stack.EnQeueue(4);
            stack.EnQeueue(5);
            stack.EnQeueue(6);

            Console.WriteLine(stack.DeQueue());
            Console.WriteLine(stack.DeQueue());

        }
    }
}
