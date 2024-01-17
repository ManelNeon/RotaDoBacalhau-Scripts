using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIventory : MonoBehaviour
{
    public bool hasRed;
    public bool hasGreen;
    public bool hasBlue;

    public void Start()
    {
        CanvasManager.Instance.ClearKeys();
    }
}
