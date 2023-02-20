using System;
using System.Collections;
using System.Collections.Generic;

namespace IsPalindrome //回文链表
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
            list1.next.next.next.val = 2;
            list1.next.next.next.next.val = 1;

            Console.WriteLine(solution.IsPalindrome(list1));
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
        public bool IsPalindrome(ListNode head)
        {
            List<int> array = new List<int>();
            while (head != null)
            {
                array.Add(head.val);
                head = head.next;
            }

            int front = 0, last = array.Count - 1;
            while (front < last)
            {
                if (array[front] != array[last])
                    return false;

                front++;
                last--;
            }

            return true;
        }
    }
}
