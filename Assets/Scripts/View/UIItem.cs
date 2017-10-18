using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour {

    public Image itemImage;
    public Text itemName;
    public Text itemCount;
    public void SetImage(string path)
    {
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
