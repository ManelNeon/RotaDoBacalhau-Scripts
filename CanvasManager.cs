using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI ammo;
    public TextMeshProUGUI armor;

    public Image healthIndicator;

    public GameObject gun;
    public GameObject sword;

    public Sprite health1; 
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;

    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;

    private static CanvasManager instance;
    public static CanvasManager Instance 
    { 
        get 
        { 
            return instance; 
        } 
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void UpdateHealth(int healthValue)
    {
        health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);
    }
    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }
    public void UpdateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
    }
    
    public void UpdateWeapon(int number)
    {
        if (number == 1)
        {
            sword.SetActive(false);
            gun.SetActive(true);
        }
        if (number == 2)
        {
            gun.SetActive(false);
            sword.SetActive(true);
        }
    }

    public void UpdateHealthIndicator(int healthvalue)
    {
        if (healthvalue >= 75)
        {
            healthIndicator.sprite = health1;
        }
        if (healthvalue >= 50 && healthvalue < 75)
        {
            healthIndicator.sprite = health2;
        }
        if (healthvalue >= 25 && healthvalue <50)
        {
            healthIndicator.sprite = health3;
        }
        if (healthvalue < 25)
        {
            healthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if (keyColor == "red")
        {
            redKey.SetActive(true);
        }
        if (keyColor == "green")
        {
            greenKey.SetActive(true);
        }
        if (keyColor == "blue")
        {
            blueKey.SetActive(true);
        }
    }

    public void DeleteKeys(string keyColor)
    {
        if (keyColor == "red")
        {
            redKey.SetActive(false);
        }
        if (keyColor == "green")
        {
            greenKey.SetActive(false);
        }
        if (keyColor == "blue")
        {
            blueKey.SetActive(false);
        }
    }

    public void ClearKeys()
    {
        redKey.SetActive(false);
        greenKey.SetActive(false);
        blueKey.SetActive(false);
    }
}
