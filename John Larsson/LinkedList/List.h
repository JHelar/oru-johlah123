#pragma once

#include <iostream>
#include <sstream>
#include <string>

#include "Node.h"
	
/**
*       An implementation of a single-linked list without sorting.
*       
*       The class contains one pointer to a node-object named the "head" of the list and
*       one named the "tail" of the list.
*/

template < class T >
class List
{
        class Iterator
        {
        public:
                typedef Iterator self_type;
                typedef Node<T> value_type;
                typedef Node<T>& reference;
                typedef Node<T>* pointer;
                typedef std::forward_iterator_tag iterator_category;
                typedef int difference_type;
                
                Iterator(pointer ptr) : ptr_(ptr) { } //Constructor
                self_type operator++() { self_type i = *this; ptr_=ptr_->next; return i; }
                self_type operator++(int junk) { ptr_=ptr_->next; return *this; }
                reference operator*() { return *ptr_; }
                pointer operator->() { return ptr_; }
                bool operator==(const self_type& rhs) { return ptr_ == rhs.ptr_; }
                bool operator!=(const self_type& rhs) { return ptr_ != rhs.ptr_; }
                
        private:
                pointer ptr_;
        };
private:
        Node<T> *head;
        Node<T> *tail;

public:

        List(void)
        {
                head = tail = nullptr;
        }

        ~List(void)
        {
			if(head == nullptr && tail == nullptr)
			{
                Node<T> *n = head;
                Node<T> *d = n;

                while( n != nullptr )
                {
                        d = n;
						n = n->next;
                        delete d;
                }
			}
        }

        string str()
        {
                ostringstream oss;
                Node<T> *n = head;

                while(n != nullptr)
                {
                        oss << n->info;
                        n = n->next;
                }

                return oss.str();
        }

        void add(T info)
        {
                if(head == nullptr) 
                        head = tail = new Node<T>(info);
                else
                {
                        Node<T> *n = new Node<T>(info);
                        n->next = head;
                        head = n;
                }
        }

        void AddUnique(T info)
        {
            if(head == nullptr)
                    head = tail = new Node<T>(info);
            else
            {
                Node<T> *s = Search(info);
                if(s == nullptr) 
                {
                        Node<T> *n = new Node<T>(info);
                        n->next = head;
                        head = n;
                }
            }
        }

        Node<T> * Search(T info)
        {
                Node<T> *n = head;

                while(n != nullptr)
                {
                        if(n->info == info)
                                return n;
                        n = n->next;
                }
                return nullptr;
        }

        Node<T> * NodeBefore(Node<T> *actual)
        {
                Node<T> *n = head;
                while(n != nullptr)
                {
                        if(n->next == actual)
                                return n;
                        n = n->next;
                }
                return nullptr;
        }

	    void Remove(Node<T> *d)
        {
                Node<T> *b = nullptr;

                if(d == nullptr || head == nullptr)
                        return;
                else if(d == head && head == tail) 
                {
                        delete d;
                        head = tail = nullptr; 
                }
                else if(d == head)
                {
                        head = head->next;
                        delete d;
                }
                else if(d == tail)
                {
                        b = NodeBefore(d);
                        b->next = nullptr;
                        tail = b;
                        delete d;
                }
                else
                {
                        b = NodeBefore(d);
                        b->next = d->next;
                        delete d;
                }
        }

		void swap(Node<T> *one, Node<T> *another)
		{
			T oneInfo = one->info;
			T anotherInfo = another->info;
			T tempInfo;

			tempInfo = oneInfo;
			oneInfo = anotherInfo;
			anotherInfo = oneInfo;
		}

		void sort()
		{
			for (Node<T> *iter = head; iter != nullptr; iter = iter->next)
			{
				Node<T> *min = iter;

				for(Node<T> *iterB = head; iterB != nullptr; iterB = iterB->next)
				{
					if(iterB->info < iter->info)
					{
						min = iterB;
					}
				}
				swap(iter,min);
			}
		}

		T pop()
		{
			T info = tail->info;

			if  (tail == head)
			{
				delete tail;
				head = tail = nullptr;
			}
			else
			{
				Node<T> *n = tail;
				delete tail;
				this->tail = NodeBefore(n);
				this->tail->next = nullptr;
			}
			return info;
		}

		int size()
		{
			int size = 0;

			Node<T> *n = head;
			while(n->next != nullptr)
			{
				n = n->next;
				size ++;
			}
			return size +1;
		}

        Iterator begin()
        {
                return Iterator(head);
        }

        Iterator end()
        {
                return Iterator(nullptr);
        }
};


