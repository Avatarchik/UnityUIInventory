using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance = null;
    public Dictionary<int, Item> ItemDictionary;
    public GameObject DragUI;
    bool isDrag;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        UIMove.OnEnter += UIMoveOnEnter;
        UIMove.OnExit += UIMoveOnExit;
        UIMove.OnDraging += UIMoveOnDraging;
        UIMove.EndDrag += UIMoveOnEndDrag;
    }
    void Start()
    {
        LoadData();
        UITips.instance.HideTips();
    }

    void Update()
    {
        if (isDrag)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            DragUI.transform.localPosition = position;
        }
    }

    void CreateItem(Item item, Transform parent)
    {
        GameObject newItem = Resources.Load("grid") as GameObject;
        if (item.Count != 1)
            item.Count = 1;
        if (newItem.GetComponent<UIItem>() != null)
        {
            newItem.GetComponent<UIItem>().SetName(item.Name);
            newItem.GetComponent<UIItem>().SetCount(item.Count.ToString());
            newItem.GetComponent<UIItem>().SetImage(item.Picture);
        }
        GameObject.Instantiate(newItem, parent);
        //Debug.Log(item.Name +"aaaa"+ item.Count);
        ItemData.SaveData(item.Name, item);
    }

    void ResetOneItem(Item item, Transform parent)
    {
        GameObject newItem = Resources.Load("grid") as GameObject;
        if (newItem.GetComponent<UIItem>() != null)
        {
            newItem.GetComponent<UIItem>().SetName(item.Name);
            newItem.GetComponent<UIItem>().SetCount(item.Count.ToString());
            newItem.GetComponent<UIItem>().SetImage(item.Picture);
        }
        GameObject.Instantiate(newItem, parent);
    }

    void ResetAmonutsItem(Item item, GameObject newItem)
    {
        if (newItem.GetComponent<UIItem>() != null)
        {
            newItem.GetComponent<UIItem>().SetName(item.Name);
            newItem.GetComponent<UIItem>().SetCount(item.Count.ToString());
            newItem.GetComponent<UIItem>().SetImage(item.Picture);
        }
    }

    public void StoreItem(int ID)
    {
        if (!ItemDictionary.ContainsKey(ID))
            return;

        else
        {
            Item temp = ItemDictionary[ID];
            if (temp != null)
            {
                if (ItemData.ContainItem(temp.Name))
                {
                    ItemData.AddItem(temp.Name);
                    GridPanel.instance.GetExistItem(temp.Name).GetChild(0).GetChild(2).GetComponent<Text>().text = temp.Count.ToString();
                    ItemData.SaveData(temp.Name, temp);
                }
                else
                {
                    Transform parent = GridPanel.instance.GetEmptyGrid();
                    if (parent == null)
                    {
                        ///TO:
                        Debug.Log("背包装满!");
                        return;
                    }
                    else
                        CreateItem(temp, parent);
                }
            }
        }
    }

    void LoadData()
    {
        ItemDictionary = new Dictionary<int, Item>();
        Weapon weapon1 = new Weapon(0, "武器1", "武器1武器1武器1武器1武器1", 100
            , 1, "ItemPicture/weapon1", 1, 20);
        Weapon weapon2 = new Weapon(1, "武器2", "武器2武器2武器2武器2武器2", 200
            , 1, "ItemPicture/weapon2", 1, 20);
        Weapon weapon3 = new Weapon(2, "武器3", "武器3武器3武器3武器3武器3", 300
            , 1, "ItemPicture/weapon3", 1, 20);
        Ring ring = new Ring(3, "戒指", "戒指戒指戒指戒指戒指戒指", 400, 1, "ItemPicture/ring", 5, 20, 10);
        Necklace necklace = new Necklace(4, "项链", "项链项链项链项链项链", 500, 1, "ItemPicture/necklace", 5, 20, 10);
        Armor armor = new Armor(5, "护甲", "护甲护甲护甲护甲护甲护甲", 600, 1, "ItemPicture/armor", 6, 100);
        Medicine medicine1 = new Medicine(6, "小血瓶", "小血瓶小血瓶小血瓶小血瓶", 20, 1, "ItemPicture/hp1", 1, 50, 0);
        Medicine medicine2 = new Medicine(7, "大血瓶", "大血瓶大血瓶大血瓶大血瓶", 20, 1, "ItemPicture/hp2", 1, 150, 0);
        Medicine medicine3 = new Medicine(8, "小蓝瓶", "小蓝瓶小蓝瓶小蓝瓶小蓝瓶", 20, 1, "ItemPicture/mp1", 1, 0, 100);
        ItemDictionary.Add(weapon1.Id, weapon1);
        ItemDictionary.Add(weapon2.Id, weapon2);
        ItemDictionary.Add(weapon3.Id, weapon3);
        ItemDictionary.Add(ring.Id, ring);
        ItemDictionary.Add(armor.Id, armor);
        ItemDictionary.Add(necklace.Id, necklace);
        ItemDictionary.Add(medicine1.Id, medicine1);
        ItemDictionary.Add(medicine2.Id, medicine2);
        ItemDictionary.Add(medicine3.Id, medicine3);
    }

    void UIMoveOnEnter(Transform transform)
    {
        string name = GridPanel.instance.GetItemFromTransform(transform);
        if (name != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            string content = UITips.instance.GetStringText(ItemData.GetItem(name));
            UITips.instance.UpdateText(content);
            UITips.instance.SetLocalPosition(position);
            UITips.instance.ShowTips();
        }
    }

    void UIMoveOnExit()
    {
        if (UITips.instance.gameObject.activeSelf)
            UITips.instance.HideTips();
    }

    void UIMoveOnDraging(Transform gridTransform)
    {
        isDrag = true;
        if (gridTransform.childCount == 0)
            return;
        Item item = ItemData.GetItem(gridTransform.GetChild(0).GetChild(1).GetComponent<Text>().text);
        DragUI.SetActive(true);
        DragUI.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Picture);

    }

    void UIMoveOnEndDrag(Transform lastTransform, Transform nextTransform)
    {
        isDrag = false;
        DragUI.SetActive(false);
        string name = lastTransform.GetChild(0).GetChild(1).GetComponent<Text>().text;
        Item item = ItemData.GetItem(name);
        if (nextTransform == null)
        {
            ItemData.DeleteItem(name, item);
            if (item.Count == 0)
                Destroy(GridPanel.instance.GetExistItem(name).GetChild(0).gameObject);
            else
                GridPanel.instance.GetExistItem(item.Name).GetChild(0).GetChild(2).
                GetComponent<Text>().text = ItemData.GetItem(name).Count.ToString();
        }
        else if (nextTransform.tag == "Grid")
        {
            if (nextTransform.gameObject.name != "background")
            {
                ResetOneItem(item, nextTransform);
                Destroy(lastTransform.GetChild(0).gameObject);
            }
            else
            {
                Item prevGirdItem = ItemData.GetItem(name);
                string nextName = nextTransform.parent.GetChild(1).GetComponent<Text>().text;
                Item enterGirdItem = ItemData.GetItem(nextName);
                ResetAmonutsItem(prevGirdItem, nextTransform.parent.gameObject);
                ResetAmonutsItem(enterGirdItem, lastTransform.GetChild(0).gameObject);
            }
        }

    }
}
