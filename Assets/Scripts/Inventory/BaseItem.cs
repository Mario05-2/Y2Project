using UnityEngine;

[CreateAssetMenu(fileName = "New Base Item", menuName = "Inventory/Base Item")]
public class BaseItem : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType itemType;

    public enum ItemType
    {
        Food,
        Drink,
        Medicine,
        Other
    }
}
