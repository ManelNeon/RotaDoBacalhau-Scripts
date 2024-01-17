using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAIBoss : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playerTransform;
    private NavMeshAgent enemyNavMeshAgent;

    public float timer = 5;
    private float bulletTime;
    public float bulletSpeed;

    public GameObject player;
    public Transform spawnPoint;
    public GameObject enemyBullet;
    
    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playerTransform = FindObjectOfType<PlayerMove>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var dist = this.gameObject.transform.position - playerTransform.transform.position;


        if (enemyAwareness.isAggro)
        {
            transform.LookAt(playerTransform.transform.position);
            ShootAtPlayer();

            if (dist.x <= 2 || dist.z <= 2)
            {
                timer = 1;
                bulletSpeed = 500;
            }
            else
            {
                timer = 2;
                bulletSpeed = 350;
            }
        }
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0)
        {
            return;
        }

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletrig = bulletObj.GetComponent<Rigidbody>();
        bulletrig.AddForce(bulletrig.transform.forward * bulletSpeed * 5);
        
    }

}
