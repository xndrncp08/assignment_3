using System;
using System.Collections.Generic;
using ProblemDomain;  // Required for User in Sort

namespace Assignment_3_skeleton
{
    [Serializable]
    public class SLL : LinkedListADT
    {
        private Node head;
        private Node tail;
        private int listSize;

        // Properties (optional)
        public Node Head { get => head; set => head = value; }

        public Node Tail { get => tail; set => tail = value; }

        public int ListSize { get => listSize; set => listSize = value; }

        public SLL()
        {
            head = null;
            tail = null;
            listSize = 0;
        }

        // Basic Operations

        // Checks if the list is empty.
        // return True if it is empty.
        public bool IsEmpty()
        {
            if (head == null && tail == null)
            {
                Console.WriteLine("List is Empty.");
                return true;
            }
            return false;
        }

        // Clears the list.
        public void Clear()
        {
            head = null;
            tail = null;
            listSize = 0;
            Console.WriteLine("List cleared");
        }

        // Adds an item to the end of the list.
        // parameter data to append.
        public void Append(object data)
        {
            // If the list is empty, initialize it.
            
            if (FixListNull(data))
                return;
            // Otherwise, add new node at the end.
            
            tail.Next = new Node(data);
            
            tail = tail.Next;
            
            listSize++;
        }

        // Prepends (adds to beginning) an item to the list.
        // parameter data to store inside element.
        public void Prepend(object data)
        {
            if (FixListNull(data))
                return;
            Node new_node = new Node(data);
            new_node.Next = head;
            head = new_node;
            listSize++;
        }

