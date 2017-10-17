using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPanel : MonoBehaviour
{

    public Transform[] Grids;

    public static GridPanel instance = null;

    int emptyIndex = 0;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    public Transform GetEmptyGrid()
    {
        for (int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i].childCount == 0)
            {
                emptyIndex = i;
                return Grids[i];
            }
        }
        return null;
    }

    public Transform GetExistItem(string name)
    {
        for (int i = 0; i <= emptyIndex; i++)
        {
            if (Grids[i].GetChild(0).GetChild(1).GetComponent<Text>().text == name)
            {
                return Grids[i];
            }
        }
        return null;
    }

    public string GetItemFromTransform(Transform transform)
    {
        for (int i = 0; i <= emptyIndex; i++)
        {
            if (Grids[i] == transform&&Grids[i].childCount!=0)
            {
                return Grids[i].GetChild(0).GetChild(1).GetComponent<Text>().text;
            }

        }
        return null;
    }
}