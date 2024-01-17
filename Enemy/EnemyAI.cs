using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playerTransform;
    private NavMeshAgent enemyNavMeshAgent;

    public float timer = 5;
    private float bulletTime;
    public float bulletSpeed;

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
        if (enemyAwareness.isAggro)
        {
            enemyNavMeshAgent.SetDestination(playerTransform.position);
        }
    }
}
