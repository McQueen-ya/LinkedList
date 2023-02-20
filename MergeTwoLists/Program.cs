using System;

namespace MergeTwoLists //合并两个有序链表
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            ListNode list1 = new ListNode();
            list1.next = new ListNode();
            list1.next.next = new ListNode();
            list1.next.next.next = new ListNode();
            list1.next.next.next.next = new ListNode();

            list1.val = 1;
            list1.next.val = 2;
            list1.next.next.val = 4;
            list1.next.next.next.val = 6;
            list1.next.next.next.next.val = 9;

            ListNode list2 = new ListNode();
            list2.next = new ListNode();
            list2.next.next = new ListNode();

            list2.val = 1;
            list2.next.val = 3;
            list2.next.next.val = 4;

            ListNode head = solution.MergeTwoLists(list1, list2);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) //迭代
        {
            ListNode newListHead = new ListNode(-1);          //头结点，用于返回
            ListNode currNode = newListHead;                  //遍历时的当前节点

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    currNode.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    currNode.next = l2;
                    l2 = l2.next;
                }
                currNode = currNode.next;                    
            }                                                 //至少有一个链表已经遍历完了

            currNode.next = l1 == null ? l2 : l1;             //不管l2有没有没遍历完的节点，直接根据l1返回它或者另外一个

            return newListHead.next;                          //返回头结点的下一个节点
        }

        public ListNode MergeTwoLists2(ListNode l1, ListNode l2) //递归
        {
            if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;
            else if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists2(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists2(l1, l2.next);
                return l2;
            }
        }
    }
}