        // Inserts an item at a specific index in the list.
        // parameter data: Data that element is to contain.
        // parameter targetIndex: Index to add new element at.
        // throws exception if index is negative or past the size.
        public void Insert(object data, int targetIndex)
        {
            if (targetIndex < 0 || targetIndex > listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            if (targetIndex == 0)
            {
                Prepend(data);
                return;
            }
            if (targetIndex == listSize)
            {
                Append(data);
                return;
            }
            Node current = head;
            for (int i = 0; i < targetIndex - 1; i++)
            {
                current = current.Next;
            }
            Node newNode = new Node(data, current.Next);
            current.Next = newNode;
            listSize++;
        }

        // Replaces the item at a specific index in the list.
        // parameter data: Data to replace.
        // parameter targetIndex: Index of element to replace.
        // throws exception if index is negative or invalid.
        public void Replace(object data, int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            Node current = head;
            for (int i = 0; i < targetIndex; i++)
            {
                current = current.Next;
            }
            current.Data = data;
        }

        // Returns the number of elements in the list.
        // return Size of list (0 if empty)
        public int Size()
        {
            // Optionally, print the size for debugging.
            Console.WriteLine(listSize);
            return listSize;
        }

        // Removes an item at a specific index in the list, reducing the size.
        // parameter targetIndex: Index of element to remove.
        // throws exception if index is negative or invalid.
        public void Delete(int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            if (targetIndex == 0)
            {
                RemoveFirst();
                return;
            }
            if (targetIndex == listSize - 1)
            {
                RemoveLast();
                return;
            }
            Node current = head;
            for (int i = 0; i < targetIndex - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            listSize--;
        }

        // Retrieves the item at a specific index in the list.
        // parameter targetIndex: Index of element to get.
        // return Data at element or throws exception if index invalid.
        public object Retrieve(int targetIndex)
        {
            if (targetIndex < 0 || targetIndex >= listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            Node current = head;
            for (int i = 0; i < targetIndex; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        // Returns the first index of an element that contains the specified data.
        // parameter target: Data to search for.
        // return: Index if found or -1 if not found.
        public int IndexOf(object target)
        {
            if (CheckListNull())
                return -1;
            int index = 0;
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                if (tempNode.Data != null && tempNode.Data.Equals(target))
                    return index;
                index++;
            }
            return -1;
        }

        // Checks if the list contains an element with the specified data.
        // parameter target: Data object to search for.
        // return: True if found, false otherwise.
        public bool Contains(object target)
        {
            return IndexOf(target) != -1;
        }

        // Additional Functionalities

        // Removes the first item in the list.
        public void RemoveFirst()
        {
            if (CheckListNull())
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            head = head.Next;
            listSize--;
            if (head == null)
                tail = null;
        }

        // Removes the last item in the list.
        public void RemoveLast()
        {
            if (CheckListNull())
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            if (listSize == 1)
            {
                head = tail = null;
            }
            else
            {
                Node current = head;
                while (current.Next != tail)
                    current = current.Next;
                current.Next = null;
                tail = current;
            }
            listSize--;
        }

        // Reverses the order of the nodes in the list.
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            tail = head; // Old head becomes new tail.
            while (current != null)
            {
                Node next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        // Sorts the nodes in ascending order.
        // If the data is of type User, it sorts based on the Name property.
        // Otherwise, it uses the default ToString() for comparison.
        public void Sort()
        {
            if (IsEmpty() || listSize == 1)
                return;
            bool isUser = head.Data is User;
            List<object> dataList = new List<object>();
            Node current = head;
            while (current != null)
            {
                dataList.Add(current.Data);
                current = current.Next;
            }
            if (isUser)
            {
                dataList.Sort((a, b) =>
                {
                    string nameA = ((User)a).Name;
                    string nameB = ((User)b).Name;
                    return nameA.CompareTo(nameB);
                });
            }
            else
            {
                dataList.Sort((a, b) => a.ToString().CompareTo(b.ToString()));
            }
            current = head;
            int i = 0;
            while (current != null)
            {
                current.Data = dataList[i++];
                current = current.Next;
            }
        }

        // Copies the values of the nodes into an array.
        public object[] ToArray()
        {
            object[] array = new object[listSize];
            Node current = head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }
            return array;
        }

        // Joins another linked list to this list.
        public void Join(LinkedListADT otherList)
        {
            object[] otherArray = otherList.ToArray();
            foreach (object data in otherArray)
            {
                Append(data);
            }
        }

        // Divides the list into two separate linked lists based on a specific index position.
        // Returns a Tuple where Item1 is the first half and Item2 is the second half.
        public Tuple<LinkedListADT, LinkedListADT> Divide(int index)
        {
            if (index < 0 || index > listSize)
                throw new IndexOutOfRangeException(Exceptions.IndexOutOfRangeException());
            SLL firstList = new SLL();
            SLL secondList = new SLL();
            Node current = head;
            int i = 0;
            while (current != null)
            {
                if (i < index)
                    firstList.Append(current.Data);
                else
                    secondList.Append(current.Data);
                current = current.Next;
                i++;
            }
            return Tuple.Create<LinkedListADT, LinkedListADT>(firstList, secondList);
        }

        // EXTRA HELPER METHODS (for demonstration and debugging)

        // Prints the data of all nodes in the linked list.
        public void PrintList()
        {
            if (CheckListNull())
            {
                return;
            }
            for (Node tempNode = head; tempNode != null; tempNode = tempNode.Next)
            {
                Console.Write(tempNode.Data.ToString() + "  ");
            }
            Console.WriteLine();
        }

        // Prints the list data & head and tail values
        public void PrintData()
        {
            if (CheckListNull())
                return;
            PrintList();
            Console.WriteLine("\nHEAD: " + GetHead().Data);
            Console.WriteLine("TAIL: " + GetTail().Data + "\n");
        }

        // Returns the head node if the list is not empty.
        public Node GetHead()
        {
            if (CheckListNull())
                return null;
            return head;
        }

        // Returns the tail node if the list is not empty.
        public Node GetTail()
        {
            if (CheckListNull())
                return null;
            return tail;
        }

        // Checks if the list is null (empty) and prints a message if so.
        public bool CheckListNull()
        {
            if (head == null && tail == null)
            {
                Console.WriteLine("List was NULL\n");
                return true;
            }
            return false;
        }

        // When adding a node to an empty list, this helper method initializes the list.
        public bool FixListNull(object data)
        {
            if (head == null && tail == null)
            {
                head = tail = new Node(data);

                listSize++;

                return true;
            }
            return false;
        }
    }
}
