using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Interactable
{
    //[SerializeField] private Animator door = null;

    public bool openState = false;
    public bool closeState = false;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    float currentYaw = 0;
    public float MaxOpenYaw = 140f;
    public float DoorSpeed = 60f;

    void Update()
    {
        if (openState && currentYaw < MaxOpenYaw)
        {
            float dt = Time.deltaTime;

            currentYaw += DoorSpeed * dt;

            currentYaw = Mathf.Clamp(currentYaw, 0, MaxOpenYaw);

            transform.Rotate(0.0f, currentYaw - transform.localEulerAngles.y, 0.0f);
        }


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    door.SetBool("open", false);
    //    door.SetBool("close", false);
    //    if (other.CompareTag("Player"))
    //    {
    //        if (openTrigger || closeTrigger)
    //        {    
    //            openState = true;
    //            Debug.Log("Enter the door " + openState);
    //        }
    //    }
    //    AnimatorSet();
    //    openState = false;
    //    closeState = false;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (openTrigger || closeTrigger) //both state play the same animation
    //        {
    //            //door.Play("Door_Close", 0, 0.0f);
    //            closeState = true; //trigger door reset
    //            openState = false;
    //        }
    //    }
    //    AnimatorSet();
    //    closeState = false;
    //    openState = false;
    //}

    private void AnimatorSet()
    {
        //door.SetBool("open", openState);
        //door.SetBool("close", closeState);
    }

    public override void Interact(GameObject iInstigator)
    {
        //door.SetBool("open", false);
        //door.SetBool("close", false);
        if (iInstigator.CompareTag("Player"))
        {
            openState = true;
            Debug.Log("Enter the door " + openState);
        }
        //AnimatorSet();
    }

    public override string GetInteractMessage()
    {
        return "open door";
    }

    public override bool CanInteract()
    {
        return !openState;
    }

    public override void ActivateInteractable()
    {
        
    }
}
