using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanel : MonoBehaviour
{

    public Transform[] Grids;

    public static GridPanel instance = null;

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
                return Grids[i];
            }
        }
        return null;
    }

    public bool GetExistItem(Transform transform)
    {
        for (int i = 0; i < Grids.Length; i++)
        {
            if (Grids[i]==transform)
            {
                return true;
            }
        }
        return false;
    }
}