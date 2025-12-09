using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //[SerializeField]GameObject pauseMenu;
    [SerializeField]GameObject winMenu;

    UIMananger uiManager;
    

    public static bool isGamePaused;

    bool prevCursorVisible;
    CursorLockMode prevLockState;

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
        /*pauseMenu.SetActive(false);
        isGamePaused = false;

        prevCursorVisible = Cursor.visible;
        prevLockState = Cursor.lockState; */

        UpdateCollectionUI();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        } */

        if (itemsCollected >= 4)
        {
            itemsProgressText.color = Color.yellow;
        }
    }

    /*public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;


        prevCursorVisible = Cursor.visible;
        prevLockState = Cursor.lockState;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

     
        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(null);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

        Cursor.visible = prevCursorVisible;
        Cursor.lockState = prevLockState;
    } */

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