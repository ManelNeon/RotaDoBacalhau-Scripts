using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FodasePesca : MonoBehaviour
{
    public AudioSource cidadao1;
    private bool check;

    private void Start()
    {
        check = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && check == false)
        {
            cidadao1.Stop();
            cidadao1.Play();
            check = true;
        }
    }
}
