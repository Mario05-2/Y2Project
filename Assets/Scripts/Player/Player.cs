using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public float maxHealth = 100f;
    public float currentHealth = 80f; 
    public float maxHunger = 100f;
    public float currentHunger = 80f;
    public float maxHydration = 100f;
    public float currentHydration = 80f;

    [Header("Drain Rates")]
    public float hungerDrainRate = 10f;
    public float hydrationDrainRate = 20f;

    [Header("Health Penalty Rates")]
    public float starvationDamage = 6f;
    public float dehydrationDamage = 7f;

    [Header("Temperature Stats")]
    public float temperatureLevel = 100f;
    public float currentTemperature = 80f;

    [Header("Test Values")]
    public float testHealing = 10f;
    public float damage = 20f;

    [Header("UI Bars")]
    public Slider healthBar;
    public Slider hungerBar;
    public Slider hydrationBar;

    [Header("Full Screen Shader Controller")]
    public FullScreenShaderController fssc;
    
    public UIMananger uiManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        currentHunger = maxHunger;
        hungerBar.maxValue = maxHunger;
        hungerBar.value = currentHunger;

        currentHydration = maxHydration;
        hydrationBar.maxValue = maxHydration;
        hydrationBar.value = currentHydration;

        currentTemperature = temperatureLevel;
    }

    

    // Update is called once per frame
    void Update()
    {
        DrainHunger();
        DrainHydration();

        // apply health penalties based on current hunger/hydration each frame
        HealthPenalties();

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Damage();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DrainHunger();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DrainHydration();
        }
    }

    public void DrainHunger()
    {
        currentHunger -= hungerDrainRate * Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        hungerBar.value = currentHunger;
        //Debug.Log(currentHunger);
        if (currentHunger <= 0)
        {
            Debug.Log("Player is starving");
        }
    }

    public void DrainHydration()
    {
        currentHydration -= hydrationDrainRate * Time.deltaTime;
        currentHydration = Mathf.Clamp(currentHydration, 0, maxHydration);
        hydrationBar.value = currentHydration;
        //Debug.Log(currentHydration);
        if (currentHydration <= 0)
        {
            Debug.Log("Player is dehydrated");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;
        Debug.Log(currentHealth);
    }

    public void IncreaseHunger(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        hungerBar.value = currentHunger;
        Debug.Log(currentHunger);
    }

    public void IncreaseHydration(float amount)
    {
        currentHydration += amount;
        currentHydration = Mathf.Clamp(currentHydration, 0, maxHydration);
        hydrationBar.value = currentHydration;
        Debug.Log(currentHydration);
    }

    public void HealthPenalties()
    {
        if (currentHunger <= 0 && currentHydration <= 0)
        {
            currentHealth -= (starvationDamage + dehydrationDamage) * Time.deltaTime;
        }
        else if (currentHunger <= 0)
        {
            currentHealth -= starvationDamage * Time.deltaTime;
        }
        else if (currentHydration <= 0)
        {
            currentHealth -= dehydrationDamage * Time.deltaTime;
        }

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //Debug.Log(currentHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Damage()
    {
        currentHealth -= damage; 
        healthBar.value = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        fssc.StartFreeze();
        uiManager.DeathMenu();
        Debug.Log("Player has died.");
    }


}
