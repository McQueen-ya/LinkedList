﻿using System;

namespace Flatten //扁平化多级双向链表
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }

    public class Solution
    {
        public Node Flatten(Node head)              //官方解法
        {
            DFS(head);
            return head;
        }

        public Node DFS(Node node)
        {
            Node cur = node;
            // 记录链表的最后一个节点
            Node last = null;

            while (cur != null)
            {
                Node next = cur.next;
                //  如果有子节点，那么首先处理子节点
                if (cur.child != null)
                {
                    Node childLast = DFS(cur.child);

                    next = cur.next;
                    //  将 node 与 child 相连
                    cur.next = cur.child;
                    cur.child.prev = cur;

                    //  如果 next 不为空，就将 last 与 next 相连
                    if (next != null)
                    {
                        childLast.next = next;
                        next.prev = childLast;
                    }

                    // 将 child 置为空
                    cur.child = null;
                    last = childLast;
                }
                else
                {
                    last = cur;
                }
                cur = next;
            }
            return last;
        }
    }
}
