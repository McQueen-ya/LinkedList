using System;
using System.Collections.Generic;

namespace HasCycle //环形链表
{
    class Program
    {
        static void Main(string[] args)
        {
            //3 2 0 -4
            ListNode listNode = new ListNode(3);
            listNode.next = new ListNode(2);
            listNode.next.next = new ListNode(0);
            listNode.next.next.next = new ListNode(-4);
            listNode.next.next.next.next = listNode.next; //尾结点指向2

            /*ListNode head = listNode;
            while (head.next != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
            Console.WriteLine(head.val);*/

            //1 2
            ListNode listNode2 = new ListNode(1);
            listNode2.next = new ListNode(2);
            listNode2.next.next = listNode2.next; //尾结点指向1

            //1
            ListNode listNode3 = new ListNode(1);

            Solution solution = new Solution();

            Console.WriteLine(solution.HasCycle(listNode));
            Console.WriteLine(solution.HasCycle(listNode2));
            Console.WriteLine(solution.HasCycle(listNode3)); 

            Console.WriteLine(solution.HasCycle2(listNode));
            Console.WriteLine(solution.HasCycle2(listNode2));
            Console.WriteLine(solution.HasCycle2(listNode3));
        }
    }

    public class ListNode //Definition for singly-linked list.
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class Solution
    {
        public bool HasCycle(ListNode head) //字典法
        {
            Dictionary<ListNode, int> listDic = new Dictionary<ListNode, int>();

            //判断传入的链表节点为空的情况
            if (head == null)
                return false;

            while (head.next != null)
            {
                if (listDic.ContainsKey(head))
                {
                    return true;
                }
                else
                {
                    listDic.Add(head, head.val);
                    head = head.next;
                }
            }
            return false;
        }

        public bool HasCycle2(ListNode head) //快慢指针法
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }

        public bool HasCycle3(ListNode head) //哈希表法
        {
            HashSet<ListNode> seen = new HashSet<ListNode>();
            while (head != null)
            {
                if (!seen.Contains(head)) seen.Add(head);
                else return true;
                head = head.next;
            }
            return false;
        }
    }
}


//笔记

//自己最先想到的是字典，但是做着做着发现了一个问题，一是空间复杂度大于不是O(1)，二是字典存储的键有用但是值是多余的
//所以字典法有内存多余的缺点，优化字典法改为用哈希集合ISet（和上一道题环形链表的HashSet基本相同）来存节点，这样就可以避免内存多余的问题
//注意在用HashSet的时候Contanins方法返回一个bool值，添加成功返回true，如果已有返回false;