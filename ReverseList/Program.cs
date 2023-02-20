using System;

namespace ReverseList //反转链表
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
            list1.next.next.val = 3;
            list1.next.next.next.val = 4;
            list1.next.next.next.next.val = 5;

            ListNode head = solution.ReverseList(list1);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.WriteLine();

            ListNode list2 = new ListNode();
            list2.next = new ListNode();
            list2.next.next = new ListNode();
            list2.next.next.next = new ListNode();
            list2.next.next.next.next = new ListNode();

            list2.val = 1;
            list2.next.val = 2;
            list2.next.next.val = 3;
            list2.next.next.next.val = 4;
            list2.next.next.next.next.val = 5;

            ListNode head2 = solution.ReverseList2(list2);

            while (head2 != null)
            {
                Console.WriteLine(head2.val);
                head2 = head2.next;
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
        public ListNode ReverseList(ListNode head) //迭代
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        public ListNode ReverseList2(ListNode head) //递归
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode newHead = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }
    }
}
/*        1 2 3 4 5
        2 1 3 4 5
      3 2 1 4 5
    4 3 2 1 5
  5 4 3 2 1          */