using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour {

    Image itemImage;
    public Text itemName;
    public Text itemCount;
	void Start () {
        itemImage = transform.gameObject.GetComponent<Image>();
    }
	
	
	void Update () {
		
	}

    public void SetImage(string path)
    {
        //Debug.Log(itemImage.);

        itemImage.sprite = Resources.Load<Sprite>(path);
    }

    public void SetName(string name)
    {
        itemName.text = name;
    }

    public void SetCount(string count)
    {
        
        itemCount.text = count;
    }
}
