using System;
using System.Collections.Generic;
using System.Text;

namespace CustomHashTable
{
    //structure for key value 
    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }
    class MyMapNode<K,V>
    {
        public int size;
        LinkedList<KeyValue<K, V>>[] items;
        
        //constructure for initializing linked list
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        //method for getting array postion
        public int GetArrayPosition(K Key)
        {
            int pos = Key.GetHashCode() % this.size;
            return Math.Abs(pos);
        }

        //getting linked lists for particular key
        public LinkedList<KeyValue<K,V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> list = items[position];
            if (list == null)
            {
                list = new LinkedList<KeyValue<K, V>>();
                items[position] = list;
            }
            return list;
        }

        //adding into the hastable
        public void Add(K Key,V Value)
        {
            int pos = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(pos);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = Key, Value = Value };
            linkedList.AddLast(item);
        }

        //checking whether the elements is already present or not
        public int Check(K Key)
        {
            int pos = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(pos);
            int count = 1;
            bool found = false;
            KeyValue<K, V> foundKey = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> keyVal in linkedList)
            {
                if (keyVal.Key.Equals(Key))
                {
                    count = Convert.ToInt32(keyVal.Value) + 1;
                    found = true;
                    foundKey = keyVal;
                }
            }

                if (found)
                {
                    linkedList.Remove(foundKey);
                    return count;
                }
                else
                {
                    return 1;
                }
                
            
        }

        //get values based on key
        public V Get(K Key)
        {
            int pos = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> list = GetLinkedList(pos);
            foreach (KeyValue<K, V> keyValue in list)
            {
                if (keyValue.Key.Equals(Key))
                {

                    return keyValue.Value;
                }
            }
            return default(V);
        }
    }
}
