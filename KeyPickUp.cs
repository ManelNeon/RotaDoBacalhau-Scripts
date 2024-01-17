using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public bool isRedKey, isGreenKey, isBlueKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRedKey)
            {
                Destroy(gameObject);
                other.GetComponent<PlayerIventory>().hasRed = true;
                CanvasManager.Instance.UpdateKeys("red");
            }
            if (isGreenKey)
            {
                Destroy(gameObject);
                other.GetComponent<PlayerIventory>().hasGreen = true;
                CanvasManager.Instance.UpdateKeys("green");
            }
            if (isBlueKey)
            {
                other.GetComponent<PlayerIventory>().hasBlue = true;
                Destroy(gameObject);
                CanvasManager.Instance.UpdateKeys("blue");
            }
        }
    }
}
