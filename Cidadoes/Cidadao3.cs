using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cidadao3 : MonoBehaviour
{
    public AudioSource cidadao3;
    private bool check;

    private void Start()
    {
        check = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && check == false)
        {
            cidadao3.Stop();
            cidadao3.Play();
            check = true;
        }
    }
}
