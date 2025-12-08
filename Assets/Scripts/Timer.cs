using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    
    public FullScreenShaderController fssc;
    public UIMananger uiManager;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (remainingTime <= 5 && remainingTime > 0)
        {
            fssc.StartFreeze();
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            fssc.StartFreeze();
            uiManager.DeathMenu();
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
