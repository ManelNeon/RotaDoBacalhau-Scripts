using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cidadao5 : MonoBehaviour
{
    public AudioSource cidadao5;
    private bool check;

    private void Start()
    {
        check = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && check == false)
        {
            cidadao5.Stop();
            cidadao5.Play();
            check = true;
        }
    }
}
