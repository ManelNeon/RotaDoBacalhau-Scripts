using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cidadao2 : MonoBehaviour
{
    public AudioSource cidadao2;
    private bool check;

    private void Start()
    {
        check = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && check == false)
        {
            cidadao2.Stop();
            cidadao2.Play();
            check = true;
        }
    }
}
