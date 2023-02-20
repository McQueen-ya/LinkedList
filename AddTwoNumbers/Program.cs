using System;

namespace AddTwoNumbers //两数相加

{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            ListNode list1 = new ListNode();
            list1.next = new ListNode();
            list1.next.next = new ListNode();

            list1.val = 2;
            list1.next.val = 4;
            list1.next.next.val = 3;

            ListNode list2 = new ListNode();
            list2.next = new ListNode();
            list2.next.next = new ListNode();

            list2.val = 5;
            list2.next.val = 6;
            list2.next.next.val = 4;

            ListNode head = solution.AddTwoNumbers(list1, list2);

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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode listHead = null, node = null;
            int a = 0, b = 0, c = 0, d = 0;               //a:l1的数 b:l2的数 c:listHead的数 d:进数(超出十)

            while (l1 != null || l2 != null)
            {
                a = l1 != null ? l1.val : 0;
                b = l2 != null ? l2.val : 0;
                c = a + b + d;
                if (listHead == null)
                    listHead = node = new ListNode(c % 10);
                else
                {
                    node.next = new ListNode(c % 10);
                    node = node.next;
                }

                d = c / 10;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if (d > 0)
                node.next = new ListNode(d);

            return listHead;
        }
    }
}
