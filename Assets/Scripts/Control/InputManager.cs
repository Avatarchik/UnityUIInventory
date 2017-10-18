using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(0, 9);
            InventoryManager.instance.StoreItem(index);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GridPanel.instance.ArragngeItem();
        }
    }
}
