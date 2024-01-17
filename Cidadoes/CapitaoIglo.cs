using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitaoIglo : MonoBehaviour
{
    public AudioSource capitaoiglo;
    private bool check;

    private void Start()
    {
        check = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && check == false)
        {
            capitaoiglo.Stop();
            capitaoiglo.Play();
            check = true;
        }
    }
}
