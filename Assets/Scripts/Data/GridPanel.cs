using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPanel : MonoBehaviour
{
    public Transform[] Grids;
    public Dictionary<Transform, GameObject> dictionary = new Dictionary<Transform, GameObject>();

    public static GridPanel instance = null;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        foreach(Transform trans in Grids)
        {
            dictionary.Add(trans, trans.gameObject);
        }
    }
    public Transform GetEmptyGrid()
    {
        foreach (Transform trans in Grids)
        {
            if (trans.childCount == 0)
                return trans;
        }
        return null;
    }

    public Transform GetExistItem(string name)
    {
        foreach (Transform trans in Grids)
        {
            if (trans.childCount != 0)
            {
                if (trans.GetChild(0).GetChild(1).GetComponent<Text>().text == name)
                {
                    return trans;
                }
            }
        }
        /*for (int i = 0; i <= emptyIndex; i++)
        {
            if (Grids[i].GetChild(0).GetChild(1).GetComponent<Text>().text == name)
            {
                return Grids[i];
            }
        }*/
        return null;
    }

    public string GetItemFromTransform(Transform transform)
    {
        /*for (int i = 0; i <= emptyIndex; i++)
        {
            if (Grids[i] == transform&&Grids[i].childCount!=0)
            {
                return Grids[i].GetChild(0).GetChild(1).GetComponent<Text>().text;
            }

        }*/
        foreach (Transform trans in Grids)
        {
            if (trans.childCount != 0)
            {
                if (trans==transform)
                {
                    return trans.GetChild(0).GetChild(1).GetComponent<Text>().text;
                }
            }
        }
        return null;
    }
}