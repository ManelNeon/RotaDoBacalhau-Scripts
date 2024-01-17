using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isHealth;
    public bool isArmor;
    public bool isAmmo;

    public int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                other.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject);
            }
            if (isArmor)
            {
                other.GetComponent<PlayerHealth>().GiveArmor(amount, this.gameObject);
            }
            if (isAmmo)
            {
                if (other.GetComponentInChildren<Gun>() != null)
                {
                    other.GetComponentInChildren<Gun>().GiveAmmo(amount, this.gameObject);
                }
                else
                {
                    other.GetComponentInChildren<Sword>().GiveAmmo(amount, this.gameObject);
                }
            }
        }
    }
}
