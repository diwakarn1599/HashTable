using System;
using System.Collections.Generic;
using System.Text;

namespace CustomHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Custom Hash Table");
            //string to be set in hashtable
            string str = "To be or not to be".ToLower();
            //converting string to array
            string[] arr = str.Split();

            //set for getting unique elements in array
            HashSet<string> set = new HashSet<string>(arr);
            int count;
            //object for mymap class
            MyMapNode<string, int> map = new MyMapNode<string, int>(arr.Length);
            for(int i = 0; i < arr.Length; i++)
            {
                count = map.Check(arr[i]);
                if (count > 1)
                {
                    map.Add(arr[i], count);
                }
                else
                {

                    map.Add(arr[i], 1);
                }
            }
           
            //printing values with frequency
            foreach(var i in set)
            {
                Console.WriteLine($"{i}---> {map.Get(i)}");
            }
        }
    }
}
