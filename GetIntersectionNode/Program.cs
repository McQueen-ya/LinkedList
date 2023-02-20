using System;
using System.Collections.Generic;

namespace GetIntersectionNode
{
    class Program
    {
        static void Main(string[] args)
        {
            //4 1 8 4 5 
            ListNode list1 = new ListNode(4);
            list1.next = new ListNode(1);
            list1.next.next = new ListNode(8);
            list1.next.next.next = new ListNode(4);
            list1.next.next.next.next = new ListNode(5);

            //5 6 1 8 4 5
            ListNode list2 = new ListNode(5);
            list2.next = new ListNode(6);
            list2.next.next = new ListNode(1);
            list2.next.next.next = list1.next.next;
            list2.next.next.next.next = list1.next.next.next;
            list2.next.next.next.next.next = list1.next.next.next.next;

            Solution solution = new Solution();
            Console.WriteLine(solution.GetIntersectionNode(list1, list2).val);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            Dictionary<ListNode, int> listDic = new Dictionary<ListNode, int>();

            while (headA.next != null)
            {
                listDic.Add(headA, headA.val);
                headA = headA.next;
            }
            listDic.Add(headA, headA.val);

            while (headB.next != null)
            {
                if (listDic.ContainsKey(headB))
                {
                    return headB;
                }
                headB = headB.next;
            }
            if (listDic.ContainsKey(headB))
            {
                return headB;
            }

            return null;
        }

        public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            ISet<ListNode> visited = new HashSet<ListNode>();
            ListNode temp = headA;
            while (temp != null)
            {
                visited.Add(temp);
                temp = temp.next;
            }
            temp = headB;
            while (temp != null)
            {
                if (visited.Contains(temp))
                {
                    return temp;
                }
                temp = temp.next;
            }
            return null;
        }

        public ListNode GetIntersectionNode3(ListNode headA, ListNode headB) //双指针法
        {
            if (headA == null || headB == null)
            {
                return null;
            }
            ListNode pA = headA, pB = headB;
            while (pA != pB)
            {
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }
            return pA;
        }
    }
}
