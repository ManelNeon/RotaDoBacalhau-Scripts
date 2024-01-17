using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessradius = 8f;
    public Material agromat;
    [HideInInspector] public bool isAggro;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist < awarenessradius)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = agromat;
        }
    }
}
