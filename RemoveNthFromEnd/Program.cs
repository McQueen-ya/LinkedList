using System;

namespace RemoveNthFromEnd //删除链表的倒数第N个节点
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Solution solution = new Solution();
            solution.RemoveNthFromEnd(list1, 2);

            while (list1 != null)
            {
                Console.WriteLine(list1.val);
                list1 = list1.next;
            }

            Console.WriteLine();

            ListNode list2 = new ListNode();
            list2.next = new ListNode();
            list2.next.next = new ListNode();

            list2.val = 1;
            list2.next.val = 2;
            list2.next.next.val = 3;

            solution.RemoveNthFromEnd(list2, 1);

            while (list2 != null)
            {
                Console.WriteLine(list2.val);
                list2 = list2.next;
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
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0, head);
            int length = GetLength(head);
            ListNode cur = dummy;
            for (int i = 1; i < length - n + 1; ++i)
            {
                cur = cur.next;
            }
            cur.next = cur.next.next;
            ListNode ans = dummy.next;
            return ans;
        }

        public int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                ++length;
                head = head.next;
            }
            return length;
        }
    }
}

//笔记

//while (list1.next != null)
//{
//    Console.WriteLine(list1.val);
//    list1 = list1.next;
//}
//Console.WriteLine(list1.val);
//在循环遍历链表的是时候，是可以遍历到最后一个节点后的空节点的，会将其置为空，不会报错
//所以可以写成
//while (list1 != null)
//{
//    Console.WriteLine(list1.val);
//    list1 = list1.next;
//}

//本体主要难点在于for循环的条件，从1开始，小于length - n + 1循环
//还有就是cur.next = cur.next.next;只用写这一句，不用考虑中间节点是否指向空
