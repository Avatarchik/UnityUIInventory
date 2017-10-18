using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPanel : MonoBehaviour
{
    public Transform[] Grids;
    public List<int> emptyGrids = new List<int>();
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

    public void InitEmptyGrid()
    {
        for(int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i].childCount == 0)
                emptyGrids.Add(i);
        }
    }

    public Transform GetFirstTransform()
    {
        foreach(Transform trans in Grids)
        {
            if (trans.childCount != 0)
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
        return null;
    }

    public string GetItemFromTransform(Transform transform)
    {
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

    public void ArragngeItem()
    {
        for(int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i].childCount == 0)
            {
                for(int j = i + 1; j < Grids.Length; j++)
                {
                    if (Grids[j].childCount != 0)
                    {
                        Grids[j].GetChild(0).SetParent(Grids[i]);
                        Grids[i].GetChild(0).transform.localPosition = new Vector3(-70, -70, 0);
                        break;
                    }
                }
            }
        }
    }
}