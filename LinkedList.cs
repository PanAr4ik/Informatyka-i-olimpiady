namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LinkedList list = new LinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(1, 4); // List is now 1 -> 4 -> 2 -> 3
            list.RemoveAt(2);   // List is now 1 -> 4 -> 3

            Console.WriteLine(list.Get(2));
            
        }
    }

    class Node
    {
        public int Value;
        public Node Next;
        public Node(int value) => Value = value;
    }

    class LinkedList
    {
        private Node head;

        public void Add(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node current = head;
            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        public void Insert(int index, int value)
        {
            if (index < 0) throw new ArgumentOutOfRangeException();

            Node newNode = new Node(value);

            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1 && current != null; i++)
                current = current.Next;

            if (current == null) throw new ArgumentOutOfRangeException();

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || head == null) throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                head = head.Next;
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1 && current.Next != null; i++)
                current = current.Next;

            if (current.Next == null) throw new ArgumentOutOfRangeException();

            current.Next = current.Next.Next;
        }

        public int Get(int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index && current != null; i++)
                current = current.Next;

            if (current == null) throw new ArgumentOutOfRangeException();

            return current.Value;
        }


    }

   
}


