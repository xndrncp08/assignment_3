using System;
using System;

namespace Assignment_3_skeleton
{
    public interface LinkedListADT
    {
        // Checks if the list is empty.
        // return True if it is empty.
        bool IsEmpty();

        // Clears the list.
        void Clear();

        // Adds an item to the end of the list.
        // parameter data: Object to append.
        void Append(object data);

        // Prepends (adds to beginning) an item to the list.
        // parameter data: Object to add at beginning.
        void Prepend(object data);

        // Inserts an item at a specific index in the list.
        // parameter data: Data to insert.
        // parameter index: Index at which to insert the data.
        // throws IndexOutOfRangeException if index is negative or greater than the size of the list.
        void Insert(object data, int index);

        // Replaces the item at a specific index in the list.
        // parameter data: Data to replace with.
        // parameter index: Index of the item to replace.
        // throws IndexOutOfRangeException if index is negative or not a valid index.
        void Replace(object data, int index);

        // Returns the number of elements in the list.
        // return: Size of the list (0 if empty).
        int Size();

        // Removes an item at a specific index in the list, reducing the size.
        // parameter index: Index of the item to remove.
        // throws IndexOutOfRangeException if index is negative or invalid.
        void Delete(int index);

        // Retrieves the item at a specific index in the list.
        // parameter index: Index of the item to retrieve.
        // return: Data at the specified index.
        // throws IndexOutOfRangeException if index is negative or invalid.
        object Retrieve(int index);

        // Returns the first index of the specified item.
        // parameter data: Data object to find.
        // return: Index of the first occurrence of the item, or -1 if not found.
        int IndexOf(object data);

        // Checks if the list contains the specified item.
        // parameter data: Data object to search for.
        // return: True if the item exists in the list.
        bool Contains(object data);

        // Additional functionalities

        // Removes the first item from the list.
        // throws IndexOutOfRangeException if the list is empty.
        void RemoveFirst();

        // Removes the last item from the list.
        // throws IndexOutOfRangeException if the list is empty.
        void RemoveLast();

        // Reverses the order of the nodes in the list.
        void Reverse();

        // Sorts the list in ascending order.
        // If the items are User objects, sort by the Name property; otherwise, sort by ToString().
        void Sort();

        // Copies the values of the list nodes into an array.
        // return: An array containing all node values.
        object[] ToArray();

        // Joins another linked list to the end of this list.
        // parameter otherList: The linked list to join.
        void Join(LinkedListADT otherList);

        // Divides the list into two lists at the specified index.
        // parameter index: The index at which to divide the list.
        // return: A Tuple containing the first and second halves of the list.
        Tuple<LinkedListADT, LinkedListADT> Divide(int index);
    }
}
