using System;
using System.Collections.Generic;

namespace CopyRandomList
{
    class Program
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Node node = new Node(7);
            Node node1 = node.next = new Node(13);
            Node node2 = node.next.next = new Node(11);
            Node node3 = node.next.next.next = new Node(10);
            Node node4 = node.next.next.next.next = new Node(1);

            node.random = null;
            node1.random = node;
            node2.random = node4;
            node3.random = node2;
            node4.random = node;

            Node copyedList = solution.CopyRandomList(node);

            while (copyedList != null)
            {
                Console.WriteLine(copyedList.val);

                if (copyedList.random != null)
                    Console.WriteLine(copyedList.random.val);
                else
                    Console.WriteLine("null");

                copyedList = copyedList.next;
            }
        }

        public class Solution
        {
            Dictionary<Node, Node> cachedNode = new Dictionary<Node, Node>(); //官方解法

            public Node CopyRandomList(Node head)
            {
                if (head == null)
                {
                    return null;
                }
                if (!cachedNode.ContainsKey(head))
                {
                    Node headNew = new Node(head.val);
                    cachedNode.Add(head, headNew);
                    headNew.next = CopyRandomList(head.next);
                    headNew.random = CopyRandomList(head.random);
                }
                return cachedNode[head];
            }
        }
    }
}
