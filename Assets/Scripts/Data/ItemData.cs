using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{

    static Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    public static void SaveData(string name,Item item)
    {
        if (itemDictionary.ContainsKey(name)) {
            itemDictionary[name].Count = item.Count;
        }
            
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

    public static void DeleteItem(string name,Item item)
    {
        if (itemDictionary.ContainsKey(name))
        {
            item.Count --;
            if (item.Count == 0)
            {
                Debug.Log("aaaa");
                itemDictionary.Remove(name);
                return;
            }
            SaveData(name, item);Debug.Log(itemDictionary.Count);
        }
        
        else
            return;
    }

    public static bool ContainItem(string name)
    {
        return itemDictionary.ContainsKey(name);
    }

    public static void AddItem(string name)
    {
        if (itemDictionary.ContainsKey(name))
            itemDictionary[name].Count++;
        else
            return;
    }
    
}
