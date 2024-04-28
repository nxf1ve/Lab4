using System;
using System.Collections;

public class BloomFilter
{
    private BitArray bitArray;
    private int[] hashFunctions;
    private int size;

    public BloomFilter(int size, int numHashFunctions)
    {
        this.size = size;
        bitArray = new BitArray(size);
        hashFunctions = new int[numHashFunctions];
        InitializeHashFunctions();
    }

    private void InitializeHashFunctions()
    {
        Random rand = new Random();
        for (int i = 0; i < hashFunctions.Length; i++)
        {
            hashFunctions[i] = rand.Next();
        }
    }

    private int Hash(int hashFunctionIndex, string value)
    {
        int hash = 0;
        foreach (char c in value.ToString())
        {
            hash += c;
        }
        return Math.Abs(hash ^ hashFunctions[hashFunctionIndex]) % size;
    }

    public void Add(string value)
    {
        for (int i = 0; i < hashFunctions.Length; i++)
        {
            int index = Hash(i, value);
            bitArray[index] = true;
        }
    }

    public bool Contains(string value)
    {
        for (int i = 0; i < hashFunctions.Length; i++)
        {
            int index = Hash(i, value);
            if (!bitArray[index])
                return false;
        }
        return true;
    }
}

