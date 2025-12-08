using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<BaseItem> items = new List<BaseItem>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] InventoryItems;

    public Toggle EnableRemove;

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(BaseItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(BaseItem item)
    {
        items.Remove(item);

        ListItems();
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMPro.TMP_Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();
            var controller = obj.GetComponent<InventoryItemController>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            if (controller != null)
            {
                controller.AddItem(item);
                removeButton.onClick.RemoveAllListeners();
                removeButton.onClick.AddListener(controller.RemoveItem);
            }
            
            if (EnableRemove.isOn)
                removeButton.gameObject.SetActive(true);
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if(EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
    
        
        for (int i = 0; i < items.Count; i++)
        {
            InventoryItems[i].AddItem(items[i]);
        }
    

    }

}
