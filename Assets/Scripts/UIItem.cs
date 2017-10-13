using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour {

    Image itemImage;
    Text itemName;
    Text itemCount;
	void Start () {
        itemImage = GetComponent<Image>();
        itemName = transform.GetChild(0).GetComponent<Text>();
        itemCount = transform.GetChild(1).GetComponent<Text>();
    }
	
	
	void Update () {
		
	}

    void SetUIItemInformation()
    {
        
    }
}
