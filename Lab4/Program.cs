using Lab4;
using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static KeyValuePair<string, int> GenerateRandomKeyValuePair()
    {
        Random rnd = new Random();
        string key = "";
        for (int i = 0; i < 5; i++)
        {
            key += (char)rnd.Next('a', 'z' + 1); 
        }   
        int value = rnd.Next(100); 

        return new KeyValuePair<string, int>(key, value);
    }
    static void Main(string[] args)
    {

        //QuadraticProbingHashTable hashTable1 = new QuadraticProbingHashTable();

        //Stopwatch stopwatch = Stopwatch.StartNew();
        //int count = 51200;
        //for (int i = 0;i < count;i++) 
        //{
        //    KeyValuePair<string, int> pair = GenerateRandomKeyValuePair();
        //    hashTable1.Add(pair.Key, pair.Value);
        //}
        //stopwatch.Stop();
        //Console.WriteLine($"Хэш таблица из {count} элементов составлена за {stopwatch.Elapsed.TotalSeconds}");
        //hashTable1.PrintHashTable();
        //hashTable1.Add("abcde", 3);
        //Console.WriteLine("\n" + hashTable1.Get("abcde"));
        //hashTable1.PrintHashTable();
        //hashTable1.Remove("abcde");
        //hashTable1.PrintHashTable();

        //HashTableChain hashTable2 = new HashTableChain();
        //int count = 15;
        //for (int i = 0; i < count; i++)
        //{
        //    KeyValuePair<string, int> pair = GenerateRandomKeyValuePair();
        //    hashTable2.Add(pair.Key, pair.Value);
        //}
        //hashTable2.PrintHashTable();


        BloomFilter filter = new BloomFilter(100, 3);
        filter.Add("apple");
        filter.Add("banana");
        filter.Add("orange");
        Console.WriteLine(filter.Contains("apple"));   // true
        Console.WriteLine(filter.Contains("banana"));  // true
        Console.WriteLine(filter.Contains("orange"));  // true
        Console.WriteLine(filter.Contains("grape"));   // false
        Console.WriteLine(filter.Contains("melon"));   // false
    }
}