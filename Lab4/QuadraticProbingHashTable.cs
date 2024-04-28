using System;

class QuadraticProbingHashTable
{
    private const int DefaultCapacity = 10;
    private const double LoadFactorThreshold = 0.7;

    private int size;
    private int capacity;
    private KeyValuePair<string, int>[] items;


    public QuadraticProbingHashTable()
    {
        capacity = DefaultCapacity;
        items = new KeyValuePair<string, int>[capacity];    
        size = 0;
    }

    private int Hash(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += c;
        }
        return Math.Abs(hash % capacity);
    }

    private int QuadraticProbe(int hash, int i)
    {
        return Math.Abs(hash + i * i) % capacity;
    }

    public void Add(string key, int value)
    {
        if ((double)size / capacity >= LoadFactorThreshold)
        {
            Resize();
        }      
        int hash = Hash(key);
        int index = hash;
        int i = 1;
        while (items[index].Key != null)
        {
            if (items[index].Key == key)
            {
                items[index] = new KeyValuePair<string, int>(key, value);
                return; 
            }
            index = QuadraticProbe(hash, i);
            i++;
        }
        items[index] = new KeyValuePair<string, int>(key, value);
        size++;
    }

    public bool ContainsKey(string key)
    {
        int hash = Hash(key);
        int index = hash;
        int i = 1;
        while (items[index].Key != null)
        {
            if (items[index].Key == key)
            {
                return true;
            }
            index = QuadraticProbe(hash, i);
            i++;
        }
        return false;
    }

    public int Get(string key)
    {
        int hash = Hash(key);
        int index = hash;
        int i = 1;
        while (items[index].Key != null)
        {
            if (items[index].Key == key)
            {
                return items[index].Value;
            }
            index = QuadraticProbe(hash, i);
            i++;
        }
        return -1;
    }

    public bool Remove(string key)
    {
        int hash = Hash(key);
        int index = hash;
        int i = 1;
        while (items[index].Key != null)
        {
            if (items[index].Key == key)
            {
                items[index] = new KeyValuePair<string, int>();
                size--;
                return true;
            }
            index = QuadraticProbe(hash, i);
            i++;
        }
        return false;
    }

    private void Resize()
    {
        int newCapacity = capacity * 2;
        KeyValuePair<string, int>[] newItems = new KeyValuePair<string, int>[newCapacity];

        for (int i = 0; i < capacity; i++)
        {
            if (items[i].Key != null)
            {
                int hash = Hash(items[i].Key);
                int index = hash;
                int j = 1;
                while (newItems[index].Key != null)
                {
                    index = QuadraticProbe(hash, j);
                    j++;
                }
                newItems[index] = items[i];
            }
        }
        items = newItems;
        capacity = newCapacity;
    }
    public void PrintHashTable()
    {
        Console.WriteLine("Hashtable contents:");
        for (int i = 0; i < capacity; i++)
        {
            if (items[i].Key != null)
            {
                Console.WriteLine($"Index {i}: Key: {items[i].Key}, Value: {items[i].Value}");
            }
            else
            {
                Console.WriteLine($"Index {i}: Empty");
            }
        }
    }
}
