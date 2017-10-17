using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{

    static Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    public static void SaveData(string name,Item item)
    {
        if (itemDictionary.ContainsKey(name))
            item.Count++;
        else
            itemDictionary.Add(name, item);
    }

    public static Item GetItem(string name)
    {
        if (itemDictionary.ContainsKey(name))
            return itemDictionary[name];
        else
            return null;
    }

    public static void DeleteItem(string name)
    {
        if (itemDictionary.ContainsKey(name))
        {
            itemDictionary.Remove(name);
        }
    }

    public static bool ContainItem(string name)
    {
        return itemDictionary.ContainsKey(name);
    }
    
}
