using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public float maxHealth = 100f;
    public float currentHealth = 80f; 
    public float maxHunger = 100f;
    public float currentHunger = 80f;
    public float maxHydration = 100f;
    public float currentHydration = 80f;

    [Header("Tempature")]
    public float temperatureLevel = 100f;
    public float currentTemperature = 80f;

    public float testHealing = 10f;

    public float damage = 20f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Damage();
        }
    }

    public void Damage()
    {
        currentHealth -= damage; 
        Debug.Log(currentHealth);

    }


}
