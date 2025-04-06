using System;
using Assignment_3_skeleton;
using ProblemDomain;

namespace Assignment_3_skeleton
{
    internal class Program
    {
        public static SLL list = new SLL();

        static void Main(string[] args)
        {
            Console.WriteLine("Function [PRINT]");
            list.PrintData();

            Console.WriteLine("Function [Append] 'a'");
            list.Append('a');
            list.PrintList();

            Console.WriteLine("Function [Append] 'b'");
            list.Append('b');
            list.PrintList();

            Console.WriteLine("Function [Append] 'c'");
            list.Append('c');
            list.PrintData();

            Console.WriteLine("Function [Retrieve] '0'");
            Console.WriteLine(list.Retrieve(0));

            Console.WriteLine("Function [Retrieve] '1'");
            Console.WriteLine(list.Retrieve(1));

            Console.WriteLine("Function [Retrieve] '2'");
            Console.WriteLine(list.Retrieve(2));
            list.PrintData();

            Console.WriteLine("\nFunction [Insert] 'd' at index 0");
            list.Insert('d', 0);
            list.PrintList();

            Console.WriteLine("Function [Insert] '1' at index 1");
            list.Insert('1', 1);
            list.PrintList();

            Console.WriteLine("Function [Insert] '2' at index 2");
            list.Insert('2', 2);
            list.PrintData();

            // Demonstrate additional functionalities
            Console.WriteLine("Function [RemoveFirst]");
            list.RemoveFirst();
            list.PrintList();

            Console.WriteLine("Function [RemoveLast]");
            list.RemoveLast();
            list.PrintList();

            Console.WriteLine("Function [Reverse]");
            list.Reverse();
            list.PrintList();

            Console.WriteLine("Function [ToArray]");
            object[] arr = list.ToArray();
            Console.WriteLine(string.Join(", ", arr));

            // Join demonstration
            SLL secondList = new SLL();
            secondList.Append("x");
            secondList.Append("y");
            secondList.Append("z");
            Console.WriteLine("Second list:");
            secondList.PrintList();

            Console.WriteLine("Function [Join]");
            list.Join(secondList);
            list.PrintList();

            // Sort demonstration with User objects
            Console.WriteLine("Function [Sort] with User objects:");
            SLL userList = new SLL();
            userList.Append(new User(2, "Bob", "bob@example.com", "pass"));
            userList.Append(new User(1, "Alice", "alice@example.com", "pass"));
            userList.Append(new User(3, "Charlie", "charlie@example.com", "pass"));
            Console.WriteLine("Before sort:");
            userList.PrintList();
            userList.Sort();
            Console.WriteLine("After sort:");
            userList.PrintList();

            // Divide demonstration
            Console.WriteLine("Function [Divide]");
            var divided = list.Divide(list.Size() / 2);
            Console.WriteLine("First half:");
            ((SLL)divided.Item1).PrintList();
            Console.WriteLine("Second half:");
            ((SLL)divided.Item2).PrintList();

            Console.ReadKey();
        }
    }
}
