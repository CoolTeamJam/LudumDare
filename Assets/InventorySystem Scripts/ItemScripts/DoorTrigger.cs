using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator door = null;

    public bool openState = false;
    public bool closeState = false;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        door.SetBool("open", false);
        door.SetBool("close", false);
        if (other.CompareTag("Player"))
        {
            if (openTrigger || closeTrigger)
            {    
                openState = true;
                Debug.Log("Enter the door " + openState);
            }
        }
        AnimatorSet();
        openState = false;
        closeState = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger || closeTrigger) //both state play the same animation
            {
                //door.Play("Door_Close", 0, 0.0f);
                closeState = true; //trigger door reset
                openState = false;
            }
        }
        AnimatorSet();
        closeState = false;
        openState = false;
    }

    private void AnimatorSet()
    {
        door.SetBool("open", openState);
        door.SetBool("close", closeState);
    }
}
