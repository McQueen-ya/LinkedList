using System;
using System.Collections.Generic;

namespace DetectCycle //环形链表II
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

            //1 2
            ListNode listNode2 = new ListNode(1);
            listNode2.next = new ListNode(2);
            listNode2.next.next = listNode2.next; //尾结点指向1

            //1
            ListNode listNode3 = new ListNode(1);

            Solution solution = new Solution();
            if (solution.DetectCycle(listNode) != null)
            {
                Console.WriteLine(solution.DetectCycle(listNode).val);
            }
            if (solution.DetectCycle(listNode2) != null)
            {
                Console.WriteLine(solution.DetectCycle(listNode2).val);
            }
            if (solution.DetectCycle(listNode3) != null)
            {
                Console.WriteLine(solution.DetectCycle(listNode3).val);
            }

            if (solution.DetectCycle2(listNode) != null)
            {
                Console.WriteLine(solution.DetectCycle(listNode).val);
            }
            if (solution.DetectCycle2(listNode2) != null)
            {
                Console.WriteLine(solution.DetectCycle(listNode2).val);
            }
            if (solution.DetectCycle2(listNode3) != null)
            {
                Console.WriteLine(solution.DetectCycle(listNode3).val);
            }
        }
    }

    public class ListNode
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
        public ListNode DetectCycle(ListNode head) //字典法
        {
            Dictionary<ListNode, int> listDic = new Dictionary<ListNode, int>();

            //判断传入的链表节点为空的情况
            if (head == null)
                return null;

            while (head.next != null)
            {
                if (listDic.ContainsKey(head))
                {
                    return head;
                }
                else
                {
                    listDic.Add(head, head.val);
                    head = head.next;
                }
            }
            return null;
        }

        public ListNode DetectCycle2(ListNode head) //快慢指针法
        {
            if (head == null)
            {
                return null;
            }
            ListNode slow = head, fast = head;
            while (fast != null)
            {
                slow = slow.next;
                if (fast.next != null)
                {
                    fast = fast.next.next;
                }
                else
                {
                    return null;
                }
                if (fast == slow)
                {
                    ListNode ptr = head;
                    while (ptr != slow)
                    {
                        ptr = ptr.next;
                        slow = slow.next;
                    }
                    return ptr;
                }
            }
            return null;
        }


        public ListNode DetectCycle3(ListNode head) //ISet集合法
        {
            ISet<ListNode> visited = new HashSet<ListNode>();
            ListNode temp = head;
            while (temp != null)
            {
                if (!visited.Add(temp))
                {
                    return temp;
                }
                temp = temp.next;
            }
            return null;
        }
    }
}

//笔记

//自己最先想到的是字典，但是做着做着发现了一个问题，一是空间复杂度大于不是O(1)，二是字典存储的键有用但是值是多余的
//所以字典法有内存多余的缺点，看了题解发现
//1、空间复杂度为一的做法涉及数学关系，用快慢指针去遍历链表的时候要找出其中的关系，利用这个关系去计算出两个指针第一次相遇的时候的节点位置
//2、优化字典法改为用哈希集合ISet（和上一道题环形链表的HashSet基本相同）来存节点，这样就可以避免内存多余的问题
//注意在用ISet的时候Add方法返回一个bool值，添加成功返回true，如果已有返回false;
