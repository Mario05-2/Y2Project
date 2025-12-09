using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int amount = 1;
    [SerializeField] private bool destroyOnCollect = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var gm = FindFirstObjectByType<GameManager>();
        if (gm == null)
        {
            Debug.LogWarning("GameManager not found in scene. Cannot collect.");
            return;
        }

        gm.CollectItem(amount);

        if (destroyOnCollect)
        {
            Destroy(gameObject);
        }
    }
}
