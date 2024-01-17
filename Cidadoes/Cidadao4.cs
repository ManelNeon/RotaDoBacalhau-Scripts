using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cidadao4 : MonoBehaviour
{
    public AudioSource cidadao4;
    private bool check;

    private void Start()
    {
        check = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && check == false)
        {
            cidadao4.Stop();
            cidadao4.Play();
            check = true;
        }
    }
}
