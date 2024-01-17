using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacoAppear : MonoBehaviour
{
    public GameObject baco;
    public GameObject pointTransform;
    public AudioSource bacoTalk;

    private bool passed;

    private void Start()
    {
        passed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && passed == false)
        {
            bacoTalk.Stop();
            bacoTalk.Play();
            baco.transform.position = pointTransform.transform.position;
            passed = true;
        }
    }
}
