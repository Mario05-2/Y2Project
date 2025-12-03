using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public BaseItem item;

    void Pickup()
    {
        InventoryManager.instance.AddItem(item);
        Destroy(gameObject);
    }

    //change to pressing F when in range later
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

}
