using System.Collections.Generic;
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
        if (ItemContent == null || InventoryItem == null)
        {
            Debug.LogError("InventoryManager: Assign ItemContent and InventoryItem prefab in the Inspector.");
            return;
        }
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
                if (removeButton != null)
                {
                    removeButton.onClick.RemoveAllListeners();
                    removeButton.onClick.AddListener(controller.RemoveItem);
                }
            }
            
            if (removeButton != null && EnableRemove != null && EnableRemove.isOn)
                removeButton.gameObject.SetActive(true);
        }
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove == null || ItemContent == null)
        {
            Debug.LogWarning("InventoryManager: EnableRemove or ItemContent not assigned.");
            return;
        }

        if(EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                var controller = item.GetComponent<InventoryItemController>();
                if (controller != null && controller.RemoveButton != null)
                    controller.RemoveButton.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                var controller = item.GetComponent<InventoryItemController>();
                if (controller != null && controller.RemoveButton != null)
                    controller.RemoveButton.gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        if (ItemContent != null)
            InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
    }

}
