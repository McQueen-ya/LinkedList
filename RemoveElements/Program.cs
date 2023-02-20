using System;

namespace RemoveElements //移除链表元素
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            //输入: head = [1, 2, 6, 3, 4, 5, 6], val = 6
            //输出: [1, 2, 3, 4, 5]
            ListNode list1 = new ListNode();
            list1.next = new ListNode();
            list1.next.next = new ListNode();
            list1.next.next.next = new ListNode();
            list1.next.next.next.next = new ListNode();
            list1.next.next.next.next.next = new ListNode();
            list1.next.next.next.next.next.next = new ListNode();

            list1.val = 1;
            list1.next.val = 2;
            list1.next.next.val = 6;
            list1.next.next.next.val = 3;
            list1.next.next.next.next.val = 4;
            list1.next.next.next.next.next.val = 5;
            list1.next.next.next.next.next.next.val = 6;

            ListNode head = solution.RemoveElements(list1, 6);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.WriteLine();

            //输入: head = [], val = 1
            //输出: []
            ListNode list2 = new ListNode();
            list2 = null;

            head = solution.RemoveElements(list2, 1);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.WriteLine();

            //输入: head = [7, 7, 7, 7], val = 7
            //输出: []
            ListNode list3 = new ListNode();
            list3.next = new ListNode();
            list3.next.next = new ListNode();
            list3.next.next.next = new ListNode();

            list3.val = 7;
            list3.next.val = 7;
            list3.next.next.val = 7;
            list3.next.next.next.val = 7;

            head = solution.RemoveElements(list3, 7);

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
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return head;

            while (head.val == val)
            {
                head = head.next;
                if (head == null)
                {
                    return head;
                }
            }

            ListNode pre = head;
            ListNode cur = head.next;

            while(cur != null)
            {
                if (cur.val != val)
                {
                    pre = cur;
                    cur = cur.next;
                }
                else
                {
                    pre.next = cur.next;
                    cur = pre.next;
                }
            }
            return head;
        }

        /*----------官方解法---------*/

        public ListNode RemoveElements2(ListNode head, int val) //递归
        {
            if (head == null)
                return null;

            head.next = RemoveElements2(head.next, val);
            return head.val == val ? head.next : head;
        }

        public ListNode RemoveElements3(ListNode head, int val) //迭代
        {
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode temp = dummyHead;
            while (temp.next != null)
            {
                if (temp.next.val == val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return dummyHead.next;
        }
    }
}
