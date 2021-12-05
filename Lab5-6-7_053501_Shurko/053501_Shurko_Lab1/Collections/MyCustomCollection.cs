using System;
using System.Collections.Generic;
using System.Text;

namespace _053501_Shurko_Lab1.Collections {
    class MyCustomCollectionValues<T> {
        public MyCustomCollectionValues<T> next;
        public T value;
    }

    class MyCustomCollection<T>: Interfaces.ICustomCollection<T>{
        private MyCustomCollectionValues<T> head;
        private MyCustomCollectionValues<T> current;
        public MyCustomCollection(){
            head = null;
            current = null;
        }
        public T this[int index] {
            get {
                if (index < 0 || index > this.Count) {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                MyCustomCollectionValues<T> pointer = head;
                int size = 0;
                while (index != size++) {
                    pointer = pointer.next;
                }
                return pointer.value;
            }
            set {
                if (index < 0 || index > this.Count) {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
                MyCustomCollectionValues<T> pointer = head;
                int size = 0;
                while (index != size++) {
                    pointer = pointer.next;
                }                
                pointer.value = value;
            }
        }
        public void Reset() {
            this.current = head;
        }
        public void Next() {
            if (this.current == null || this.current.next == null) {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            current = current.next;
        }
        public T Current() {
            if (isEmpty()) {
                throw new ArgumentNullException("Collection is empty! Can't get value");
            }
            return this.current.value;
        }
        public int Count { 
            get {
                int size = 0;
                if (!isEmpty()) {
                    MyCustomCollectionValues<T> pointer = head;                    
                    while (pointer.next != null) {
                        ++size;
                        pointer = pointer.next;
                    }
                    ++size;
                }
                return size;
            } 
        }
        public void Add(T item) {
            MyCustomCollectionValues<T> newItem = new MyCustomCollectionValues<T>();
            newItem.next = null;
            newItem.value = item;
            if (head == null) {
                head = new MyCustomCollectionValues<T>();
                current = new MyCustomCollectionValues<T>();
                head = newItem;
            }
            this.current.next = newItem;
            this.current = newItem;
        }
        private bool isEmpty() {
            if (head == null) {
                return true;
            }
            return false;
        }
        public void Remove(T item) {
            bool flagSucceed = false;
            if (!isEmpty()) {
                MyCustomCollectionValues<T> pointer = head;
                if (item.Equals(pointer.value)) {
                    head = pointer.next;
                    if (pointer == current) {
                        current = pointer.next;
                    }
                    flagSucceed = true;
                } else {
                    while (pointer.next != null && flagSucceed == false) {
                        if (item.Equals(pointer.next.value)) {
                            pointer.next = pointer.next.next;
                            if (pointer.next == current) {
                                current = pointer.next.next;
                            }
                            flagSucceed = true;
                        } else {
                            pointer = pointer.next;
                        }
                    }
                }
                if (flagSucceed == false) {
                    throw new Exception("There is no such an item in collection!");
                }
            } else { 
                throw new ArgumentNullException("Collection is Empty!");
            }
        }
        public T RemoveCurrent() {
            MyCustomCollectionValues<T> saveItem = current;
            MyCustomCollectionValues<T> pointer = head;
            if (pointer == current) {
                head = current = pointer.next;
            } else {
                while (pointer != null) {
                    if (pointer.next == current) {
                        pointer.next = current.next;
                        current = pointer;
                        break;
                    }
                    pointer = pointer.next;
                }
            }
            return saveItem.value;
        }
    }
}
