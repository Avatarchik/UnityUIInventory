using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{

    static Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>();

    public static void SaveData(int id,Item item)
    {
        if (itemDictionary.ContainsKey(id))
            item.Count++;
        else
            itemDictionary.Add(id, item);
    }

    public static Item GetItem(int id)
    {
        if (itemDictionary.ContainsKey(id))
            return itemDictionary[id];
        else
            return null;
    }

    public static void DeleteItem(int id)
    {
        if (itemDictionary.ContainsKey(id))
        {
            itemDictionary.Remove(id);
        }
    }

    public static bool ContainItem(Item item)
    {
        return itemDictionary.ContainsValue(item);
    }

    public static Item GetItemFromName(string name)
    {
        for(int i = 0; i < itemDictionary.Count; i++)
        {
            if (itemDictionary[i].Name == name)
                return itemDictionary[i];
        }
        return null;
    }
}
