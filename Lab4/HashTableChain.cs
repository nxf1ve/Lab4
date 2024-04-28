namespace Lab4;

public class HashTableChain
{
    private const int DefaultCapacity = 10;

    private int capacity;
    private LinkedList<KeyValuePair<string, int>>[] items;

    public HashTableChain()
    {
        capacity = DefaultCapacity;
        items = new LinkedList<KeyValuePair<string, int>>[capacity];
    }

    private int Hash(string key)
    {
        int hash = 0;
        foreach (char c in key.ToString())
        {
            hash += c;
        }
        return Math.Abs(hash % capacity);
    }

    public void Add(string key, int value)
    {
        int index = Hash(key);
        if (items[index] == null)
        {
            items[index] = new LinkedList<KeyValuePair<string, int>>();
        }

        foreach (var pair in items[index])
        {
            if (pair.Key.Equals(key))
            {
                return;
            }
        }

        items[index].AddLast(new KeyValuePair<string, int>(key, value));
    }

    public bool ContainsKey(string key)
    {
        int index = Hash(key);
        if (items[index] != null)
        {
            foreach (var pair in items[index])
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public int Get(string key)
    {
        int index = Hash(key);
        if (items[index] != null)
        {
            foreach (var pair in items[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }
        return -1;
    }

    public bool Remove(string key)
    {
        int index = Hash(key);
        if (items[index] != null)
        {
            var node = items[index].First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    items[index].Remove(node);
                    return true;
                }
                node = node.Next;
            }
        }
        return false;
    }

    public void PrintHashTable()
    {
        Console.WriteLine("Hashtable contents:");
        for (int i = 0; i < capacity; i++)
        {
            if (items[i] != null)
            {
                Console.Write($"Index {i}: ");
                foreach (var pair in items[i])
                {
                    Console.Write($"[{pair.Key} - {pair.Value}] ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Index {i}: Empty");
            }
        }
    }
}
