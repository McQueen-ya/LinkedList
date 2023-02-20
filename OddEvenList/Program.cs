using System;

namespace OddEvenList //奇偶链表
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            //输入: head = [1, 2, 3, 4, 5]
            //输出: [1, 3, 5, 2, 4]
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

            ListNode head = solution.OddEvenList(list1);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.WriteLine();

            //输入: head = [2, 1, 3, 5, 6, 4, 7]
            //输出: [2, 3, 6, 7, 1, 5, 4]
            ListNode list2 = new ListNode();
            list2.next = new ListNode();
            list2.next.next = new ListNode();
            list2.next.next.next = new ListNode();
            list2.next.next.next.next = new ListNode();
            list2.next.next.next.next.next = new ListNode();
            list2.next.next.next.next.next.next = new ListNode();

            list2.val = 2;
            list2.next.val = 1;
            list2.next.next.val = 3;
            list2.next.next.next.val = 5;
            list2.next.next.next.next.val = 6;
            list2.next.next.next.next.next.val = 4;
            list2.next.next.next.next.next.next.val = 7;

            head = solution.OddEvenList(list2);

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
        public ListNode OddEvenList(ListNode head) //官方解法 分离节点后合并
        {
            if (head == null)
                return head;

            ListNode evenHead = head.next; //偶数头结点
            ListNode odd = head, even = evenHead; //两个指针   odd:奇数的 even:偶数的
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
    }
}

//笔记

//自己想了半天只有思路但是写不出来代码, 思路是对的, 就是遍历链表的过程中去拆开偶数节点的链表和奇数节点的链表
//最后将偶数节点的链表接到奇数节点链表的后面
//难点一在于循环的条件, 用偶数节点是否为空和偶数节点后面的节点是否为空来作为判断条件很巧妙
//难点二在于循坏的内部语句, 怎么用指针去遍历链表并将其奇偶数节点分开