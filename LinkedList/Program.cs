using System;

namespace LinkedList //设计链表
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList linkedList = new MyLinkedList(); //链表从头结点后的0开始
            linkedList.AddAtHead(1);
            linkedList.AddAtTail(2);
            linkedList.AddAtIndex(2, 3);
            Console.WriteLine(linkedList.Get(0));
            Console.WriteLine(linkedList.Get(1));
            Console.WriteLine(linkedList.Get(2));
            linkedList.DeleteAtIndex(2);
        }
    }

    public class MyLinkedList
    {
        int size;
        ListNode head;

        public MyLinkedList()
        {
            size = 0;
            head = new ListNode(0);
        }

        class ListNode //单链表
        {
            public int val;
            public ListNode next;

            public ListNode(int val)
            {
                this.val = val;
            }
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                return -1;
            }
            ListNode cur = head;
            for (int i = 0; i <= index; i++)
            {
                cur = cur.next;
            }
            return cur.val;
        }

        public void AddAtHead(int val)
        {
            AddAtIndex(0, val);
        }

        public void AddAtTail(int val)
        {
            AddAtIndex(size, val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (index > size)
            {
                return;
            }
            index = Math.Max(0, index);
            ListNode pred = head;
            for (int i = 0; i < index; i++)
            {
                pred = pred.next;
            }
            ListNode toAdd = new ListNode(val);
            toAdd.next = pred.next;
            pred.next = toAdd;
            size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                return;
            }
            ListNode pred = head;
            for (int i = 0; i < index; i++)
            {
                pred = pred.next;
            }
            pred.next = pred.next.next;
            size--;
        }
    }
}
