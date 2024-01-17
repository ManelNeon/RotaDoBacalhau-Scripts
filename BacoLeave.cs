using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacoLeave : MonoBehaviour
{
    public GameObject baco;
    public GameObject pointTransform;
    public AudioSource bacoLeave;

    private bool passed;
    void Start()
    {
        passed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && passed == false)
        {
            bacoLeave.Stop();
            bacoLeave.Play();
            baco.transform.position = pointTransform.transform.position;
            passed = true;
        }
    }
}
