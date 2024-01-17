using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;

    public bool requiresKey;
    public bool reqRed , reqGreen, reqBlue;
    private bool doorOpened;

    public AudioSource doorOpen;

    public GameObject areaToSpawn;

    private void Start()
    {
        doorOpened = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(requiresKey && doorOpened == false)
            {
                if (reqRed && other.GetComponent<PlayerIventory>().hasRed)
                {
                    doorOpen.Stop();
                    doorOpen.Play();
                    doorAnim.SetTrigger("OpenDoor");
                    other.GetComponent<PlayerIventory>().hasRed = false;
                    CanvasManager.Instance.DeleteKeys("red");
                    areaToSpawn.SetActive(true);
                    doorOpened = true;
                }
                if (reqGreen && other.GetComponent<PlayerIventory>().hasGreen)
                {

                    doorOpen.Stop();
                    doorOpen.Play();
                    doorAnim.SetTrigger("OpenDoor");
                    CanvasManager.Instance.DeleteKeys("green");
                    other.GetComponent<PlayerIventory>().hasGreen = false;
                    areaToSpawn.SetActive(true);
                    doorOpened = true;

                }
                if (reqBlue && other.GetComponent<PlayerIventory>().hasBlue)
                {
                    doorOpen.Stop();
                    doorOpen.Play();
                    doorAnim.SetTrigger("OpenDoor");
                    other.GetComponent<PlayerIventory>().hasBlue = false;              
                    CanvasManager.Instance.DeleteKeys("blue");
                    areaToSpawn.SetActive(true);
                    doorOpened = true;
                }
            }
            else if (doorOpened == false)
            {
                doorOpen.Stop();
                doorOpen.Play();
                doorAnim.SetTrigger("OpenDoor");
                areaToSpawn.SetActive(true);
                doorOpened = true;
            }
        }
    }
}
