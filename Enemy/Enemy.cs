using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    public float enemyHealth = 2f;
    
    public GameObject gunHitEffect;
    void Start()
    {
        
    }

    void Update()
    {
        death(); 
    }


    private void death()
    {
        if (enemyHealth <= 0 && this.gameObject != null)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
            if (this.gameObject.CompareTag("Boss"))
            {
                SceneManager.LoadScene("Congratulations");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Boss"))
            {
                other.GetComponent<PlayerHealth>().damagePlayer(60);
            }
            else
            {
                other.GetComponent<PlayerHealth>().damagePlayer(15);
                Destroy(this.gameObject);
            }  
        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }
}
