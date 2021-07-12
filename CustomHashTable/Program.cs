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
            string str = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations".ToLower();
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
            Console.WriteLine("Enter the string you want to remove");
            string remove = Console.ReadLine().ToLower();
            //printing values with frequency
            foreach(var i in set)
            {
                Console.WriteLine($"{i}---> {map.Get(i)}");
            }
            map.Remove(remove);
            foreach (var i in set)
            {
                Console.WriteLine($"{i}---> {map.Get(i)}");
            }
        }
    }
}
