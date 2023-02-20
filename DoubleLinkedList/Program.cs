﻿using System;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class MyLinkedList
    {
        int size; //长度(不包含头尾节点)
        ListNode head; //头结点
        ListNode tail; //尾结点

        public MyLinkedList()
        {
            size = 0;
            head = new ListNode(0);
            tail = new ListNode(0);
            head.next = tail;
            tail.prev = head;
        }

        class ListNode //双向链表
        {
            public int val;
            public ListNode prev; //前驱节点
            public ListNode next; //后继节点

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
            ListNode curr;
            if (index + 1 < size - index)
            {
                curr = head;
                for (int i = 0; i <= index; i++)
                {
                    curr = curr.next;
                }
            }
            else
            {
                curr = tail;
                for (int i = 0; i < size - index; i++)
                {
                    curr = curr.prev;
                }
            }
            return curr.val;
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
            ListNode pred, succ;
            if (index < size - index)
            {
                pred = head;
                for (int i = 0; i < index; i++)
                {
                    pred = pred.next;
                }
                succ = pred.next;
            }
            else
            {
                succ = tail;
                for (int i = 0; i < size - index; i++)
                {
                    succ = succ.prev;
                }
                pred = succ.prev;
            }
            ListNode toAdd = new ListNode(val);
            toAdd.prev = pred;
            toAdd.next = succ;
            pred.next = toAdd;
            succ.prev = toAdd;
            size++;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                return;
            }
            ListNode pred, succ;
            if (index < size - index)
            {
                pred = head;
                for (int i = 0; i < index; i++)
                {
                    pred = pred.next;
                }
                succ = pred.next.next;
            }
            else
            {
                succ = tail;
                for (int i = 0; i < size - index - 1; i++)
                {
                    succ = succ.prev;
                }
                pred = succ.prev.prev;
            }
            pred.next = succ;
            succ.prev = pred;
            size--;
        }
    }
}
