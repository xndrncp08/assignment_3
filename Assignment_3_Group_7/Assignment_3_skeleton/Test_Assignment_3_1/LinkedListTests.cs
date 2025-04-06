using Assignment_3_skeleton;
using NUnit.Framework;
using ProblemDomain;

namespace Test_Assignment_3
{
    public class LinkedListTests
    {
        private LinkedListADT linkedList;

        [SetUp]
        public void Setup()
        {
            linkedList = new SLL();
        }

        [TearDown]
        public void TearDown()
        {
            linkedList.Clear();
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.True(linkedList.IsEmpty());
            Assert.AreEqual(0, linkedList.Size());
        }

        [Test]
        public void TestAppendNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            Assert.False(linkedList.IsEmpty());
            Assert.AreEqual(4, linkedList.Size());
            Assert.AreEqual("a", linkedList.Retrieve(0));
            Assert.AreEqual("b", linkedList.Retrieve(1));
            Assert.AreEqual("c", linkedList.Retrieve(2));
            Assert.AreEqual("d", linkedList.Retrieve(3));
        }

        [Test]
        public void TestPrependNodes()
        {
            linkedList.Prepend("a");
            linkedList.Prepend("b");
            linkedList.Prepend("c");
            linkedList.Prepend("d");

            // Expected order: d -> c -> b -> a
            Assert.False(linkedList.IsEmpty());
            Assert.AreEqual(4, linkedList.Size());
            Assert.AreEqual("d", linkedList.Retrieve(0));
            Assert.AreEqual("c", linkedList.Retrieve(1));
            Assert.AreEqual("b", linkedList.Retrieve(2));
            Assert.AreEqual("a", linkedList.Retrieve(3));
        }

        [Test]
        public void TestInsertNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            linkedList.Insert("e", 2);

            // Expected: a -> b -> e -> c -> d
            Assert.False(linkedList.IsEmpty());
            Assert.AreEqual(5, linkedList.Size());
            Assert.AreEqual("a", linkedList.Retrieve(0));
            Assert.AreEqual("b", linkedList.Retrieve(1));
            Assert.AreEqual("e", linkedList.Retrieve(2));
            Assert.AreEqual("c", linkedList.Retrieve(3));
            Assert.AreEqual("d", linkedList.Retrieve(4));
        }

        [Test]
        public void TestReplaceNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            linkedList.Replace("e", 2);

            // Expected: a -> b -> e -> d
            Assert.False(linkedList.IsEmpty());
            Assert.AreEqual(4, linkedList.Size());
            Assert.AreEqual("a", linkedList.Retrieve(0));
            Assert.AreEqual("b", linkedList.Retrieve(1));
            Assert.AreEqual("e", linkedList.Retrieve(2));
            Assert.AreEqual("d", linkedList.Retrieve(3));
        }

        [Test]
        public void TestDeleteNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            linkedList.Delete(2); // Remove "c"

            // Expected: a -> b -> d
            Assert.False(linkedList.IsEmpty());
            Assert.AreEqual(3, linkedList.Size());
            Assert.AreEqual("a", linkedList.Retrieve(0));
            Assert.AreEqual("b", linkedList.Retrieve(1));
            Assert.AreEqual("d", linkedList.Retrieve(2));
        }

        [Test]
        public void TestRemoveFirst()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");

            linkedList.RemoveFirst();

            // Expected: b -> c
            Assert.AreEqual(2, linkedList.Size());
            Assert.AreEqual("b", linkedList.Retrieve(0));
            Assert.AreEqual("c", linkedList.Retrieve(1));
        }

        [Test]
        public void TestRemoveLast()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");

            linkedList.RemoveLast();

            // Expected: a -> b
            Assert.AreEqual(2, linkedList.Size());
            Assert.AreEqual("a", linkedList.Retrieve(0));
            Assert.AreEqual("b", linkedList.Retrieve(1));
        }

        [Test]
        public void TestFindNode()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            Assert.True(linkedList.Contains("b"));
            Assert.AreEqual(1, linkedList.IndexOf("b"));
            Assert.AreEqual("b", linkedList.Retrieve(1));
        }

        [Test]
        public void TestReverse()
        {
            linkedList.Append("1");
            linkedList.Append("2");
            linkedList.Append("3");
            linkedList.Append("4");

            linkedList.Reverse();

            // Expected: 4 -> 3 -> 2 -> 1
            Assert.AreEqual("4", linkedList.Retrieve(0));
            Assert.AreEqual("3", linkedList.Retrieve(1));
            Assert.AreEqual("2", linkedList.Retrieve(2));
            Assert.AreEqual("1", linkedList.Retrieve(3));
        }

        [Test]
        public void TestToArray()
        {
            linkedList.Append("x");
            linkedList.Append("y");
            linkedList.Append("z");

            object[] array = linkedList.ToArray();
            Assert.AreEqual(3, array.Length);
            Assert.AreEqual("x", array[0]);
            Assert.AreEqual("y", array[1]);
            Assert.AreEqual("z", array[2]);
        }

        [Test]
        public void TestJoin()
        {
            linkedList.Append("a");
            linkedList.Append("b");

            LinkedListADT other = new SLL();
            other.Append("c");
            other.Append("d");

            linkedList.Join(other);

            // Expected: a -> b -> c -> d
            Assert.AreEqual(4, linkedList.Size());
            Assert.AreEqual("a", linkedList.Retrieve(0));
            Assert.AreEqual("b", linkedList.Retrieve(1));
            Assert.AreEqual("c", linkedList.Retrieve(2));
            Assert.AreEqual("d", linkedList.Retrieve(3));
        }

        [Test]
        public void TestDivide()
        {
            linkedList.Append("a");
            linkedList.Append("b");
            linkedList.Append("c");
            linkedList.Append("d");

            // Divide at index 2: first list should contain "a","b"; second list "c","d"
            var divided = linkedList.Divide(2);
            LinkedListADT firstHalf = divided.Item1;
            LinkedListADT secondHalf = divided.Item2;

            Assert.AreEqual(2, firstHalf.Size());
            Assert.AreEqual(2, secondHalf.Size());
            Assert.AreEqual("a", firstHalf.Retrieve(0));
            Assert.AreEqual("b", firstHalf.Retrieve(1));
            Assert.AreEqual("c", secondHalf.Retrieve(0));
            Assert.AreEqual("d", secondHalf.Retrieve(1));
        }

        [Test]
        public void TestSortUsers()
        {
            LinkedListADT userList = new SLL();
            userList.Append(new User(2, "Bob", "bob@example.com", "pass"));
            userList.Append(new User(1, "Alice", "alice@example.com", "pass"));
            userList.Append(new User(3, "Charlie", "charlie@example.com", "pass"));

            userList.Sort();

            // Expected order: Alice, Bob, Charlie (sorted by Name)
            User first = (User)userList.Retrieve(0);
            User second = (User)userList.Retrieve(1);
            User third = (User)userList.Retrieve(2);

            Assert.AreEqual("Alice", first.Name);
            Assert.AreEqual("Bob", second.Name);
            Assert.AreEqual("Charlie", third.Name);
        }
    }
}
