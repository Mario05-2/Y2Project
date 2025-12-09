using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]GameObject winMenu;

    UIMananger uiManager;
    
    [Header("Item Collection")]
    [SerializeField] public int itemsNeeded = 5;
    [SerializeField] public int itemsCollected = 0;
    [Header("Collection UI")]
    [SerializeField] public TMP_Text itemsProgressText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCollectionUI();
    }

    void Update()
    {
        if (itemsCollected >= 4)
        {
            itemsProgressText.color = Color.yellow;
        }
    }

    public void CollectItem(int amount = 1)
    {
        itemsCollected += amount;
        UpdateCollectionUI();
        CheckWinCondition();
    }

    public void RemoveCollected(int amount = 1)
    {
        itemsCollected = Mathf.Max(0, itemsCollected - amount);
        UpdateCollectionUI();
    }

    void UpdateCollectionUI()
    {
        if (itemsProgressText != null)
            itemsProgressText.text = $"Collected: {itemsCollected} / {itemsNeeded}";
    }

    void CheckWinCondition()
    {
        if (itemsCollected >= itemsNeeded)
        {
            winMenu.SetActive(true);
        }
    }
}