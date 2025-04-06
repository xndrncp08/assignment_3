using System;

namespace Assignment_3_skeleton
{
    [Serializable]
    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }

        public Node(object data)
        {
            Data = data;
            Next = null;
        }

        public Node(object data, Node next)
        {
            Data = data;
            Next = next;
        }
    }
}

