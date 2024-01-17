using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    private int health = 100;

    public int maxArmor;
    private int armor;

    public AudioSource hurtSound;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }


    public void damagePlayer(int damage)
    {
        hurtSound.Stop();
        hurtSound.Play();

        if (armor > 0)
        {
            if (armor >= damage)
            {
                armor -= damage;
            }
            else if (armor < damage)
            {
                int remainingDamage;

                remainingDamage = damage - armor;

                armor = 0;

                health -= remainingDamage;
            }
        }
        else
        {
            health -= damage;
        }
        if (health <= 0)
        {
            Debug.Log("Player has died");
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }
    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
            Destroy(pickup);
        }
        CanvasManager.Instance.UpdateHealth(health);
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }

        if (armor >= maxArmor)
        {
            armor = maxArmor;
            Destroy(pickup);
        }
        CanvasManager.Instance.UpdateArmor(armor);
    }
}
