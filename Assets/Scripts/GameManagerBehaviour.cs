using UnityEngine;
using UnityEngine.EventSystems;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public static bool isGamePaused;

    bool prevCursorVisible;
    CursorLockMode prevLockState;

    void Start()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;

        prevCursorVisible = Cursor.visible;
        prevLockState = Cursor.lockState;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
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
    }
}