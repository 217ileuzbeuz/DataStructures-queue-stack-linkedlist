using System;

namespace Stack
{
    internal class Node<T>
    {
        internal T data;
        internal Node<T> next;
        internal Node<T> prev;
        public Node(T item)
        {
            this.data = item;
            prev = null;
            next = null;
        }
    }

    public class LinkedList<T>
    {
        internal Node<T> root;
        internal Node<T> GetLastNode()
        {
            Node<T> temp = root;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }

        internal void Show()
        {
            Node<T> temp = root;
            Console.WriteLine(temp.data);
            while (temp.next != null)
            {
                temp = temp.next;
                Console.WriteLine(temp.data);
            }
        }

        internal void InsertLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (root == null)
            {
                newNode.prev = null;
                root = newNode;
                return;
            }
            Node<T> lastNode = GetLastNode();
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }

        internal void InsertFront(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.next = root;
            newNode.prev = null;
            if (root != null)
            {
                root.prev = newNode;
            }
            root = newNode;
        }

        internal void InsertAfter(Node<T> prev_node, T data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            Node<T> newNode = new Node<T>(data);
            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }

        internal void DeleteNodebyKey(T item)
        {
            Node<T> temp = root;
            if (temp != null && temp.data.Equals(item))
            {
                root = temp.next;
                root.prev = null;
                return;
            }
            while (temp != null && !temp.data.Equals(item))
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }

    }

}
