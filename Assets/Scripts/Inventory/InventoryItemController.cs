using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public BaseItem item;
    public Player player;

    public Button RemoveButton;
    public Button UseButton;

        void Awake()
    {
        if (UseButton != null)
        {
            UseButton.onClick.RemoveAllListeners();
            UseButton.onClick.AddListener(UseItem);
        }
        if (RemoveButton != null)
        {
            RemoveButton.onClick.RemoveAllListeners();
            RemoveButton.onClick.AddListener(RemoveItem);
        }
    }

    public void RemoveItem()
    {
        InventoryManager.instance.RemoveItem(item);

        Destroy(gameObject);
    }

    public void AddItem(BaseItem newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        if (player == null)
        {
            player = FindFirstObjectByType<Player>();
        }

        if (item == null || player == null)
        {
            Debug.LogWarning("InventoryItemController: Cannot use item; missing item or player.");
            return;
        }

        switch (item.itemType)
        {
            case BaseItem.ItemType.Food:
                player.IncreaseHealth(item.value);
                break;
            case BaseItem.ItemType.Drink:
                player.IncreaseHydration(item.value);
                break;
            case BaseItem.ItemType.Medicine:
                player.IncreaseHealth(item.value);
                break;
            case BaseItem.ItemType.Other:
                break;
            default: Debug.Log("Item type not recognized.");
                break;

        }

        RemoveItem();
    }

}
